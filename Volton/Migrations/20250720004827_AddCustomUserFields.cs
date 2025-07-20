using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Volton.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomUserFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "AgreedSupplyPower",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AppartmentInterestType",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AppartmentIsCustomer",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BusinessInterestType",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomeCounterType",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomeInterestType",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomeIsCustomer",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomeSecondPower",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SelectedPlanId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "warentyInfo",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgreedSupplyPower",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppartmentInterestType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppartmentIsCustomer",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BusinessInterestType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HomeCounterType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HomeInterestType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HomeIsCustomer",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HomeSecondPower",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SelectedPlanId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "warentyInfo",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgreedSupplyPower = table.Column<int>(type: "int", nullable: false),
                    AppartmentInterestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppartmentIsCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessInterestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnergySelection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnergySelectionId = table.Column<int>(type: "int", nullable: false),
                    HomeCounterType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeInterestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeIsCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeSecondPower = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    Preference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedPackage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedPlan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedPlanId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    warentyInfo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }
    }
}
