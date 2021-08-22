using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using System.Windows;

namespace PrintCertVac
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var splashScreenViewModel = new DXSplashScreenViewModel()
            {
                Title = "Сертификаты о вакцинации\nпротив COVID-19",
                Copyright = "Copyright © 2021 Zubronov A.A.",
                Status = "Загрузка..."

            };
            SplashScreenManager.Create(() => new FluentSplashScreen1(), splashScreenViewModel).ShowOnStartup();
        }
    }


}
