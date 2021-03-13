using Microsoft.EntityFrameworkCore;
using SubscriptionManagement.Domain.Entities;
using SubscriptionManagement.Domain.ValueObjects;
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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().OwnsOne(c => c.Address);

            var customerId = Guid.NewGuid();

            modelBuilder.Entity<Customer>(b =>
            {
                b.HasData(new
                {
                    Email = "something@gmail.com",
                    Id = customerId,
                    Name = "Jens Pedersen",
                });
                b.OwnsOne(c => c.Address).HasData(new
                {
                    CustomerId = customerId,
                    Street = "Fuglebakken 33",
                    City = "Odensen",
                    PostalCode = "5000"
                });
            });


            // ------------------------------------------------------

            var subscriptionId = Guid.NewGuid();

            modelBuilder.Entity<Subscription>(b =>
            {
                b.HasData(
                    new
                    {
                        Id = subscriptionId,
                        CustomerId = customerId,
                        HasDefaulted = false,
                        AutomaticallyReneweble = true,
                        Start = new DateTime(2020, 10, 22),
                    });

                b.OwnsOne(s => s.Type)
                    .HasData(new
                    {
                        SubscriptionId = subscriptionId,
                        ProductId = Guid.NewGuid(),
                        Description = "some description",
                        SubscriptionPeriodInDays = 90,
                        Level = Level.Premium,
                        PeriodInDays = 365
                    });

                b.OwnsOne(s => s.PricingPlan)
                    .HasData(new
                    {
                        SubscriptionId = subscriptionId,
                        FlatFee = 100m,
                        MonthlyRate = 99m,
                        CurrencyCode = "DKK"
                    });
            });
        }
    }
}
