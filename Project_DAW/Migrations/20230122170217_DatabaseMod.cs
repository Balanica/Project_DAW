using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDAW.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseMod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "OrdersProduct",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "OrdersProduct",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "OrdersProduct",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "OrdersProduct");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "OrdersProduct");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrdersProduct");
        }
    }
}
