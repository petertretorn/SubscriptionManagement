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

        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscription { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FakeData.Init();

            modelBuilder.Entity<User>().HasData(FakeData.Users);
        }
    }
}
