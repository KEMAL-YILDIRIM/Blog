using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

using System;

namespace Blog.ORM.Migrations
{
	public partial class initialize : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					UserId = table.Column<Guid>(nullable: false),
					FullName = table.Column<string>(nullable: true),
					RegisteredAt = table.Column<DateTime>(nullable: false),
					Email = table.Column<string>(nullable: true),
					Phone = table.Column<string>(nullable: true),
					Password = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users", x => x.UserId);
				});

			migrationBuilder.CreateTable(
				name: "Posts",
				columns: table => new
				{
					PostId = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					CreateDate = table.Column<DateTime>(nullable: false),
					ReadingTime = table.Column<TimeSpan>(nullable: false),
					Author = table.Column<Guid>(nullable: false),
					Title = table.Column<string>(nullable: true),
					Category = table.Column<string>(nullable: true),
					Body = table.Column<string>(nullable: true),
					UserId = table.Column<Guid>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Posts", x => x.PostId);
					table.ForeignKey(
						name: "FK_Posts_Users_Author",
						column: x => x.Author,
						principalTable: "Users",
						principalColumn: "UserId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Posts_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "UserId",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Posts_Author",
				table: "Posts",
				column: "Author");

			migrationBuilder.CreateIndex(
				name: "IX_Posts_UserId",
				table: "Posts",
				column: "UserId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Posts");

			migrationBuilder.DropTable(
				name: "Users");
		}
	}
}
