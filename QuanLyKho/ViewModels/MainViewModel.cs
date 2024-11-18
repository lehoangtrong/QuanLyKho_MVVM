using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyKho.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public bool IsLoaded { get; set; }
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand UnitCommand { get; set; }
        public ICommand SuplierCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand ObjectCommand { get; set; }
        public ICommand UserCommand { get; set; }
        public ICommand InputCommand { get; set; }
        public ICommand OutputCommand { get; set; }

        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
            {
                IsLoaded = true;
                LoginWindow login = new LoginWindow();
                login.ShowDialog();
            });

            UnitCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                UnitWindow unitWindow = new UnitWindow();
                unitWindow.ShowDialog();
            });

            SuplierCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SuplierWindow suplierWindow = new SuplierWindow();
                suplierWindow.ShowDialog();
            });

            CustomerCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CustomerWindow customerWindow = new CustomerWindow();
                customerWindow.ShowDialog();
            });

            ObjectCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ObjectWindow objectWindow = new ObjectWindow();
                objectWindow.ShowDialog();
            });

            UserCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                UserWindow userWindow = new UserWindow();
                userWindow.ShowDialog();
            });

            InputCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                InputWindow inputWindow = new InputWindow();
                inputWindow.ShowDialog();
            });

            OutputCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                OutputWindow outputWindow = new OutputWindow();
                outputWindow.ShowDialog();
            });
        }
    }
}
