using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndreTurismoApp.AddressService.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Complement",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Neighborhood",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Complement",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Neighborhood",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Address");
        }
    }
}
