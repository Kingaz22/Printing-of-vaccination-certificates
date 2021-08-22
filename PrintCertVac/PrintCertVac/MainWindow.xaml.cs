using DevExpress.Xpf.Core;
using PrintCertVac.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PrintCertVac
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new PcvViewModel();
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var i = ((TextBox) sender).SelectionStart;
            ((TextBox) sender).Text = ((TextBox) sender).Text.Replace(",", ".");
            ((TextBox) sender).SelectionStart = i;
        }

        
	}
}
