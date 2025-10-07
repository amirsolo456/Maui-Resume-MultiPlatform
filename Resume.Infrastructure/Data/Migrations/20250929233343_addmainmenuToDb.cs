using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addmainmenuToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ForeignId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainMenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TargetPage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    ImageSource = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    MenuGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainMenus_MainMenus_ParentId",
                        column: x => x.ParentId,
                        principalTable: "MainMenus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MainMenus_MenuGroups_MenuGroupId",
                        column: x => x.MenuGroupId,
                        principalTable: "MenuGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainMenus_MenuItemType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "MenuItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainMenus_MenuGroupId",
                table: "MainMenus",
                column: "MenuGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MainMenus_ParentId",
                table: "MainMenus",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_MainMenus_TypeId",
                table: "MainMenus",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainMenus");

            migrationBuilder.DropTable(
                name: "MenuGroups");

            migrationBuilder.DropTable(
                name: "MenuItemType");
        }
    }
}
