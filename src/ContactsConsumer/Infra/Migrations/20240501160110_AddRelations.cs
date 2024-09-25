using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DDDId",
                table: "Contacts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_DDDId",
                table: "Contacts",
                column: "DDDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_DDDs_DDDId",
                table: "Contacts",
                column: "DDDId",
                principalTable: "DDDs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_DDDs_DDDId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_DDDId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "DDDId",
                table: "Contacts");
        }
    }
}
