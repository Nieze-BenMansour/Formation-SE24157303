using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formation.SE24157303.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTwoColunsClientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientType",
                table: "ClientDbset",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdentifiantNationale",
                table: "ClientDbset",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientType",
                table: "ClientDbset");

            migrationBuilder.DropColumn(
                name: "IdentifiantNationale",
                table: "ClientDbset");
        }
    }
}
