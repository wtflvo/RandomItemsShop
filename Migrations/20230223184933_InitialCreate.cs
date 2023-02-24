using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandomItemsShop.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShopTable",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(97)", unicode: false, maxLength: 97, nullable: false),
                    price = table.Column<decimal>(type: "numeric(6,2)", nullable: false),
                    description = table.Column<string>(type: "varchar(772)", unicode: false, maxLength: 772, nullable: false),
                    category = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    image = table.Column<string>(type: "varchar(71)", unicode: false, maxLength: 71, nullable: false),
                    count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usersTable",
                columns: table => new
                {
                    email = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    name = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    password = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_pk", x => x.email);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopTable");

            migrationBuilder.DropTable(
                name: "usersTable");
        }
    }
}
