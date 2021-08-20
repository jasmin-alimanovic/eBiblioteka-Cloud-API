using Microsoft.EntityFrameworkCore.Migrations;

namespace eBibliotekaCloud.Migrations
{
    public partial class AddedisDeletedfieldinBookclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Knjiga",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Knjiga");
        }
    }
}
