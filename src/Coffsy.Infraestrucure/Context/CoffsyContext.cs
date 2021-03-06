﻿using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Coffsy.Domain.Entities;

namespace Coffsy.vPet.Infraestructure.data.Context
{
    public class CoffsyContext : DbContext
    {
        private static bool _created;

        public CoffsyContext()
        {
            if (!_created)
            {
                _created = true;
             //  Database.EnsureCreated();
            }
        }

        public DbSet<Carrier> Carriers { get; set; }
     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\sqlexpress;Initial Catalog=Axado;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateCreated") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateCreated").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DateCreated").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateUpdate") != null))
            {
                entry.Property("DateUpdate").CurrentValue = DateTime.Now;
            }

            return base.SaveChanges();
        }
    }
}