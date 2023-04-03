using System;
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
        public DbSet<_4Sale.Models.Dictionary> Dictionary { get; set; } = default!;
        public DbSet<_4Sale.Models.Invoice> Invoice { get; set; } = default!;
        public DbSet<_4Sale.Models.InvoiceContent> InvoiceContent { get; set; } = default!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dictionary>()
                .Property(x => x.Category)
                .HasConversion<int>();

            modelBuilder.Entity<Invoice>()
                .HasMany(i => i.InvoiceElements)
                .WithOne(ic => ic.Invoice)
                .HasForeignKey(ic => ic.InvoiceId);

            modelBuilder.Entity<InvoiceContent>()
                .HasIndex("InvoiceId").IsUnique(false);
            modelBuilder.Entity<InvoiceContent>()
                .HasIndex("ItemId").IsUnique(false);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.InvoiceContent)
                .WithOne(ic => ic.Item)
                .HasForeignKey<InvoiceContent>(ic => ic.ItemId);


            base.OnModelCreating(modelBuilder);
        }

        
    }
}
