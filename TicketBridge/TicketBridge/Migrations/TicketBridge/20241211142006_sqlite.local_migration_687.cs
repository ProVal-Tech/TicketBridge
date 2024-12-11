using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketBridge.Migrations.TicketBridge {
    /// <inheritdoc />
    public partial class sqlitelocal_migration_687 : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "GitHubIntegrations",
                columns: table => new {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Properties = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_GitHubIntegrations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "GitHubIntegrations");
        }
    }
}
