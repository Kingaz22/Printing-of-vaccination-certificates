using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;
using Microsoft.Win32;
using PrintCertVac.EntityFramework;
using PrintCertVac.Model;
using PrintCertVac.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Xpf;
using DevExpress.Mvvm;
using System;
using System.IO;

namespace PrintCertVac.ViewModel
{
    [POCOViewModel]
    public class PcvViewModel : ViewModelBase
    {
        private BitmapImage _imageSource;

        public BitmapImage ImageSource
        {
            get => _imageSource;
            set
            {
                _imageSource = value;
                RaisePropertyChanged(() => ImageSource);
            }
        }

       

        private IEnumerable<Certificate> _listCertificate;
        public IEnumerable<Certificate> ListCertificate
        {
            get => _listCertificate;
            set
            {
                _listCertificate = value;
                RaisePropertyChanged(() => ListCertificate);
            }
        }

        private IEnumerable<TemplateCert> _templateCertList;
        public IEnumerable<TemplateCert> TemplateCertList
        {
            get => _templateCertList;
            set
            {
                _templateCertList = value;
                RaisePropertyChanged(() => TemplateCertList);
            }
        }

        private TemplateCert _templateCert;
        public TemplateCert TemplateCert
        {
            get => _templateCert;
            set
            {
                _templateCert = value;
                if (value is not null)
                {
                    Certificate.User.Margin = TemplateCert.UserMargin;
                    Certificate.User.FontSize = TemplateCert.UserFontSize;
                    Certificate.Vaccine = TemplateCert.Vaccine;
                    Certificate.Vaccine2 = TemplateCert.Vaccine2;
                    Certificate.Doctor = TemplateCert.Doctor;
                    Certificate.Doctor2 = TemplateCert.Doctor2;
                    Certificate.DateOfVaccination.Margin = TemplateCert.DateOfVaccinationMargin;
                    Certificate.DateOfVaccination.FontSize = TemplateCert.DateOfVaccinationFontSize;
                    Certificate.DateOfVaccination2.Margin = TemplateCert.DateOfVaccination2Margin;
                    Certificate.DateOfVaccination2.FontSize = TemplateCert.DateOfVaccination2FontSize;
                    Certificate.FirstPage = TemplateCert.FirstPage;
                }
                RaisePropertyChanged(() => TemplateCert);
            }
        }

        private Setting _settingApp;
        public Setting SettingApp
        {
            get => _settingApp;
            set
            {
                _settingApp = value;
                RaisePropertyChanged(() => SettingApp);
            }
        }

        private Certificate _certificate;
        public Certificate Certificate
        {
            get
            {
                NameVacRusEngPart = $"{_certificate.Vaccine.NameVacRus}{_certificate.PartVac}{_certificate.Vaccine.NameVacEng}{_certificate.PartVac}";
                NameVacRusEngPart2 = $"{_certificate.Vaccine2.NameVacRus}{_certificate.PartVac2}{_certificate.Vaccine2.NameVacEng}{_certificate.PartVac2}";
                FamilyName = $"{_certificate.User.FamilyNameRus} / {_certificate.User.FamilyNameEng}";
                NameFull = $"{_certificate.User.NameRus} / {_certificate.User.NameEng}";
                return _certificate;
            }
            set
            {
                _certificate = value;
                RaisePropertyChanged(() => Certificate);
            }
        }

        private string _nameVacRusEngPart;
        private string _nameVacRusEngPart2;
        private string _familyName;
        private string _nameFull;

        public string NameVacRusEngPart
        {
            get => _nameVacRusEngPart;
            set
            {
                _nameVacRusEngPart = value;
                RaisePropertyChanged(() => NameVacRusEngPart);
            }
        }
        public string NameVacRusEngPart2
        {
            get => _nameVacRusEngPart2;
            set
            {
                _nameVacRusEngPart2 = value;
                RaisePropertyChanged(() => NameVacRusEngPart2);
            }
        }
        public string FamilyName
        {
            get => _familyName;
            set
            {
                _familyName = value;
                RaisePropertyChanged(() => FamilyName);
            }
        }
        public string NameFull
        {
            get => _nameFull;
            set
            {
                _nameFull = value;
                RaisePropertyChanged(() => NameFull);
            }
        }

