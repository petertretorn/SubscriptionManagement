using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SubscriptionManagement.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubscriptionType_ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubscriptionType_Level = table.Column<int>(type: "int", nullable: true),
                    SubscriptionType_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionType_PeriodInDays = table.Column<int>(type: "int", nullable: true),
                    PricingPlan_FlatFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PricingPlan_MonthlyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PricingPlan_CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutomaticallyReneweble = table.Column<bool>(type: "bit", nullable: false),
                    HasDefaulted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name", "Address_City", "Address_PostalCode", "Address_Street" },
                values: new object[] { new Guid("b7f803c5-43b9-4644-974f-9dc728078042"), "something@gmail.com", "Jens Pedersen", "Odensen", "5000", "Fuglebakken 33" });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "AutomaticallyReneweble", "CustomerId", "End", "HasDefaulted", "Start", "SubscriptionType_Description", "SubscriptionType_Level", "SubscriptionType_PeriodInDays", "SubscriptionType_ProductId", "PricingPlan_CurrencyCode", "PricingPlan_FlatFee", "PricingPlan_MonthlyRate" },
                values: new object[] { new Guid("a1302b50-6e85-4686-ae54-2c14fa3107e5"), true, new Guid("b7f803c5-43b9-4644-974f-9dc728078042"), null, false, new DateTime(2020, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "some description", 4, 365, new Guid("0e4c5d3a-8c5b-4ee6-ae3b-3b6656d224e2"), "DKK", 100m, 99m });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_CustomerId",
                table: "Subscriptions",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
