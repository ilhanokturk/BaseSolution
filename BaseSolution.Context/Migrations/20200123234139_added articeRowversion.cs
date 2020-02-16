using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseSolution.Context.Migrations
{
    public partial class addedarticeRowversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Article",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Article");
        }
    }
}
