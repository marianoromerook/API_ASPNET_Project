using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_RESTful_Project.Migrations
{
    /// <inheritdoc />
    public partial class test_user_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "UserNetworks",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserNetworks",
                table: "UserNetworks",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserNetworks",
                table: "UserNetworks");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserNetworks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
