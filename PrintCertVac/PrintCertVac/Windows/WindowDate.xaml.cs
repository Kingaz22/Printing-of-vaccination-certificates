using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PrintCertVac.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class WindowDate : Window
    {
        public DateTime Date { get; set; }
        public DateTime Date2 { get; set; }

        public WindowDate()
        {
            InitializeComponent();

            DatePic1.SelectedDate = DateTime.Now;
            DatePic2.SelectedDate = DateTime.Now;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            Date = DatePic1.SelectedDate.Value.Date;
            Date2 = DatePic2.SelectedDate.Value.Date;
            this.DialogResult = true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DatePic1.SelectedDate = DatePic1.SelectedDate.Value.AddDays(-1);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DatePic1.SelectedDate = DatePic1.SelectedDate.Value.AddDays(1);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DatePic2.SelectedDate = DatePic2.SelectedDate.Value.AddDays(-1);
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DatePic2.SelectedDate = DatePic2.SelectedDate.Value.AddDays(1);
        }
    }
}
