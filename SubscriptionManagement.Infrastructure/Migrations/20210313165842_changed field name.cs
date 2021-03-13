using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SubscriptionManagement.Infrastructure.Migrations
{
    public partial class changedfieldname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("a1302b50-6e85-4686-ae54-2c14fa3107e5"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("b7f803c5-43b9-4644-974f-9dc728078042"));

            migrationBuilder.RenameColumn(
                name: "SubscriptionType_ProductId",
                table: "Subscriptions",
                newName: "Type_ProductId");

            migrationBuilder.RenameColumn(
                name: "SubscriptionType_PeriodInDays",
                table: "Subscriptions",
                newName: "Type_PeriodInDays");

            migrationBuilder.RenameColumn(
                name: "SubscriptionType_Level",
                table: "Subscriptions",
                newName: "Type_Level");

            migrationBuilder.RenameColumn(
                name: "SubscriptionType_Description",
                table: "Subscriptions",
                newName: "Type_Description");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name", "Address_City", "Address_PostalCode", "Address_Street" },
                values: new object[] { new Guid("c79ebb0b-d6fb-41fd-b110-ad2b722f2345"), "something@gmail.com", "Jens Pedersen", "Odensen", "5000", "Fuglebakken 33" });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "AutomaticallyReneweble", "CustomerId", "End", "HasDefaulted", "Start", "Type_Description", "Type_Level", "Type_PeriodInDays", "Type_ProductId", "PricingPlan_CurrencyCode", "PricingPlan_FlatFee", "PricingPlan_MonthlyRate" },
                values: new object[] { new Guid("6552414a-b8db-48f5-9640-f6be68d492d5"), true, new Guid("c79ebb0b-d6fb-41fd-b110-ad2b722f2345"), null, false, new DateTime(2020, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "some description", 4, 365, new Guid("0f6873b5-766c-4852-8db3-2a363c483830"), "DKK", 100m, 99m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("6552414a-b8db-48f5-9640-f6be68d492d5"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("c79ebb0b-d6fb-41fd-b110-ad2b722f2345"));

            migrationBuilder.RenameColumn(
                name: "Type_ProductId",
                table: "Subscriptions",
                newName: "SubscriptionType_ProductId");

            migrationBuilder.RenameColumn(
                name: "Type_PeriodInDays",
                table: "Subscriptions",
                newName: "SubscriptionType_PeriodInDays");

            migrationBuilder.RenameColumn(
                name: "Type_Level",
                table: "Subscriptions",
                newName: "SubscriptionType_Level");

            migrationBuilder.RenameColumn(
                name: "Type_Description",
                table: "Subscriptions",
                newName: "SubscriptionType_Description");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name", "Address_City", "Address_PostalCode", "Address_Street" },
                values: new object[] { new Guid("b7f803c5-43b9-4644-974f-9dc728078042"), "something@gmail.com", "Jens Pedersen", "Odensen", "5000", "Fuglebakken 33" });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "AutomaticallyReneweble", "CustomerId", "End", "HasDefaulted", "Start", "SubscriptionType_Description", "SubscriptionType_Level", "SubscriptionType_PeriodInDays", "SubscriptionType_ProductId", "PricingPlan_CurrencyCode", "PricingPlan_FlatFee", "PricingPlan_MonthlyRate" },
                values: new object[] { new Guid("a1302b50-6e85-4686-ae54-2c14fa3107e5"), true, new Guid("b7f803c5-43b9-4644-974f-9dc728078042"), null, false, new DateTime(2020, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "some description", 4, 365, new Guid("0e4c5d3a-8c5b-4ee6-ae3b-3b6656d224e2"), "DKK", 100m, 99m });
        }
    }
}
