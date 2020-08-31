using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.OrmApp.Migrations
{
    public partial class changed_content_entity_auditable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Contents",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Contents",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Contents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Contents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Contents");
        }
    }
}
