using Microsoft.EntityFrameworkCore.Migrations;

namespace ExampleProject.Infrastructure.Persistence.Migrations
{
    public partial class ManyToManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accessories_Cars_CarId",
                table: "Accessories");

            migrationBuilder.DropIndex(
                name: "IX_Accessories_CarId",
                table: "Accessories");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Accessories");

            migrationBuilder.CreateTable(
                name: "AccessoryCar",
                columns: table => new
                {
                    AccessoriesId = table.Column<int>(type: "int", nullable: false),
                    CarsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryCar", x => new { x.AccessoriesId, x.CarsId });
                    table.ForeignKey(
                        name: "FK_AccessoryCar_Accessories_AccessoriesId",
                        column: x => x.AccessoriesId,
                        principalTable: "Accessories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessoryCar_Cars_CarsId",
                        column: x => x.CarsId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessoryCar_CarsId",
                table: "AccessoryCar",
                column: "CarsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessoryCar");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Accessories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_CarId",
                table: "Accessories",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accessories_Cars_CarId",
                table: "Accessories",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
