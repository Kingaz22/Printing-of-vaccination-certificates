using Microsoft.EntityFrameworkCore.Migrations;

namespace PrintCertVac.Migrations
{
    public partial class AddCFieldContractNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContractNumber",
                table: "Certificates",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractNumber",
                table: "Certificates");
        }
    }
}
