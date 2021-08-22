using Microsoft.EntityFrameworkCore.Migrations;

namespace PrintCertVac.Migrations
{
    public partial class AddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameCharacterCasing = table.Column<bool>(type: "INTEGER", nullable: false),
                    FullNameCharacterCasing = table.Column<bool>(type: "INTEGER", nullable: false),
                    NumberCharacterCasing = table.Column<bool>(type: "INTEGER", nullable: false),
                    NumberIdCharacterCasing = table.Column<bool>(type: "INTEGER", nullable: false),
                    NumberCheck = table.Column<bool>(type: "INTEGER", nullable: false),
                    TemplateQrCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
