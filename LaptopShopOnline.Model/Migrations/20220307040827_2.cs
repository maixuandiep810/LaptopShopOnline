using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaptopShopOnline.Model.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_UserId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Order_BuyerId",
                table: "Order",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_BuyerId",
                table: "Order",
                column: "BuyerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_BuyerId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_BuyerId",
                table: "Order");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Order",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
