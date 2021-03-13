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
                name: "Subscription",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubscriptionType_ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubscriptionType_Level = table.Column<int>(type: "int", nullable: true),
                    SubscriptionType_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionType_SubscriptionPeriodInDays = table.Column<int>(type: "int", nullable: true),
                    PricingPlan_FlatFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PricingPlan_MonthlyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PricingPlan_CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutomaticallyReneweble = table.Column<bool>(type: "bit", nullable: false),
                    HasDefaulted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscription_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name", "Address_City", "Address_PostalCode", "Address_Street" },
                values: new object[] { new Guid("0db2e155-fe61-4d45-87f7-c3af6343eb29"), "something@gmail.com", "Jens Pedersen", "Odensen", "5000", "Fuglebakken 33" });

            migrationBuilder.InsertData(
                table: "Subscription",
                columns: new[] { "Id", "AutomaticallyReneweble", "CustomerId", "End", "HasDefaulted", "Start", "SubscriptionType_Description", "SubscriptionType_Level", "SubscriptionType_ProductId", "SubscriptionType_SubscriptionPeriodInDays", "PricingPlan_CurrencyCode", "PricingPlan_FlatFee", "PricingPlan_MonthlyRate" },
                values: new object[] { new Guid("cc4fa774-5e91-4eed-9925-6379d964680c"), true, new Guid("0db2e155-fe61-4d45-87f7-c3af6343eb29"), null, false, new DateTime(2020, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "some description", 4, new Guid("6f7473d1-d484-4857-9e9f-e795d79a60f5"), 90, "DKK", 100m, 99m });

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_CustomerId",
                table: "Subscription",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
