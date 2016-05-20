using Coffsy.ConsoleApp.Entities;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffsy.ConsoleApp
{
    public class CoffsyContext : DbContext
    {
        private static bool _created;

        public CoffsyContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }

        public DbSet<Produto> Produtos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"Data Source=localhost\sqlexpress;Initial Catalog=ALLTADM;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
          
            return base.SaveChanges();
        }
    }
}
