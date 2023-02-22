using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update17022023v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Breeds_BreedForeingKey",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_BreedForeingKey",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "BreedForeingKey",
                table: "Pets");

            migrationBuilder.AddColumn<Guid>(
                name: "BreedId",
                table: "Pets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_BreedId",
                table: "Pets",
                column: "BreedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Breeds_BreedId",
                table: "Pets",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Breeds_BreedId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_BreedId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "BreedId",
                table: "Pets");

            migrationBuilder.AddColumn<Guid>(
                name: "BreedForeingKey",
                table: "Pets",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Pets_BreedForeingKey",
                table: "Pets",
                column: "BreedForeingKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Breeds_BreedForeingKey",
                table: "Pets",
                column: "BreedForeingKey",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
