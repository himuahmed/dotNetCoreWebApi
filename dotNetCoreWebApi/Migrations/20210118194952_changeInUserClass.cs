using Microsoft.EntityFrameworkCore.Migrations;

namespace dotNetCoreWebApi.Migrations
{
    public partial class changeInUserClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KnownAs",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KnownAs",
                table: "Users");
        }
    }
}
