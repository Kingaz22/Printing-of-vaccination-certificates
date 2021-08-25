using Microsoft.Win32;
using PrintCertVac.EntityFramework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows;
using System.Windows.Data;
using System.Diagnostics;
using System.Windows.Controls;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using PrintCertVac.Windows;
using DevExpress.Xpf.Core;

namespace PrintCertVac.Model
{
    public static class Func
    {
        public static Certificate PastUser(Certificate certificate)
        {
            var a = Clipboard.GetText().Split(new char[] { '\t' });
            if (a.Length >= 1)
            {
                var b = a[0].Trim().Split(new char[] { ' ' });
                if (b.Length >= 3)
                {
                    certificate.User.FamilyNameRus = b[0];
                    certificate.User.NameRus = b[1];
                    certificate.User.Patronymic = b[2];
                }
            }

            if (a.Length >= 4 && DateTime.TryParse(a[3].Trim(), out _))
            {
                certificate.User.DateOfBirth = a[3].Trim();
            }

            if (a.Length >= 5)
            {
                var c = a[4].Trim();
                if (c.Length == 14)
                {
                    certificate.User.IdentNumber = c;
                }
            }

            return certificate;
        }

        public static Certificate PastVac(Certificate certificate)
        {
            string str1 = "", str2 = "", str3 = "", str4 = "";

            var a = Clipboard.GetText().Split(new char[] { '\t', '\r', '\n' }).Where(x => x != "").ToList();

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i].IndexOf("Вакцинация 1") != -1)
                {
                    str1 = a[i - 1];
                    str2 = a[i + 3];
                }

