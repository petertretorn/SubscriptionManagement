using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SubscriptionManagement.Infrastructure.Migrations
{
    public partial class addedcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("54554e5c-9b0d-4487-a739-0ab931bfb4f1"));

            migrationBuilder.DropColumn(
                name: "Type_Description",
                table: "Subscriptions");

            migrationBuilder.AddColumn<int>(
                name: "Type_Category",
                table: "Subscriptions",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("33eb22ad-6700-45db-a209-03b9a6addacb"),
                column: "Address_City",
                value: "Odense");

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "CustomerId", "End", "HasDefaulted", "Start", "PricingPlan_CurrencyCode", "PricingPlan_FlatFee", "PricingPlan_MonthlyRate", "Type_Category", "Type_Level", "Type_PeriodInDays", "Type_ProductId" },
                values: new object[] { new Guid("0ca497ab-d921-4025-930a-81eaf2a4e9f3"), new Guid("33eb22ad-6700-45db-a209-03b9a6addacb"), null, false, new DateTime(2020, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "DKK", 100m, 99m, 2, 4, 365, new Guid("9536fd67-0845-4f1e-9cbd-7cdbdda49e44") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("0ca497ab-d921-4025-930a-81eaf2a4e9f3"));

            migrationBuilder.DropColumn(
                name: "Type_Category",
                table: "Subscriptions");

            migrationBuilder.AddColumn<string>(
                name: "Type_Description",
                table: "Subscriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("33eb22ad-6700-45db-a209-03b9a6addacb"),
                column: "Address_City",
                value: "Odensen");

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "CustomerId", "End", "HasDefaulted", "Start", "PricingPlan_CurrencyCode", "PricingPlan_FlatFee", "PricingPlan_MonthlyRate", "Type_Description", "Type_Level", "Type_PeriodInDays", "Type_ProductId" },
                values: new object[] { new Guid("54554e5c-9b0d-4487-a739-0ab931bfb4f1"), new Guid("33eb22ad-6700-45db-a209-03b9a6addacb"), null, false, new DateTime(2020, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "DKK", 100m, 99m, "some description", 4, 365, new Guid("cc507cd9-b9bc-49da-b5fa-9a77b36c4816") });
        }
    }
}
