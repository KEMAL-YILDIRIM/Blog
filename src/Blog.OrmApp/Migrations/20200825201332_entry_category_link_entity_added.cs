using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.OrmApp.Migrations
{
    public partial class entry_category_link_entity_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Categories_CategoryId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Users_CreatedBy",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Users_UserId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Users_UserId",
                table: "Phones");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Users_UserId1",
                table: "Phones");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_Users_OwnerId",
                table: "RefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Entries_CategoryId",
                table: "Entries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Entries");

            migrationBuilder.RenameTable(
                name: "RefreshToken",
                newName: "RefreshTokens");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshToken_OwnerId",
                table: "RefreshTokens",
                newName: "IX_RefreshTokens_OwnerId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContentId1",
                table: "Entries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntryId",
                table: "Contents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Html",
                table: "Contents",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens",
                column: "Token");

            migrationBuilder.CreateTable(
                name: "EntryCategories",
                columns: table => new
                {
                    EntryId = table.Column<string>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    EntryId1 = table.Column<string>(nullable: true),
                    CategoryId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryCategories", x => new { x.EntryId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_EntryCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryCategories_Categories_CategoryId1",
                        column: x => x.CategoryId1,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntryCategories_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "EntryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryCategories_Entries_EntryId1",
                        column: x => x.EntryId1,
                        principalTable: "Entries",
                        principalColumn: "EntryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ContentId1",
                table: "Entries",
                column: "ContentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_EntryId",
                table: "Contents",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryCategories_CategoryId",
                table: "EntryCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryCategories_CategoryId1",
                table: "EntryCategories",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_EntryCategories_EntryId1",
                table: "EntryCategories",
                column: "EntryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Entries_EntryId",
                table: "Contents",
                column: "EntryId",
                principalTable: "Entries",
                principalColumn: "EntryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Contents_ContentId1",
                table: "Entries",
                column: "ContentId1",
                principalTable: "Contents",
                principalColumn: "ContentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Users_CreatedBy",
                table: "Entries",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Users_UserId",
                table: "Entries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Users_UserId",
                table: "Phones",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Users_UserId1",
                table: "Phones",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_OwnerId",
                table: "RefreshTokens",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Entries_EntryId",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Contents_ContentId1",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Users_CreatedBy",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Users_UserId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Users_UserId",
                table: "Phones");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Users_UserId1",
                table: "Phones");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_OwnerId",
                table: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "EntryCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Entries_ContentId1",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Contents_EntryId",
                table: "Contents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ContentId1",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "EntryId",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "Html",
                table: "Contents");

            migrationBuilder.RenameTable(
                name: "RefreshTokens",
                newName: "RefreshToken");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshTokens_OwnerId",
                table: "RefreshToken",
                newName: "IX_RefreshToken_OwnerId");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken",
                column: "Token");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_CategoryId",
                table: "Entries",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Categories_CategoryId",
                table: "Entries",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Users_CreatedBy",
                table: "Entries",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Users_UserId",
                table: "Entries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Users_UserId",
                table: "Phones",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Users_UserId1",
                table: "Phones",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_Users_OwnerId",
                table: "RefreshToken",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
