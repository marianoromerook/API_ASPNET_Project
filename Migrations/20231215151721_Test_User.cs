using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_RESTful_Project.Migrations
{
    /// <inheritdoc />
    public partial class Test_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreConnections");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StoreConnections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShopifyApiKey = table.Column<string>(type: "text", nullable: false),
                    ShopifyApiSecret = table.Column<string>(type: "text", nullable: false),
                    ShopifyUrl = table.Column<string>(type: "text", nullable: false),
                    WooCommerceConsumerKey = table.Column<string>(type: "text", nullable: false),
                    WooCommerceConsumerSecret = table.Column<string>(type: "text", nullable: false),
                    WooCommerceUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreConnections", x => x.Id);
                });
        }
    }
}
