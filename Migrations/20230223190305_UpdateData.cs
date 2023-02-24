using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandomItemsShop.Migrations
{
    public partial class UpdateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
     migrationBuilder.UpdateData(
    table: "usersTable",
    keyColumn: "email",
    keyValue: "foo",
    column: "name",
    value: "Oleg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
   table: "usersTable",
   keyColumn: "email",
   keyValue: "foo",
   column: "name",
   value: "Igor");
        }
    }
}
