using QuanLyKho.ViewModels;
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

namespace QuanLyKho
{
    /// <summary>
    /// Interaction logic for SuplierWindow.xaml
    /// </summary>
    public partial class SuplierWindow : Window
    {
        public SuplierViewModel SuplierViewModel { get; set; }
        public SuplierWindow()
        {
            InitializeComponent();
            this.DataContext = SuplierViewModel = new SuplierViewModel();
        }
    }
}
