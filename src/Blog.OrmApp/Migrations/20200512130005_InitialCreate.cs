using System;

using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.OrmApp.Migrations
{
	public partial class InitialCreate : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Category",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Category", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Contents",
				columns: table => new
				{
					ContentId = table.Column<string>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Contents", x => x.ContentId);
				});

			migrationBuilder.CreateTable(
				name: "Type",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Type", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					Id = table.Column<string>(nullable: false),
					FirstName = table.Column<string>(nullable: true),
					LastName = table.Column<string>(nullable: true),
					Username = table.Column<string>(nullable: true),
					Email = table.Column<string>(nullable: true),
					Password = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Entries",
				columns: table => new
				{
					EntryId = table.Column<string>(nullable: false),
					CreatedBy = table.Column<string>(nullable: true),
					UpdatedBy = table.Column<string>(nullable: true),
					CreatedAt = table.Column<DateTime>(nullable: false),
					UpdatedAt = table.Column<DateTime>(nullable: true),
					Title = table.Column<string>(nullable: true),
					ReadingTime = table.Column<TimeSpan>(nullable: false),
					CategoryId = table.Column<int>(nullable: true),
					ContentId = table.Column<string>(nullable: true),
					UserId = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Entries", x => x.EntryId);
					table.ForeignKey(
						name: "FK_Entries_Category_CategoryId",
						column: x => x.CategoryId,
						principalTable: "Category",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Entries_Contents_ContentId",
						column: x => x.ContentId,
						principalTable: "Contents",
						principalColumn: "ContentId",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Entries_Users_CreatedBy",
						column: x => x.CreatedBy,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Entries_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Phones",
				columns: table => new
				{
					Number = table.Column<string>(nullable: false),
					TypeId = table.Column<int>(nullable: true),
					UserId = table.Column<string>(nullable: true),
					UserId1 = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Phones", x => x.Number);
					table.ForeignKey(
						name: "FK_Phones_Type_TypeId",
						column: x => x.TypeId,
						principalTable: "Type",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Phones_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Phones_Users_UserId1",
						column: x => x.UserId1,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Entries_CategoryId",
				table: "Entries",
				column: "CategoryId");

			migrationBuilder.CreateIndex(
				name: "IX_Entries_ContentId",
				table: "Entries",
				column: "ContentId");

			migrationBuilder.CreateIndex(
				name: "IX_Entries_CreatedBy",
				table: "Entries",
				column: "CreatedBy");

			migrationBuilder.CreateIndex(
				name: "IX_Entries_UserId",
				table: "Entries",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_Phones_TypeId",
				table: "Phones",
				column: "TypeId");

			migrationBuilder.CreateIndex(
				name: "IX_Phones_UserId",
				table: "Phones",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_Phones_UserId1",
				table: "Phones",
				column: "UserId1");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Entries");

			migrationBuilder.DropTable(
				name: "Phones");

			migrationBuilder.DropTable(
				name: "Category");

			migrationBuilder.DropTable(
				name: "Contents");

			migrationBuilder.DropTable(
				name: "Type");

			migrationBuilder.DropTable(
				name: "Users");
		}
	}
}
