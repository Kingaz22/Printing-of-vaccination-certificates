using Microsoft.EntityFrameworkCore.Migrations;

namespace PrintCertVac.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<string>(type: "TEXT", nullable: true),
                    DateRecord = table.Column<string>(type: "TEXT", nullable: true),
                    User_FamilyNameRus = table.Column<string>(type: "TEXT", nullable: true),
                    User_FamilyNameEng = table.Column<string>(type: "TEXT", nullable: true),
                    User_NameRus = table.Column<string>(type: "TEXT", nullable: true),
                    User_NameEng = table.Column<string>(type: "TEXT", nullable: true),
                    User_Patronymic = table.Column<string>(type: "TEXT", nullable: true),
                    User_DateOfBirth = table.Column<string>(type: "TEXT", nullable: true),
                    User_Passport = table.Column<string>(type: "TEXT", nullable: true),
                    User_IdentNumber = table.Column<string>(type: "TEXT", nullable: true),
                    User_FontSize_FamilyName = table.Column<string>(type: "TEXT", nullable: true),
                    User_FontSize_Name = table.Column<string>(type: "TEXT", nullable: true),
                    User_FontSize_Patronymic = table.Column<string>(type: "TEXT", nullable: true),
                    User_FontSize_DateOfBirth = table.Column<string>(type: "TEXT", nullable: true),
                    User_FontSize_Passport = table.Column<string>(type: "TEXT", nullable: true),
                    User_FontSize_IdentNumber = table.Column<string>(type: "TEXT", nullable: true),
                    User_FontSize_Id = table.Column<int>(type: "INTEGER", nullable: true),
                    User_Margin_FamilyName = table.Column<string>(type: "TEXT", nullable: true),
                    User_Margin_Name = table.Column<string>(type: "TEXT", nullable: true),
                    User_Margin_Patronymic = table.Column<string>(type: "TEXT", nullable: true),
                    User_Margin_DateOfBirth = table.Column<string>(type: "TEXT", nullable: true),
                    User_Margin_Passport = table.Column<string>(type: "TEXT", nullable: true),
                    User_Margin_IdentNumber = table.Column<string>(type: "TEXT", nullable: true),
                    User_Margin_Id = table.Column<int>(type: "INTEGER", nullable: true),
                    User_Id = table.Column<int>(type: "INTEGER", nullable: true),
                    DateOfVaccination_Date = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfVaccination_Id = table.Column<int>(type: "INTEGER", nullable: true),
                    DateOfVaccination_FontSize = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfVaccination_Margin = table.Column<string>(type: "TEXT", nullable: true),
                    Vaccine_NameVacRus = table.Column<string>(type: "TEXT", nullable: true),
                    Vaccine_NameVacEng = table.Column<string>(type: "TEXT", nullable: true),
                    Vaccine_Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Vaccine_FontSize = table.Column<string>(type: "TEXT", nullable: true),
                    Vaccine_Margin = table.Column<string>(type: "TEXT", nullable: true),
                    PartVac = table.Column<string>(type: "TEXT", nullable: true),
                    Doctor_Name = table.Column<string>(type: "TEXT", nullable: true),
                    Doctor_Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Doctor_FontSize = table.Column<string>(type: "TEXT", nullable: true),
                    Doctor_Margin = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfVaccination2_Date = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfVaccination2_Id = table.Column<int>(type: "INTEGER", nullable: true),
                    DateOfVaccination2_FontSize = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfVaccination2_Margin = table.Column<string>(type: "TEXT", nullable: true),
                    Vaccine2_NameVacRus = table.Column<string>(type: "TEXT", nullable: true),
                    Vaccine2_NameVacEng = table.Column<string>(type: "TEXT", nullable: true),
                    Vaccine2_Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Vaccine2_FontSize = table.Column<string>(type: "TEXT", nullable: true),
                    Vaccine2_Margin = table.Column<string>(type: "TEXT", nullable: true),
                    PartVac2 = table.Column<string>(type: "TEXT", nullable: true),
                    Doctor2_Name = table.Column<string>(type: "TEXT", nullable: true),
                    Doctor2_Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Doctor2_FontSize = table.Column<string>(type: "TEXT", nullable: true),
                    Doctor2_Margin = table.Column<string>(type: "TEXT", nullable: true),
                    FirsPage_NameOrgRus = table.Column<string>(type: "TEXT", nullable: true),
                    FirsPage_NameOrgEng = table.Column<string>(type: "TEXT", nullable: true),
                    FirsPage_NameOrgRusFontSize = table.Column<string>(type: "TEXT", nullable: true),
                    FirsPage_NameOrgEngFontSize = table.Column<string>(type: "TEXT", nullable: true),
                    FirsPage_QrCodeSize = table.Column<string>(type: "TEXT", nullable: true),
                    FirsPage_NameOrgRusMargin = table.Column<string>(type: "TEXT", nullable: true),
                    FirsPage_NameOrgEngMargin = table.Column<string>(type: "TEXT", nullable: true),
                    FirsPage_QrCodeMargin = table.Column<string>(type: "TEXT", nullable: true),
                    FirsPage_Id = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemplateCerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameTemplate = table.Column<string>(type: "TEXT", nullable: true),
                    UserMargin_FamilyName = table.Column<string>(type: "TEXT", nullable: true),
                    UserMargin_Name = table.Column<string>(type: "TEXT", nullable: true),
                    UserMargin_Patronymic = table.Column<string>(type: "TEXT", nullable: true),
                    UserMargin_DateOfBirth = table.Column<string>(type: "TEXT", nullable: true),
                    UserMargin_Passport = table.Column<string>(type: "TEXT", nullable: true),
                    UserMargin_IdentNumber = table.Column<string>(type: "TEXT", nullable: true),
                    UserMargin_Id = table.Column<int>(type: "INTEGER", nullable: true),
                    UserFontSize_FamilyName = table.Column<string>(type: "TEXT", nullable: true),
                    UserFontSize_Name = table.Column<string>(type: "TEXT", nullable: true),
                    UserFontSize_Patronymic = table.Column<string>(type: "TEXT", nullable: true),
                    UserFontSize_DateOfBirth = table.Column<string>(type: "TEXT", nullable: true),
                    UserFontSize_Passport = table.Column<string>(type: "TEXT", nullable: true),
                    UserFontSize_IdentNumber = table.Column<string>(type: "TEXT", nullable: true),
                    UserFontSize_Id = table.Column<int>(type: "INTEGER", nullable: true),
                    DateOfVaccinationMargin = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfVaccinationFontSize = table.Column<string>(type: "TEXT", nullable: true),
                    Vaccine_NameVacRus = table.Column<string>(type: "TEXT", nullable: true),
                    Vaccine_NameVacEng = table.Column<string>(type: "TEXT", nullable: true),
                    Vaccine_Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Vaccine_FontSize = table.Column<string>(type: "TEXT", nullable: true),
                    Vaccine_Margin = table.Column<string>(type: "TEXT", nullable: true),
                    Doctor_Name = table.Column<string>(type: "TEXT", nullable: true),
                    Doctor_Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Doctor_FontSize = table.Column<string>(type: "TEXT", nullable: true),
                    Doctor_Margin = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfVaccination2Margin = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfVaccination2FontSize = table.Column<string>(type: "TEXT", nullable: true),
                    Vaccine2_NameVacRus = table.Column<string>(type: "TEXT", nullable: true),
                    Vaccine2_NameVacEng = table.Column<string>(type: "TEXT", nullable: true),
                    Vaccine2_Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Vaccine2_FontSize = table.Column<string>(type: "TEXT", nullable: true),
                    Vaccine2_Margin = table.Column<string>(type: "TEXT", nullable: true),
                    Doctor2_Name = table.Column<string>(type: "TEXT", nullable: true),
                    Doctor2_Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Doctor2_FontSize = table.Column<string>(type: "TEXT", nullable: true),
                    Doctor2_Margin = table.Column<string>(type: "TEXT", nullable: true),
                    FirsPage_NameOrgRus = table.Column<string>(type: "TEXT", nullable: true),
                    FirsPage_NameOrgEng = table.Column<string>(type: "TEXT", nullable: true),
                    FirsPage_NameOrgRusFontSize = table.Column<string>(type: "TEXT", nullable: true),
                    FirsPage_NameOrgEngFontSize = table.Column<string>(type: "TEXT", nullable: true),
                    FirsPage_QrCodeSize = table.Column<string>(type: "TEXT", nullable: true),
                    FirsPage_NameOrgRusMargin = table.Column<string>(type: "TEXT", nullable: true),
                    FirsPage_NameOrgEngMargin = table.Column<string>(type: "TEXT", nullable: true),
                    FirsPage_QrCodeMargin = table.Column<string>(type: "TEXT", nullable: true),
                    FirsPage_Id = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateCerts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "TemplateCerts");
        }
    }
}
