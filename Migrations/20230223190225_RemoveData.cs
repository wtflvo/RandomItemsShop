using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandomItemsShop.Migrations
{
    public partial class RemoveData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
               migrationBuilder.DeleteData(
                table: "ShopTable",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
               table: "usersTable",
               keyColumn: "email",
               keyValue: "Bar@rt");



        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "ShopTable",
               columns: new[] { "id", "title", "price", "description", "category", "image", "count" },
                values: new object[] { 21, "Foo", 21.44, "Foo", "Foo", "Foo", 21 });

            migrationBuilder.InsertData(
                table: "usersTable",
                columns: new[] { "name", "email", "password" },
                values: new object[] { "Foo", "Bar@rt", "Foo" });

        }
    }
}

