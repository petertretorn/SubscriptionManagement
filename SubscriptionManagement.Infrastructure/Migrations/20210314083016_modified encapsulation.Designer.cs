// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SubscriptionManagement.Infrastructure;

namespace SubscriptionManagement.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210314083016_modified encapsulation")]
    partial class modifiedencapsulation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SubscriptionManagement.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f54268ae-67d8-4e5e-ac1b-8a1189592f72"),
                            Email = "something@gmail.com",
                            Name = "Jens Pedersen"
                        });
                });

            modelBuilder.Entity("SubscriptionManagement.Domain.Entities.Subscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime2");

                    b.Property<bool>("HasDefaulted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7e801f18-0a6c-4075-8364-ada243c3ab87"),
                            CustomerId = new Guid("f54268ae-67d8-4e5e-ac1b-8a1189592f72"),
                            HasDefaulted = false,
                            Start = new DateTime(2020, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SubscriptionManagement.Domain.Entities.Customer", b =>
                {
                    b.OwnsOne("SubscriptionManagement.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");

                            b1.HasData(
                                new
                                {
                                    CustomerId = new Guid("f54268ae-67d8-4e5e-ac1b-8a1189592f72"),
                                    City = "Odensen",
                                    PostalCode = "5000",
                                    Street = "Fuglebakken 33"
                                });
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("SubscriptionManagement.Domain.Entities.Subscription", b =>
                {
                    b.HasOne("SubscriptionManagement.Domain.Entities.Customer", null)
                        .WithMany("Subscriptions")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("SubscriptionManagement.Domain.ValueObjects.PricingPlan", "PricingPlan", b1 =>
                        {
                            b1.Property<Guid>("SubscriptionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("CurrencyCode")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<decimal>("FlatFee")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<decimal>("MonthlyRate")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("SubscriptionId");

                            b1.ToTable("Subscriptions");

                            b1.WithOwner()
                                .HasForeignKey("SubscriptionId");

                            b1.HasData(
                                new
                                {
                                    SubscriptionId = new Guid("7e801f18-0a6c-4075-8364-ada243c3ab87"),
                                    CurrencyCode = "DKK",
                                    FlatFee = 100m,
                                    MonthlyRate = 99m
                                });
                        });

                    b.OwnsOne("SubscriptionManagement.Domain.ValueObjects.SubscriptionType", "Type", b1 =>
                        {
                            b1.Property<Guid>("SubscriptionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Description")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Level")
                                .HasColumnType("int");

                            b1.Property<int>("PeriodInDays")
                                .HasColumnType("int");

                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("SubscriptionId");

                            b1.ToTable("Subscriptions");

                            b1.WithOwner()
                                .HasForeignKey("SubscriptionId");

                            b1.HasData(
                                new
                                {
                                    SubscriptionId = new Guid("7e801f18-0a6c-4075-8364-ada243c3ab87"),
                                    Description = "some description",
                                    Level = 4,
                                    PeriodInDays = 365,
                                    ProductId = new Guid("defd8328-4265-4845-996e-2a7427c315e5")
                                });
                        });

                    b.Navigation("PricingPlan");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("SubscriptionManagement.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Subscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
