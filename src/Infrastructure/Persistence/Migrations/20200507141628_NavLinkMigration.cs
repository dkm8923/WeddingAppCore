using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Persistence.Migrations
{
    public partial class NavLinkMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UiAppSettingHeaders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UiAppSettingHeaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UiAppSettingNavLinks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<long>(nullable: false),
                    NavLinkSectionId = table.Column<long>(nullable: true),
                    Text = table.Column<string>(nullable: false),
                    FontAwesomeCss = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: false),
                    BadgeText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UiAppSettingNavLinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UiAppSettingNavLinkSections",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<long>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    FontAwesomeCss = table.Column<string>(nullable: true),
                    BadgeText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UiAppSettingNavLinkSections", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UiAppSettingHeaders");

            migrationBuilder.DropTable(
                name: "UiAppSettingNavLinks");

            migrationBuilder.DropTable(
                name: "UiAppSettingNavLinkSections");
        }
    }
}
