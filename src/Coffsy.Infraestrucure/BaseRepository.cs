using Coffsy.Domain.Interface.Repository;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Coffsy.Infraestrucure
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        internal DbContext Db;
        internal DbSet<TEntity> DbSet;

        public BaseRepository(DbContext context)
        {
            Db = context;

            DbSet = context.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
            Db.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.AsNoTracking();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        internal void ExecuteSql(string SQL)
        {
            Db.Database.ExecuteSqlCommand(SQL);
        }

        public IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = DbSet.AsQueryable();

            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            query = query.Where(predicate);

            return query.AsNoTracking().AsEnumerable();
        }
    }
}
