using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TTMS.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class RoleUserSeedAndSetRoleToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("23fe4e81-5015-42a0-8d76-d1f08c6b227a"), "8/10/2025 1:02:03 AM", "Manager", "Manager" },
                    { new Guid("5e76c76d-4cf6-4784-8796-fd9f5c8cf29d"), "8/10/2025 1:02:01 AM", "Admin", "ADMIN" },
                    { new Guid("b7a80d7e-24d8-4cc3-8981-ee4e1b5b1b3a"), "4/19/2025 1:02:04 AM", "Employee", "AUTHOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1a2073e8-d2ce-46b2-863b-3aac8d29d163"), 0, "5b20a20f-40a0-4f82-bbf4-8c6995d4091a", "admin@demo.com", true, "Admin", false, null, "ADMIN@DEMO.COM", "ADMIN@DEMO.COM", "AQAAAAIAAYagAAAAEPv1uwjqNLu2C9rkru6m7yllqLpPOqke5Y1sJktzmrf2LcWrYNNoNVU+JU1r89mcng==", null, false, "ee4bfc33-f7b1-4a2f-9a97-cc0c923b0493", false, "admin@demo.com" },
                    { new Guid("1e945b04-5cd5-419e-ae40-5185eb5a94d5"), 0, "1b498b47-6d94-44f0-8f89-4b1840d26034", "employee@demo.com", true, "Employee", false, null, "EMPLOYEE@DEMO.COM", "EMPLOYEE@DEMO.COM", "AQAAAAIAAYagAAAAEPv1uwjqNLu2C9rkru6m7yllqLpPOqke5Y1sJktzmrf2LcWrYNNoNVU+JU1r89mcng==", null, false, "6c9f38b3-a1b4-4a0d-b5f6-0ee6f6a42f0a", false, "employee@demo.com" },
                    { new Guid("a036ccd4-08fc-4fe6-b217-adc8f84386fc"), 0, "35b88d79-5b64-4f9c-a6b5-8d9bbba5bc1b", "manager@demo.com", true, "Manager", false, null, "MANAGER@DEMO.COM", "MANAGER@DEMO.COM", "AQAAAAIAAYagAAAAEPv1uwjqNLu2C9rkru6m7yllqLpPOqke5Y1sJktzmrf2LcWrYNNoNVU+JU1r89mcng==", null, false, "a27b30aa-6f6f-4fc0-bf8c-38cc9e7f2835", false, "manager@demo.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("5e76c76d-4cf6-4784-8796-fd9f5c8cf29d"), new Guid("1a2073e8-d2ce-46b2-863b-3aac8d29d163") },
                    { new Guid("b7a80d7e-24d8-4cc3-8981-ee4e1b5b1b3a"), new Guid("1e945b04-5cd5-419e-ae40-5185eb5a94d5") },
                    { new Guid("23fe4e81-5015-42a0-8d76-d1f08c6b227a"), new Guid("a036ccd4-08fc-4fe6-b217-adc8f84386fc") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5e76c76d-4cf6-4784-8796-fd9f5c8cf29d"), new Guid("1a2073e8-d2ce-46b2-863b-3aac8d29d163") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b7a80d7e-24d8-4cc3-8981-ee4e1b5b1b3a"), new Guid("1e945b04-5cd5-419e-ae40-5185eb5a94d5") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("23fe4e81-5015-42a0-8d76-d1f08c6b227a"), new Guid("a036ccd4-08fc-4fe6-b217-adc8f84386fc") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23fe4e81-5015-42a0-8d76-d1f08c6b227a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5e76c76d-4cf6-4784-8796-fd9f5c8cf29d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b7a80d7e-24d8-4cc3-8981-ee4e1b5b1b3a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a2073e8-d2ce-46b2-863b-3aac8d29d163"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1e945b04-5cd5-419e-ae40-5185eb5a94d5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a036ccd4-08fc-4fe6-b217-adc8f84386fc"));
        }
    }
}
