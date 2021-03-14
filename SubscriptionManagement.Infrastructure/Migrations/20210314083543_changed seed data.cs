using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SubscriptionManagement.Infrastructure.Migrations
{
    public partial class changedseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("7e801f18-0a6c-4075-8364-ada243c3ab87"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("f54268ae-67d8-4e5e-ac1b-8a1189592f72"));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name", "Address_City", "Address_PostalCode", "Address_Street" },
                values: new object[] { new Guid("33eb22ad-6700-45db-a209-03b9a6addacb"), "something@gmail.com", "Jens Pedersen", "Odensen", "5000", "Fuglebakken 33" });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "CustomerId", "End", "HasDefaulted", "Start", "PricingPlan_CurrencyCode", "PricingPlan_FlatFee", "PricingPlan_MonthlyRate", "Type_Description", "Type_Level", "Type_PeriodInDays", "Type_ProductId" },
                values: new object[] { new Guid("54554e5c-9b0d-4487-a739-0ab931bfb4f1"), new Guid("33eb22ad-6700-45db-a209-03b9a6addacb"), null, false, new DateTime(2020, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "DKK", 100m, 99m, "some description", 4, 365, new Guid("cc507cd9-b9bc-49da-b5fa-9a77b36c4816") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("54554e5c-9b0d-4487-a739-0ab931bfb4f1"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("33eb22ad-6700-45db-a209-03b9a6addacb"));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name", "Address_City", "Address_PostalCode", "Address_Street" },
                values: new object[] { new Guid("f54268ae-67d8-4e5e-ac1b-8a1189592f72"), "something@gmail.com", "Jens Pedersen", "Odensen", "5000", "Fuglebakken 33" });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "CustomerId", "End", "HasDefaulted", "Start", "PricingPlan_CurrencyCode", "PricingPlan_FlatFee", "PricingPlan_MonthlyRate", "Type_Description", "Type_Level", "Type_PeriodInDays", "Type_ProductId" },
                values: new object[] { new Guid("7e801f18-0a6c-4075-8364-ada243c3ab87"), new Guid("f54268ae-67d8-4e5e-ac1b-8a1189592f72"), null, false, new DateTime(2020, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "DKK", 100m, 99m, "some description", 4, 365, new Guid("defd8328-4265-4845-996e-2a7427c315e5") });
        }
    }
}