        private string _visibility;
        public string Visibility
        {
            get => _visibility;
            set
            {
                _visibility = value;
                RaisePropertyChanged(() => Visibility);
            }
        }

        private IEnumerable<Report> _reports;
        public IEnumerable<Report> Reports
        {
            get => _reports;
            set
            {
                _reports = value;
                RaisePropertyChanged(() => Reports);
            }
        }

        private IEnumerable<Record> _records;
        public IEnumerable<Record> Records
        {
            get => _records;
            set
            {
                _records = value;
                RaisePropertyChanged(() => Records);
            }
        }

        private string _selectedIndex;
        public string SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;
                RaisePropertyChanged(() => SelectedIndex);
            }
        }

        private DateTime _datePrint;
        public DateTime DatePrint
        {
            get => _datePrint;
            set
            {
                _datePrint = value;
                RaisePropertyChanged(() => DatePrint);
            }
        }

        public PcvViewModel()
        {
            SelectedIndex = "0";

            SettingApp = Func.SettingApp();

            Certificate = new Certificate();
            Visibility = "Collapsed";
            ListCertificate = GenericDataService<Certificate>.GetAll();
            TemplateCertList = GenericDataService<TemplateCert>.GetAll().ToList();

            if (!TemplateCertList.Any())
            {
                Func.FirstTemplateCert();
                TemplateCertList = GenericDataService<TemplateCert>.GetAll();
            }
            TemplateCert = TemplateCertList.First();

            Records = GenericDataService<Record>.GetAll();
            Reports = Func.ReportsUpdate();
            DatePrint = DateTime.Now;
        }

        [Command]
        public void RefreshTemplate()
        {
            if (TemplateCert is not null)
            {
                Certificate.User.Margin = TemplateCert.UserMargin;
                Certificate.User.FontSize = TemplateCert.UserFontSize;
                Certificate.Vaccine = TemplateCert.Vaccine;
                Certificate.Vaccine2 = TemplateCert.Vaccine2;
                Certificate.Doctor = TemplateCert.Doctor;
                Certificate.Doctor2 = TemplateCert.Doctor2;
                Certificate.DateOfVaccination.Margin = TemplateCert.DateOfVaccinationMargin;
                Certificate.DateOfVaccination.FontSize = TemplateCert.DateOfVaccinationFontSize;
                Certificate.DateOfVaccination2.Margin = TemplateCert.DateOfVaccination2Margin;
                Certificate.DateOfVaccination2.FontSize = TemplateCert.DateOfVaccination2FontSize;
                Certificate.FirstPage = TemplateCert.FirstPage;
            }
        }

        [Command]
        public void RowUpdatedDate(RowUpdatedArgs args)
        {
            if (args.Item is Record)
            {
                GenericDataService<Record>.Edit(args.Item as Record);
            }

            if (args.Item is Certificate)
            {
                GenericDataService<Certificate>.Edit(args.Item as Certificate);
            }
        }

        [Command]
        public void Setting()
        {
            Visibility = (Visibility == "Visible") ? "Collapsed" : "Visible";
        }

        [Command]
        public void SaveSettingApp()
        {
            GenericDataService<Setting>.Edit(SettingApp);
        }

        [Command]
        public void Statistic()
        {
            Reports = Func.ReportsUpdate();
        }

        [Command]
        public void DeleteRecords(Record record)
        {
            GenericDataService<Record>.Delete(record);
            Records = GenericDataService<Record>.GetAll();
        }

        [Command]
        public void ContentPaste()
        {
            Certificate = Func.PastUser(Certificate);
        }

        [Command]
        public void ContentPasteVac()
        {
            Certificate = Func.PastVac(Certificate);
        }

        [Command]
        public void CommandSetting()
        {
            Visibility = (Visibility == "Visible") ? "Collapsed" : "Visible";
        }

        [Command]
        public void SaveTemplate()
        {
            if (Func.SaveTemplate(Certificate, TemplateCert))
            {
                TemplateCertList = GenericDataService<TemplateCert>.GetAll();
                TemplateCert = TemplateCertList.Last();
            }
            else
            {
                var temp = TemplateCert.Id;
                TemplateCertList = GenericDataService<TemplateCert>.GetAll();
                TemplateCert = TemplateCertList.First(x => x.Id == temp);
            }
        }

        [Command]
        public void SaveClient()
        {
            if (Certificate.Date == DateTime.Parse("01.01.0001"))
            {
                if (ListCertificate.Any(x => x.ContractNumber == Certificate.ContractNumber) && DXMessageBox.Show(
                    caption: "Ошибка",
                    messageBoxText: "Такой номер договора уже существует.\nПродолжить сохранение?",
                    button: MessageBoxButton.YesNo,
                    icon: MessageBoxImage.Exclamation) == MessageBoxResult.No)
                {
                    return;
                }

                AddClient addClient = new();
                if (addClient.ShowDialog() == true)
                {
                    Certificate.Date = addClient.Date;
                    Certificate.DateRecord = addClient.Date2;
                    GenericDataService<Certificate>.Create(Certificate);
                    ListCertificate = GenericDataService<Certificate>.GetAll();
                    Certificate = new(TemplateCert);
                    SelectedIndex = "0";
                }
            }
            else
            {
                AddClient addClient = new(Certificate.Date, Certificate.DateRecord);
                if (addClient.ShowDialog() == true)
                {
                    Certificate.Date = addClient.Date;
                    Certificate.DateRecord = addClient.Date2;
                    GenericDataService<Certificate>.Create(Certificate);
                    ListCertificate = GenericDataService<Certificate>.GetAll();
                    Certificate = new(TemplateCert);
                    SelectedIndex = "0";
                }
            }
        }

        [Command]
        public void PrintSt()
        {
            WindowDate windowDate = new();
            if (windowDate.ShowDialog() == true)
            {
                Func.PrintStatement(ListCertificate.Where(x => x.DateRecord >= windowDate.Date && x.DateRecord <= windowDate.Date2).OrderBy(x => x.ContractNumber));
            }
        }

        [Command]
        public void Clear()
        {
            Certificate = new(TemplateCert);
            SelectedIndex = "0";
        }

        [Command]
        public void LoadClient(Certificate args)
        {
            Certificate = args;
            SelectedIndex = "0";
        }

        [Command]
        public void CopyClient(Certificate args)
        {
            Certificate = new(TemplateCert);
            Certificate.User = args.User;
            RefreshTemplate();
            SelectedIndex = "0";
        }

        [Command]
        public void DeleteTemplate(TemplateCert args)
        {
            if (args is not null)
            {
                GenericDataService<TemplateCert>.Delete(args);
                TemplateCertList = GenericDataService<TemplateCert>.GetAll();
            }
        }

        [Command]
        public void DeleteCertificate(GridControl args)
        {
            foreach (var item in args.SelectedItems)
            {
                GenericDataService<Certificate>.Delete(item as Certificate);
            }
            ListCertificate = GenericDataService<Certificate>.GetAll();
        }

        [Command]
        public void ChekCertificate()
        {
            string error = Func.ChekErrors(Certificate);
            DXMessageBox.Show(caption: "Ошибки", messageBoxText: error == "" ? "Ошибок нет" : error, button: MessageBoxButton.OKCancel, icon: MessageBoxImage.Exclamation);
        }

        [Command]
        public void ExportCertificate()
        {
            Func.ExportCertificate(ListCertificate);
        }

        [Command]
        public void ImportCertificate()
        {
            ListCertificate = Func.ImportCertificate();
        }

        [Command]
        public void CopyFio(Certificate args)
        {
            Clipboard.SetText(args is null
                ? $"{Certificate.User.FamilyNameRus} {Certificate.User.NameRus} {Certificate.User.Patronymic}"
                : $"{args.User.FamilyNameRus} {args.User.NameRus} {args.User.Patronymic}");
        }

        [Command]
        public void ExportCertificateExcel(GridControl args)
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "Excel file (*.xlsx)|*.xlsx"
            };
            if (saveFileDialog.ShowDialog() == true) args.View.ExportToXlsx(saveFileDialog.FileName);
        }

        [Command]
        public void About()
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }

        [Command]
        public void Print(Grid args)
        {
            if (args.Name == "print")
            {
                SelectedIndex = "1";
                ImageSource = QrCodeGenerator.RunQrCode(Certificate, SettingApp.TemplateQrCode, DatePrint);
            }

            if (args.Name == "print1")
            {
                SelectedIndex = "0";
            }

            var a = Func.ChekErrors(Certificate);

            if (!string.IsNullOrEmpty(a))
            {
                var result = DXMessageBox.Show(caption: "Ошибки", messageBoxText: $"В сертификате есть ошибки:\n{a}\n\nПродолжить печатать?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Exclamation);

                if (result == MessageBoxResult.No)
                {
                    return;
                }
            }

            PrintDialog printDialog = new();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(args, "invoice");
            }
        }
        

        private RelayCommand _qrCode;
        public RelayCommand QrCode => _qrCode ??= new RelayCommand((o) => ImageSource = QrCodeGenerator.RunQrCode(Certificate, SettingApp.TemplateQrCode, DatePrint));

        private RelayCommand _toTheLeft;
        public RelayCommand ToTheLeft
        {
            get
            {
                return _toTheLeft ??= new RelayCommand((o) =>
                {
                    ((StackPanel)o).Margin = new Thickness()
                    {
                        Left = ((StackPanel)o).Margin.Left - 1,
                        Top = ((StackPanel) o).Margin.Top,
                        Right = ((StackPanel) o).Margin.Right,
                        Bottom = ((StackPanel) o).Margin.Bottom
                    };

                });
            }
        }

        private RelayCommand _toTheRight;
        public RelayCommand ToTheRight
        {
            get
            {
                return _toTheRight ??= new RelayCommand((o) =>
                {
                    ((StackPanel) o).Margin = new Thickness()
                    {
                        Left = ((StackPanel) o).Margin.Left + 1,
                        Top = ((StackPanel) o).Margin.Top,
                        Right = ((StackPanel) o).Margin.Right,
                        Bottom = ((StackPanel) o).Margin.Bottom
                    };

                });
            }
        }

        private RelayCommand _up;
        public RelayCommand Up
        {
            get
            {
                return _up ??= new RelayCommand((o) =>
                {
                    ((StackPanel) o).Margin = new Thickness()
                    {
                        Left = ((StackPanel) o).Margin.Left,
                        Top = ((StackPanel) o).Margin.Top - 1,
                        Right = ((StackPanel) o).Margin.Right,
                        Bottom = ((StackPanel) o).Margin.Bottom
                    };

                });
            }
        }
        private RelayCommand _down;
        public RelayCommand Down
        {
            get
            {
                return _down ??= new RelayCommand((o) =>
                {
                    ((StackPanel) o).Margin = new Thickness()
                    {
                        Left = ((StackPanel) o).Margin.Left,
                        Top = ((StackPanel) o).Margin.Top + 1,
                        Right = ((StackPanel) o).Margin.Right,
                        Bottom = ((StackPanel) o).Margin.Bottom
                    };

                });
            }
        }

        private RelayCommand _upSize;
        public RelayCommand UpSize
        {
            get
            {
                return _upSize ??= new RelayCommand((o) =>
                {
                    if (((TextBlock) ((StackPanel) o).Children[0]).FontSize == 80) return;

                    ((o as StackPanel).Children[0] as TextBlock).FontSize = ((o as StackPanel).Children[0] as TextBlock).FontSize + 1; 
                });
            }
        }

        private RelayCommand _downSize;
        public RelayCommand DownSize
        {
            get
            {
                return _downSize ??= new RelayCommand((o) =>
                {                    
                    if (((o as StackPanel).Children[0] as TextBlock).FontSize == 3) return;                    

                    ((o as StackPanel).Children[0] as TextBlock).FontSize = ((o as StackPanel).Children[0] as TextBlock).FontSize - 1;
                });
            }
        }

        private RelayCommand _upSizeQrCode;
        public RelayCommand UpSizeQrCode
        {
            get
            {
                return _upSizeQrCode ??= new RelayCommand((o) =>
                {
                    if (((o as StackPanel).Children[0] as Image).Width == 300) return;

                    ((o as StackPanel).Children[0] as Image).Width = ((o as StackPanel).Children[0] as Image).Width + 5;
                });
            }
        }

        private RelayCommand _downSizeQrCode;
        public RelayCommand DownSizeQrCode
        {
            get
            {
                return _downSizeQrCode ??= new RelayCommand((o) =>
                {
                    if (((o as StackPanel).Children[0] as Image).Width == 10) return;

                    ((o as StackPanel).Children[0] as Image).Width = ((o as StackPanel).Children[0] as Image).Width - 5;
                });
            }
        }
    }
}
