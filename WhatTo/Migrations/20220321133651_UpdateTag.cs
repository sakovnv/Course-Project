using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class UpdateTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewsCount",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Tags",
                table: "Tag",
                newName: "Item");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Item",
                table: "Tag",
                newName: "Tags");

            migrationBuilder.AddColumn<int>(
                name: "ReviewsCount",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
