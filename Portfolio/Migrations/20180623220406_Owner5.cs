using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Migrations
{
    public partial class Owner5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_IdentityUser_OwnerId",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_Article_ArticleId",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Article_ArticleId",
                table: "Section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Article",
                table: "Article");

            migrationBuilder.RenameTable(
                name: "Article",
                newName: "Articles");

            migrationBuilder.RenameIndex(
                name: "IX_Article_OwnerId",
                table: "Articles",
                newName: "IX_Articles_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articles",
                table: "Articles",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_IdentityUser_OwnerId",
                table: "Articles",
                column: "OwnerId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Articles_ArticleId",
                table: "Group",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Articles_ArticleId",
                table: "Section",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_IdentityUser_OwnerId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_Articles_ArticleId",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Articles_ArticleId",
                table: "Section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articles",
                table: "Articles");

            migrationBuilder.RenameTable(
                name: "Articles",
                newName: "Article");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_OwnerId",
                table: "Article",
                newName: "IX_Article_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Article",
                table: "Article",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_IdentityUser_OwnerId",
                table: "Article",
                column: "OwnerId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Article_ArticleId",
                table: "Group",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Article_ArticleId",
                table: "Section",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
