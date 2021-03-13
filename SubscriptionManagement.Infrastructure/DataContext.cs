using Microsoft.EntityFrameworkCore;
using SubscriptionManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Customer> Users { get; set; }
        public DbSet<Subscription> Subscription { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscription>().OwnsOne(s => s.SubscriptionType);
            
            modelBuilder.Entity<Subscription>().OwnsOne(s => s.PricingPlan);
            
            modelBuilder.Entity<Customer>().OwnsOne(c => c.Address);


            FakeData.Init();

            modelBuilder.Entity<Customer>().HasData(FakeData.Users);
        }
    }
}
