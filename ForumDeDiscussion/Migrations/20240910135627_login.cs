using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumDeDiscussion.Migrations
{
    public partial class login : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_messages_Membre_MembreId",
                table: "messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Membre",
                table: "Membre");

            migrationBuilder.RenameTable(
                name: "Membre",
                newName: "membre");

            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "membre",
                newName: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_membre",
                table: "membre",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_messages_membre_MembreId",
                table: "messages",
                column: "MembreId",
                principalTable: "membre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_messages_membre_MembreId",
                table: "messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_membre",
                table: "membre");

            migrationBuilder.RenameTable(
                name: "membre",
                newName: "Membre");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Membre",
                newName: "Mail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Membre",
                table: "Membre",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_messages_Membre_MembreId",
                table: "messages",
                column: "MembreId",
                principalTable: "Membre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
