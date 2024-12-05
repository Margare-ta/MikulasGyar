using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MikulasGyar.Migrations
{
    /// <inheritdoc />
    public partial class DbInitUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toys_Kids_KidId",
                table: "Toys");

            migrationBuilder.DropIndex(
                name: "IX_Toys_KidId",
                table: "Toys");

            migrationBuilder.DropColumn(
                name: "KidId",
                table: "Toys");

            migrationBuilder.CreateTable(
                name: "KidToy",
                columns: table => new
                {
                    KidsId = table.Column<int>(type: "int", nullable: false),
                    ToysId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KidToy", x => new { x.KidsId, x.ToysId });
                    table.ForeignKey(
                        name: "FK_KidToy_Kids_KidsId",
                        column: x => x.KidsId,
                        principalTable: "Kids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KidToy_Toys_ToysId",
                        column: x => x.ToysId,
                        principalTable: "Toys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_KidToy_ToysId",
                table: "KidToy",
                column: "ToysId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KidToy");

            migrationBuilder.AddColumn<int>(
                name: "KidId",
                table: "Toys",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Toys_KidId",
                table: "Toys",
                column: "KidId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toys_Kids_KidId",
                table: "Toys",
                column: "KidId",
                principalTable: "Kids",
                principalColumn: "Id");
        }
    }
}
