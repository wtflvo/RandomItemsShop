using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandomItemsShop.Migrations
{
    public partial class DeleteColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "usersTable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<bool>(
                    name: "name",
                    table: "usersTable",
                    type: "varchar(128)",
                    nullable: false,
                    defaultValue: false);
        }

    }
}
