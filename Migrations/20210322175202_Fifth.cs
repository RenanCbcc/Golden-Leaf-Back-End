using Microsoft.EntityFrameworkCore.Migrations;

namespace Golden_Leaf_Back_End.Migrations
{
    public partial class Fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClerkId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClerkId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clerks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clerks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ClerkId",
                table: "Payments",
                column: "ClerkId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClerkId",
                table: "Orders",
                column: "ClerkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clerks_ClerkId",
                table: "Orders",
                column: "ClerkId",
                principalTable: "Clerks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Clerks_ClerkId",
                table: "Payments",
                column: "ClerkId",
                principalTable: "Clerks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clerks_ClerkId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Clerks_ClerkId",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "Clerks");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ClerkId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ClerkId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ClerkId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ClerkId",
                table: "Orders");
        }
    }
}
