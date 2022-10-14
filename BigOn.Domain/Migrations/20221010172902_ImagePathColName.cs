using Microsoft.EntityFrameworkCore.Migrations;

namespace BigOn.Domain.Migrations
{
    public partial class ImagePathColName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "BlogPosts",
                newName: "ImagePath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "BlogPosts",
                newName: "Image");
        }
    }
}
