using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SubscriptionManagement.Infrastructure.Migrations
{
    public partial class modifiedencapsulation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("6552414a-b8db-48f5-9640-f6be68d492d5"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("c79ebb0b-d6fb-41fd-b110-ad2b722f2345"));

            migrationBuilder.DropColumn(
                name: "AutomaticallyReneweble",
                table: "Subscriptions");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name", "Address_City", "Address_PostalCode", "Address_Street" },
                values: new object[] { new Guid("f54268ae-67d8-4e5e-ac1b-8a1189592f72"), "something@gmail.com", "Jens Pedersen", "Odensen", "5000", "Fuglebakken 33" });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "CustomerId", "End", "HasDefaulted", "Start", "PricingPlan_CurrencyCode", "PricingPlan_FlatFee", "PricingPlan_MonthlyRate", "Type_Description", "Type_Level", "Type_PeriodInDays", "Type_ProductId" },
                values: new object[] { new Guid("7e801f18-0a6c-4075-8364-ada243c3ab87"), new Guid("f54268ae-67d8-4e5e-ac1b-8a1189592f72"), null, false, new DateTime(2020, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "DKK", 100m, 99m, "some description", 4, 365, new Guid("defd8328-4265-4845-996e-2a7427c315e5") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("7e801f18-0a6c-4075-8364-ada243c3ab87"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("f54268ae-67d8-4e5e-ac1b-8a1189592f72"));

            migrationBuilder.AddColumn<bool>(
                name: "AutomaticallyReneweble",
                table: "Subscriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name", "Address_City", "Address_PostalCode", "Address_Street" },
                values: new object[] { new Guid("c79ebb0b-d6fb-41fd-b110-ad2b722f2345"), "something@gmail.com", "Jens Pedersen", "Odensen", "5000", "Fuglebakken 33" });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "AutomaticallyReneweble", "CustomerId", "End", "HasDefaulted", "Start", "Type_Description", "Type_Level", "Type_PeriodInDays", "Type_ProductId", "PricingPlan_CurrencyCode", "PricingPlan_FlatFee", "PricingPlan_MonthlyRate" },
                values: new object[] { new Guid("6552414a-b8db-48f5-9640-f6be68d492d5"), true, new Guid("c79ebb0b-d6fb-41fd-b110-ad2b722f2345"), null, false, new DateTime(2020, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "some description", 4, 365, new Guid("0f6873b5-766c-4852-8db3-2a363c483830"), "DKK", 100m, 99m });
        }
    }
}
