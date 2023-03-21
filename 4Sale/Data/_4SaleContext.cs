﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _4Sale.Models;

namespace _4Sale.Data
{
    public class _4SaleContext : DbContext
    {
        public _4SaleContext (DbContextOptions<_4SaleContext> options)
            : base(options)
        {
        }

        public DbSet<_4Sale.Models.Item> Item { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .Property(x => x.Type)
                .HasConversion<int>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
