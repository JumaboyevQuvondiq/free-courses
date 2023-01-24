using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineDars.DataAccess.Migrations
{
    public partial class SecondaryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 24, 9, 32, 1, 826, DateTimeKind.Utc).AddTicks(8605), new DateTime(2023, 1, 24, 9, 32, 1, 826, DateTimeKind.Utc).AddTicks(8607) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 21, 9, 2, 56, 632, DateTimeKind.Utc).AddTicks(4298), new DateTime(2023, 1, 21, 9, 2, 56, 632, DateTimeKind.Utc).AddTicks(4299) });
        }
    }
}
