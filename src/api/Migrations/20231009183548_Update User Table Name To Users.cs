using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserTableNameToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_User_UsersId",
                table: "RoleUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Sanctions_User_SecretaryId",
                table: "Sanctions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sanctions_User_StudentId",
                table: "Sanctions");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_ParentId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_User_PersonalId",
                table: "Users",
                newName: "IX_Users_PersonalId");

            migrationBuilder.RenameIndex(
                name: "IX_User_ParentId",
                table: "Users",
                newName: "IX_Users_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Email",
                table: "Users",
                newName: "IX_Users_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Users_UsersId",
                table: "RoleUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sanctions_Users_SecretaryId",
                table: "Sanctions",
                column: "SecretaryId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sanctions_Users_StudentId",
                table: "Sanctions",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_ParentId",
                table: "Users",
                column: "ParentId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Users_UsersId",
                table: "RoleUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Sanctions_Users_SecretaryId",
                table: "Sanctions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sanctions_Users_StudentId",
                table: "Sanctions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_ParentId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Users_PersonalId",
                table: "User",
                newName: "IX_User_PersonalId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ParentId",
                table: "User",
                newName: "IX_User_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                table: "User",
                newName: "IX_User_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_User_UsersId",
                table: "RoleUser",
                column: "UsersId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sanctions_User_SecretaryId",
                table: "Sanctions",
                column: "SecretaryId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sanctions_User_StudentId",
                table: "Sanctions",
                column: "StudentId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_ParentId",
                table: "User",
                column: "ParentId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
