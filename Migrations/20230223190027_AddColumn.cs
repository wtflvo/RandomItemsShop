using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandomItemsShop.Migrations
{
    public partial class AddColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "hasPremium",
                table: "usersTable",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hasPremium",
                table: "usersTable");
        }
    }
}
