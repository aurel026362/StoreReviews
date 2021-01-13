using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreReivew.Infrastracture.Migrations
{
    public partial class ChangeAdressToAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Shops",
                newName: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Shops",
                newName: "Adress");
        }
    }
}
