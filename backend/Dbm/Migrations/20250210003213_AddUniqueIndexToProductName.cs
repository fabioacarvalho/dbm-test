﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dbm.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexToProductName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Name",
                table: "Products");
        }
    }
}
