using Microsoft.EntityFrameworkCore.Migrations;

namespace PrintCertVac.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirsPage_QrCodeSize",
                table: "TemplateCerts",
                newName: "FirstPage_QrCodeSize");

            migrationBuilder.RenameColumn(
                name: "FirsPage_QrCodeMargin",
                table: "TemplateCerts",
                newName: "FirstPage_QrCodeMargin");

            migrationBuilder.RenameColumn(
                name: "FirsPage_NameOrgRusMargin",
                table: "TemplateCerts",
                newName: "FirstPage_NameOrgRusMargin");

            migrationBuilder.RenameColumn(
                name: "FirsPage_NameOrgRusFontSize",
                table: "TemplateCerts",
                newName: "FirstPage_NameOrgRusFontSize");

            migrationBuilder.RenameColumn(
                name: "FirsPage_NameOrgRus",
                table: "TemplateCerts",
                newName: "FirstPage_NameOrgRus");

            migrationBuilder.RenameColumn(
                name: "FirsPage_NameOrgEngMargin",
                table: "TemplateCerts",
                newName: "FirstPage_NameOrgEngMargin");

            migrationBuilder.RenameColumn(
                name: "FirsPage_NameOrgEngFontSize",
                table: "TemplateCerts",
                newName: "FirstPage_NameOrgEngFontSize");

            migrationBuilder.RenameColumn(
                name: "FirsPage_NameOrgEng",
                table: "TemplateCerts",
                newName: "FirstPage_NameOrgEng");

            migrationBuilder.RenameColumn(
                name: "FirsPage_Id",
                table: "TemplateCerts",
                newName: "FirstPage_Id");

            migrationBuilder.RenameColumn(
                name: "FirsPage_QrCodeSize",
                table: "Certificates",
                newName: "FirstPage_QrCodeSize");

            migrationBuilder.RenameColumn(
                name: "FirsPage_QrCodeMargin",
                table: "Certificates",
                newName: "FirstPage_QrCodeMargin");

            migrationBuilder.RenameColumn(
                name: "FirsPage_NameOrgRusMargin",
                table: "Certificates",
                newName: "FirstPage_NameOrgRusMargin");

            migrationBuilder.RenameColumn(
                name: "FirsPage_NameOrgRusFontSize",
                table: "Certificates",
                newName: "FirstPage_NameOrgRusFontSize");

            migrationBuilder.RenameColumn(
                name: "FirsPage_NameOrgRus",
                table: "Certificates",
                newName: "FirstPage_NameOrgRus");

            migrationBuilder.RenameColumn(
                name: "FirsPage_NameOrgEngMargin",
                table: "Certificates",
                newName: "FirstPage_NameOrgEngMargin");

            migrationBuilder.RenameColumn(
                name: "FirsPage_NameOrgEngFontSize",
                table: "Certificates",
                newName: "FirstPage_NameOrgEngFontSize");

            migrationBuilder.RenameColumn(
                name: "FirsPage_NameOrgEng",
                table: "Certificates",
                newName: "FirstPage_NameOrgEng");

            migrationBuilder.RenameColumn(
                name: "FirsPage_Id",
                table: "Certificates",
                newName: "FirstPage_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstPage_QrCodeSize",
                table: "TemplateCerts",
                newName: "FirsPage_QrCodeSize");

            migrationBuilder.RenameColumn(
                name: "FirstPage_QrCodeMargin",
                table: "TemplateCerts",
                newName: "FirsPage_QrCodeMargin");

            migrationBuilder.RenameColumn(
                name: "FirstPage_NameOrgRusMargin",
                table: "TemplateCerts",
                newName: "FirsPage_NameOrgRusMargin");

            migrationBuilder.RenameColumn(
                name: "FirstPage_NameOrgRusFontSize",
                table: "TemplateCerts",
                newName: "FirsPage_NameOrgRusFontSize");

            migrationBuilder.RenameColumn(
                name: "FirstPage_NameOrgRus",
                table: "TemplateCerts",
                newName: "FirsPage_NameOrgRus");

            migrationBuilder.RenameColumn(
                name: "FirstPage_NameOrgEngMargin",
                table: "TemplateCerts",
                newName: "FirsPage_NameOrgEngMargin");

            migrationBuilder.RenameColumn(
                name: "FirstPage_NameOrgEngFontSize",
                table: "TemplateCerts",
                newName: "FirsPage_NameOrgEngFontSize");

            migrationBuilder.RenameColumn(
                name: "FirstPage_NameOrgEng",
                table: "TemplateCerts",
                newName: "FirsPage_NameOrgEng");

            migrationBuilder.RenameColumn(
                name: "FirstPage_Id",
                table: "TemplateCerts",
                newName: "FirsPage_Id");

            migrationBuilder.RenameColumn(
                name: "FirstPage_QrCodeSize",
                table: "Certificates",
                newName: "FirsPage_QrCodeSize");

            migrationBuilder.RenameColumn(
                name: "FirstPage_QrCodeMargin",
                table: "Certificates",
                newName: "FirsPage_QrCodeMargin");

            migrationBuilder.RenameColumn(
                name: "FirstPage_NameOrgRusMargin",
                table: "Certificates",
                newName: "FirsPage_NameOrgRusMargin");

            migrationBuilder.RenameColumn(
                name: "FirstPage_NameOrgRusFontSize",
                table: "Certificates",
                newName: "FirsPage_NameOrgRusFontSize");

            migrationBuilder.RenameColumn(
                name: "FirstPage_NameOrgRus",
                table: "Certificates",
                newName: "FirsPage_NameOrgRus");

            migrationBuilder.RenameColumn(
                name: "FirstPage_NameOrgEngMargin",
                table: "Certificates",
                newName: "FirsPage_NameOrgEngMargin");

            migrationBuilder.RenameColumn(
                name: "FirstPage_NameOrgEngFontSize",
                table: "Certificates",
                newName: "FirsPage_NameOrgEngFontSize");

            migrationBuilder.RenameColumn(
                name: "FirstPage_NameOrgEng",
                table: "Certificates",
                newName: "FirsPage_NameOrgEng");

            migrationBuilder.RenameColumn(
                name: "FirstPage_Id",
                table: "Certificates",
                newName: "FirsPage_Id");
        }
    }
}
