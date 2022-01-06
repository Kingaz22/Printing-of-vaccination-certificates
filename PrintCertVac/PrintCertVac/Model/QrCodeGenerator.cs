using System;
using PrintCertVac.Model;
using QRCoder;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace PrintCertVac.Model
{
    public static class QrCodeGenerator
    {

        public static BitmapImage RunQrCode(Certificate certificate, string nameOrg, DateTime datePrint)
        {
            //{Имя} {Фамилия} {Дата рождения} {Номер паспорта} 
            //{Дата 1 вакцинации} {Наименование 1 вакцины} {Номер партии 1 вакцины} 
            //{Дата 2 вакцинации} {Наименование 2 вакцины} {Номер партии 2 вакцины} {Дата печати сертификата}

            certificate.DateOfVaccination2.Date ??= " ";
            certificate.PartVac2 ??= " ";

            nameOrg = nameOrg.Replace("{Имя}", certificate.User.NameEng)
                .Replace("{Фамилия}", certificate.User.FamilyNameEng)
                .Replace("{Дата рождения}", certificate.User.DateOfBirth)
                .Replace("{Номер паспорта}", certificate.User.Passport)
                .Replace("{Дата 1 вакцинации}", certificate.DateOfVaccination.Date)
                .Replace("{Наименование 1 вакцины}", certificate.Vaccine.NameVacEng.Trim())
                .Replace("{Номер партии 1 вакцины}", certificate.PartVac.Trim())
                .Replace("{Дата 2 вакцинации}", certificate.DateOfVaccination2.Date.Trim())
                .Replace("{Наименование 2 вакцины}", certificate.Vaccine2.NameVacEng.Trim())
                .Replace("{Номер партии 2 вакцины}", certificate.PartVac2.Trim())
                .Replace("{Дата печати сертификата}", datePrint.ToShortDateString());

            QRCodeGenerator qrGenerator = new();          
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(nameOrg, QRCodeGenerator.ECCLevel.L);
            QRCode qrCode = new(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(7);

            return BitmapToImageSource(qrCodeImage);
        }

        static BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using MemoryStream memory = new();
            bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
            memory.Position = 0;
            BitmapImage bitmapimage = new();
            bitmapimage.BeginInit();
            bitmapimage.StreamSource = memory;
            bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapimage.EndInit();

            return bitmapimage;
        }
    }
}
