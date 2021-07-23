using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopBridge_InventoryManagement.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "Description", "Name", "Price" },
                values: new object[] { 1L, "Developer", "John", 30000m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "Description", "Name", "Price" },
                values: new object[] { 2L, "Manager", "Chris", 50000m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "Description", "Name", "Price" },
                values: new object[] { 3L, "Consultant", "Mukesh", 20000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 3L);
        }
    }
}
