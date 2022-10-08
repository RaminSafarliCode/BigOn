using Microsoft.EntityFrameworkCore.Migrations;

namespace BigOn.Domain.Migrations
{
    public partial class @base : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnswerDate",
                table: "ProductTypes",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "AnswerDate",
                table: "ProductSizes",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "AnswerDate",
                table: "Products",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "AnswerDate",
                table: "ProductMaterials",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "AnswerDate",
                table: "ProductImages",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "AnswerDate",
                table: "ProductColors",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "AnswerDate",
                table: "ProductCatalog",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "AnswerDate",
                table: "Faqs",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "AnswerDate",
                table: "ContactPosts",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "AnswerDate",
                table: "Categories",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "AnswerDate",
                table: "Brands",
                newName: "DeletedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "ProductTypes",
                newName: "AnswerDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "ProductSizes",
                newName: "AnswerDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Products",
                newName: "AnswerDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "ProductMaterials",
                newName: "AnswerDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "ProductImages",
                newName: "AnswerDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "ProductColors",
                newName: "AnswerDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "ProductCatalog",
                newName: "AnswerDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Faqs",
                newName: "AnswerDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "ContactPosts",
                newName: "AnswerDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Categories",
                newName: "AnswerDate");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Brands",
                newName: "AnswerDate");
        }
    }
}
