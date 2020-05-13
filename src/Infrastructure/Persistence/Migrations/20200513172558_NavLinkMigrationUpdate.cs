using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Persistence.Migrations
{
    public partial class NavLinkMigrationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "UiAppSettingNavLinkSections",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "UiAppSettingNavLinkSections",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "UiAppSettingNavLinkSections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "UiAppSettingNavLinkSections",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "UiAppSettingNavLinks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "UiAppSettingNavLinks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "UiAppSettingNavLinks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "UiAppSettingNavLinks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "UiAppSettingNavLinkSections");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UiAppSettingNavLinkSections");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "UiAppSettingNavLinkSections");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "UiAppSettingNavLinkSections");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "UiAppSettingNavLinks");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UiAppSettingNavLinks");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "UiAppSettingNavLinks");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "UiAppSettingNavLinks");
        }
    }
}
