using QuanLyKho.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyKho.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<TonKho> _tonKhoList;
        public ObservableCollection<TonKho> TonKhoList { get => _tonKhoList; set { _tonKhoList = value; OnPropertyChanged(); } }
        public bool IsLoaded
        { get; set; }
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
                if (p == null)
                    return;
                p.Hide();
                LoginWindow login = new LoginWindow();
                login.ShowDialog();
                if (login.DataContext == null)
                {
                    p.Close();
                    return;
                }

                var loginVM = login.DataContext as LoginViewModel;
                if (loginVM == null)
                    return;
                if (loginVM.IsLogin)
                {
                    p.Show();
                    LoadTonKhoData();
                }
                else
                    p.Close();
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

        void LoadTonKhoData()
        {
            TonKhoList = new ObservableCollection<TonKho>();

            QuanLyKhoKteamContext quanLyKho = new QuanLyKhoKteamContext();
            var objectList = quanLyKho.Objects.ToList();
            int id = 0;
            foreach (var item in objectList)
            {
                var inputList = quanLyKho.InputInfos.Where(p => p.IdObject == item.Id).ToList();
                var outputList = quanLyKho.OutputInfos.Where(p => p.IdObject == item.Id).ToList();

                int countInput = 0;
                int countOutput = 0;
                if (inputList != null) countInput = (int)inputList.Sum(p => p.Count);
                if (outputList != null) countOutput = (int)outputList.Sum(p => p.Count);
                TonKho tonkho = new TonKho();
                tonkho.Object = item;
                tonkho.STT = id++;
                tonkho.Count = countInput - countOutput;

                TonKhoList.Add(tonkho);
            }
        }
    }
}
