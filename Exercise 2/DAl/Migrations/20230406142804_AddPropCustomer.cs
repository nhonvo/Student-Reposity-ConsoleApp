using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercise_2.Migrations
{
    /// <inheritdoc />
    public partial class AddPropCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Customers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Wallet",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Wallet",
                table: "Customers");
        }
    }
}
