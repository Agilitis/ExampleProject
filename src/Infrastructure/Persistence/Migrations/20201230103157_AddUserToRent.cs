using Microsoft.EntityFrameworkCore.Migrations;

namespace ExampleProject.Infrastructure.Persistence.Migrations
{
    public partial class AddUserToRent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Rents",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Rents");
        }
    }
}
