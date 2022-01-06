using System.Diagnostics;
using System.Windows;

namespace PrintCertVac.Windows
{
    /// <summary>
    /// Логика взаимодействия для AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            if (version is not null)
                TextBlock.Text = version.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var sInfo = new ProcessStartInfo($"https://www.linkedin.com/in/kingaz22/")
            {
                UseShellExecute = true,
            };
            Process.Start(sInfo);
        }
    }
}