                if (a[i].IndexOf("Вакцинация 2") != -1)
                {
                    if (i + 3 > a.Count)
                    {
                        continue;
                    }
                    str3 = a[i - 1];
                    str4 = a[i + 3];
                }
            }
            certificate.DateOfVaccination.Date = str1;
            certificate.DateOfVaccination2.Date = str3;
            certificate.PartVac = str2;
            certificate.PartVac2 = str4;
            return certificate;
        }

        public static string ChekErrors(Certificate certificate)
        {
            string errors = "";

            if (!string.IsNullOrEmpty(certificate.User.Passport) && certificate.User.Passport.Length != 9)
            {
                errors = $"{errors}Не верная длина номера паспорта\n";
            }

            if (!string.IsNullOrEmpty(certificate.User.IdentNumber) && certificate.User.IdentNumber.Length != 14)
            {
                errors = $"{errors}Не верная длина ЛН\n";
            }
            else
            {
                if (!string.IsNullOrEmpty(certificate.User.DateOfBirth) && !string.IsNullOrEmpty(certificate.User.IdentNumber) && certificate.User.DateOfBirth.Remove(5, 3).Remove(2, 1) != certificate.User.IdentNumber.Substring(1, 6))
                {
                    errors = $"{errors}Дата рорждения не совпадает с ЛН\n";
                }
            }

            if (!string.IsNullOrEmpty(certificate.DateOfVaccination.Date) && !string.IsNullOrEmpty(certificate.DateOfVaccination2.Date) && DateTime.Parse(certificate.DateOfVaccination.Date) >= DateTime.Parse(certificate.DateOfVaccination2.Date))
            {
                errors = $"{errors}Дата первой вакцинации больше или равна второй\n";
            }

            return errors;
        }

        public static IEnumerable<Report> ReportsUpdate()
        {
            var records = GenericDataService<Record>.GetAll();
            int total = 0;
            var ListCertificate = GenericDataService<Certificate>.GetAll().GroupBy(x => x.Date)
                .Select(g => new Report()
                { 
                    DateTime = g.Key, 
                    Sale = g.Count(), 
                    Incoming = records.FirstOrDefault(x => x.Date == g.Key) == null ? 0 : records.FirstOrDefault(x => x.Date == g.Key).Incoming,
                    Spoiled = records.FirstOrDefault(x => x.Date == g.Key) == null ? 0 : records.FirstOrDefault(x => x.Date == g.Key).Spoiled
                }).OrderBy(x => x.DateTime).ToList();   

            foreach (var item in ListCertificate)
            {
                total = total + item.Incoming - item.Sale - item.Spoiled;
                item.Total = total;
            }

            return ListCertificate;
        }

        public static bool SaveTemplate(Certificate certificate, TemplateCert templateCert)
        {
            var result = DXMessageBox.Show(
                caption: "Сохранение шаблона",
                messageBoxText: "Сохранить шаблон как новый?",
                button: MessageBoxButton.YesNoCancel,
                icon: MessageBoxImage.Exclamation);

            if (result == MessageBoxResult.Yes)
            {
                AddTemplate addTemplate = new();
                if (addTemplate.ShowDialog() == true)
                {

                    templateCert.NameTemplate = addTemplate.nameTemplate;
                    templateCert.DateOfVaccinationFontSize = certificate.DateOfVaccination.FontSize;
                    templateCert.DateOfVaccinationMargin = certificate.DateOfVaccination.Margin;
                    templateCert.DateOfVaccination2FontSize = certificate.DateOfVaccination2.FontSize;
                    templateCert.DateOfVaccination2Margin = certificate.DateOfVaccination2.Margin;
                    templateCert.Doctor = certificate.Doctor;
                    templateCert.Doctor2 = certificate.Doctor2;
                    templateCert.FirstPage = certificate.FirstPage;
                    templateCert.Vaccine = certificate.Vaccine;
                    templateCert.Vaccine2 = certificate.Vaccine2;

                    templateCert.UserFontSize = certificate.User.FontSize;
                    templateCert.UserMargin = certificate.User.Margin;

                    templateCert.Id = new int();
                    GenericDataService<TemplateCert>.Create(templateCert);
                    return true;
                }
            }
            else if (result == MessageBoxResult.No)
            {
                AddTemplate addTemplate = new(templateCert.NameTemplate);
                if (addTemplate.ShowDialog() == true)
                {
                    templateCert.NameTemplate = addTemplate.nameTemplate;
                    templateCert.DateOfVaccinationFontSize = certificate.DateOfVaccination.FontSize;
                    templateCert.DateOfVaccinationMargin = certificate.DateOfVaccination.Margin;
                    templateCert.DateOfVaccination2FontSize = certificate.DateOfVaccination2.FontSize;
                    templateCert.DateOfVaccination2Margin = certificate.DateOfVaccination2.Margin;
                    templateCert.Doctor = certificate.Doctor;
                    templateCert.Doctor2 = certificate.Doctor2;
                    templateCert.FirstPage = certificate.FirstPage;
                    templateCert.Vaccine = certificate.Vaccine;
                    templateCert.Vaccine2 = certificate.Vaccine2;

                    templateCert.UserFontSize = certificate.User.FontSize;
                    templateCert.UserMargin = certificate.User.Margin;
                    GenericDataService<TemplateCert>.Edit(templateCert);
                    return false;
                }
            }

            return false;
        }

        public static void ExportCertificate(IEnumerable<Certificate> listCertificate)
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "Json file (*.json)|*.json"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                var fileName = saveFileDialog.FileName;

                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };

                using StreamWriter sw = new(fileName);
                var asd = JsonSerializer.Serialize(listCertificate, options);
                sw.WriteLine(asd);
            }
        }

        public static IEnumerable<Certificate> ImportCertificate()
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Json file (*.json)|*.json|All files |*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                var fileName = openFileDialog.FileName;
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };

                string jsonString = File.ReadAllText(fileName);
                var list = JsonSerializer.Deserialize<IEnumerable<Certificate>>(jsonString, options);

                return GenericDataService<Certificate>.AddAll(list);
            }

            return GenericDataService<Certificate>.GetAll();
        }

        public static void FirstTemplateCert()
        {
            TemplateCert tmp = new()
            {
                NameTemplate = "Стандартный шаблон",
                UserMargin =
                {
                    FamilyName = "1cm, 4.2cm, 0, 0",
                    Name = "1cm, 6cm, 0, 0",
                    Patronymic = "1cm, 7.8cm, 0, 0",
                    DateOfBirth = "1cm, 9.9cm, 0, 0",
                    Passport = "1cm, 11.7cm, 0, 0",
                    IdentNumber = "1cm, 13.5cm, 0, 0"
                },
                UserFontSize =
                {
                    FamilyName = "24",
                    Name = "24",
                    Patronymic = "24",
                    DateOfBirth = "24",
                    Passport = "24",
                    IdentNumber = "24"
                },
                DateOfVaccinationMargin = "11cm, 6.4cm, 0, 0",
                DateOfVaccinationFontSize = "24",
                DateOfVaccination2Margin = "11cm, 14.9cm, 0, 0",
                DateOfVaccination2FontSize = "24",
                Vaccine =
                {
                    NameVacRus = "Гам-КОВИД-Вак, Россия",
                    NameVacEng = "Gam-COVID-Vac, Russian",
                    Margin = "11cm, 7.9cm, 0, 0",
                    FontSize = "13"
                },
                Vaccine2 =
                {
                    NameVacRus = "Гам-КОВИД-Вак, Россия",
                    NameVacEng = "Gam-COVID-Vac, Russian",
                    Margin = "11cm, 16.5cm, 0, 0",
                    FontSize = "13"
                },
                Doctor =
                {
                    Name = "",
                    FontSize = "14",
                    Margin = "11cm, 9.5cm, 0, 0"
                },
                Doctor2 =
                {
                    Name = "",
                    FontSize = "14",
                    Margin = "11cm, 18.1cm, 0, 0"
                },
                FirstPage =
                {
                    NameOrgRus = "Учреждение ",
                    NameOrgRusFontSize = "11",
                    NameOrgRusMargin = "10.8cm, 7cm, 0, 0",
                    NameOrgEng = "State",
                    NameOrgEngFontSize = "11",
                    NameOrgEngMargin = "10.8cm, 8cm, 0, 0",
                    QrCodeMargin = "10.1cm, 0.4cm, 0, 0",
                    QrCodeSize = "100"
                }
            };
            GenericDataService<TemplateCert>.Create(tmp);
        }

        public static void PrintStatement(IEnumerable<Certificate> listCertificate)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            FileInfo fileInf = new("Statement.xlsx");
            fileInf.CopyTo("PrintStatement.xlsx", true);

            using (var package = new ExcelPackage(new FileInfo("PrintStatement.xlsx")))
            {
                var sheet = package.Workbook.Worksheets[0];

                var i = 3;

                foreach (var item in listCertificate)
                {
                    sheet.Cells[i, 1].Value = item.ContractNumber;
                    sheet.Cells[i, 2].Value = item.Date;
                    sheet.Cells[i, 2].Style.Numberformat.Format = "dd.mm.yyyy";
                    sheet.Cells[i, 3].Value = item.User.FamilyNameRus + " " + item.User.NameRus + " " + item.User.Patronymic;
                    sheet.Cells[i, 4].Value = item.User.DateOfBirth;
                    sheet.Cells[i, 5].Value = item.User.Passport;
                    sheet.Cells[i, 6].Value = item.User.IdentNumber;
                    i++;
                }
                sheet.Cells[3, 1, i, 8].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                sheet.Cells[3, 1, i, 8].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                sheet.Cells[3, 1, i, 8].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                sheet.Cells[3, 1, i, 8].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                sheet.PrinterSettings.PrintArea = sheet.Cells[1, 1, i, 8];

                package.Save();
            }
            _ = Process.Start(new ProcessStartInfo("PrintStatement.xlsx") { UseShellExecute = true });
        }

        public static Setting SettingApp()
        {
            if (!GenericDataService<Setting>.GetAll().Any())
            {
                GenericDataService<Setting>.Create(new Setting()
                {
                    NameCharacterCasing = false,
                    FullNameCharacterCasing = false,
                    NumberCharacterCasing = false,
                    NumberIdCharacterCasing = false,
                    NumberCheck = false,
                    TemplateQrCode = "Учреждение;\r\n" +
                                     "Statement;\r\n" +
                                     "{Фамилия} {Имя} {Дата рождения} {Номер паспорта};\r\n" +
                                     "1-{Дата 1 вакцинации} {Наименование 1 вакцины} {Номер партии 1 вакцины};\r\n" +
                                     "2-{Дата 2 вакцинации} {Наименование 2 вакцины} {Номер партии 2 вакцины};\r\n" +
                                     "{Дата печати сертификата}"
                });
            }

            return GenericDataService<Setting>.GetAll().First();
        }

    }

    public class BooleanConverter<T> : IValueConverter
    {
        public BooleanConverter(T trueValue, T falseValue)
        {
            True = trueValue;
            False = falseValue;
        }

        public T True { get; set; }
        public T False { get; set; }

        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is true ? True : False;
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is T t && EqualityComparer<T>.Default.Equals(t, True);
        }
    }

    public class UpperConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is true ? CharacterCasing.Upper : CharacterCasing.Normal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }


}
