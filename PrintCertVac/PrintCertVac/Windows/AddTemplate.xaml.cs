using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for AddTemplate.xaml
    /// </summary>
    public partial class AddTemplate : ThemedWindow
    {
        public string nameTemplate { get; set; }
        public AddTemplate(string str)
        {
            InitializeComponent();
            txt.Text = str;
        }

        public AddTemplate()
        {
            InitializeComponent();
        }

        private void SimpleButton_Click(object sender, RoutedEventArgs e)
        {
            nameTemplate = txt.Text;
            this.DialogResult = true;
        }
    }
}
