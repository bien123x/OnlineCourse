using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCourse.Migrations
{
    /// <inheritdoc />
    public partial class AddUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "AssignedAt",
                value: new DateTime(2025, 8, 25, 7, 48, 3, 97, DateTimeKind.Utc).AddTicks(1835));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "UserRoleId",
                keyValue: 2,
                column: "AssignedAt",
                value: new DateTime(2025, 8, 25, 7, 48, 3, 97, DateTimeKind.Utc).AddTicks(1836));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 25, 7, 48, 3, 97, DateTimeKind.Utc).AddTicks(1757));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 25, 7, 48, 3, 97, DateTimeKind.Utc).AddTicks(1760));

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleName",
                table: "Roles",
                column: "RoleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionName",
                table: "Permissions",
                column: "PermissionName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Roles_RoleName",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_PermissionName",
                table: "Permissions");

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "AssignedAt",
                value: new DateTime(2025, 8, 25, 6, 38, 46, 742, DateTimeKind.Utc).AddTicks(9309));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "UserRoleId",
                keyValue: 2,
                column: "AssignedAt",
                value: new DateTime(2025, 8, 25, 6, 38, 46, 742, DateTimeKind.Utc).AddTicks(9310));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 25, 6, 38, 46, 742, DateTimeKind.Utc).AddTicks(9226));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 25, 6, 38, 46, 742, DateTimeKind.Utc).AddTicks(9228));
        }
    }
}
