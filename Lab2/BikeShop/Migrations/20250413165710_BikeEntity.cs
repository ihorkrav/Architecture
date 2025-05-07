using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeShop.Migrations
{
    /// <inheritdoc />
    public partial class BikeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_BikeId",
                table: "Orders",
                column: "BikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Bikes_BikeId",
                table: "Orders",
                column: "BikeId",
                principalTable: "Bikes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Bikes_BikeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BikeId",
                table: "Orders");
        }
    }
}
