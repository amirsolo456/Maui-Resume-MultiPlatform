using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainMenus_MenuItemType_TypeId",
                table: "MainMenus");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "MainMenus",
                newName: "MenuItemTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_MainMenus_TypeId",
                table: "MainMenus",
                newName: "IX_MainMenus_MenuItemTypeId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Persons",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Persons",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ForeignId",
                table: "MenuItemType",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTokens_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_PersonId",
                table: "UserTokens",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainMenus_MenuItemType_MenuItemTypeId",
                table: "MainMenus",
                column: "MenuItemTypeId",
                principalTable: "MenuItemType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainMenus_MenuItemType_MenuItemTypeId",
                table: "MainMenus");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "MenuItemTypeId",
                table: "MainMenus",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_MainMenus_MenuItemTypeId",
                table: "MainMenus",
                newName: "IX_MainMenus_TypeId");

            migrationBuilder.AlterColumn<string>(
                name: "ForeignId",
                table: "MenuItemType",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MainMenus_MenuItemType_TypeId",
                table: "MainMenus",
                column: "TypeId",
                principalTable: "MenuItemType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
