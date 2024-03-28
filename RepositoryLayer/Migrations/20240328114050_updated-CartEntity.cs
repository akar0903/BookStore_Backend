using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class updatedCartEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Book_BookId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_UserTable_User_Id",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_BookId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_User_Id",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Cart");

            migrationBuilder.AddColumn<int>(
                name: "Book_Id",
                table: "Cart",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Cart",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Book_Id",
                table: "Cart",
                column: "Book_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Id",
                table: "Cart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Book_Book_Id",
                table: "Cart",
                column: "Book_Id",
                principalTable: "Book",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_UserTable_Id",
                table: "Cart",
                column: "Id",
                principalTable: "UserTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Book_Book_Id",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_UserTable_Id",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_Book_Id",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_Id",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "Book_Id",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cart");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Cart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Cart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_BookId",
                table: "Cart",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_User_Id",
                table: "Cart",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Book_BookId",
                table: "Cart",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_UserTable_User_Id",
                table: "Cart",
                column: "User_Id",
                principalTable: "UserTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
