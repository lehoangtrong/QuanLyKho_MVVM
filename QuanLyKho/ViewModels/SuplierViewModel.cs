using QuanLyKho.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyKho.ViewModels
{
    public class SuplierViewModel : BaseViewModel
    {
        private ObservableCollection<Suplier> _List;
        public ObservableCollection<Suplier> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private Suplier _selectedItem;
        public Suplier SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                    Phone = SelectedItem.Phone;
                    Email = SelectedItem.Email;
                    Address = SelectedItem.Address;
                    MoreInfo = SelectedItem.MoreInfo;
                    ContractDate = SelectedItem.ContractDate;
                }
            }
        }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }


        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }


        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }


        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }


        private string _MoreInfo;
        public string MoreInfo { get => _MoreInfo; set { _MoreInfo = value; OnPropertyChanged(); } }


        private DateTime? _ContractDate;
        public DateTime? ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }


        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        private QuanLyKhoKteamContext kteamContext;

        public SuplierViewModel()
        {
            kteamContext = new QuanLyKhoKteamContext();
            List = new ObservableCollection<Suplier>(kteamContext.Supliers);

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName))
                    return false;
                if (kteamContext.Supliers.Any(x => x.DisplayName == DisplayName))
                    return false;
                return true;

            }, (p) =>
            {
                Suplier suplier = new Suplier()
                {
                    DisplayName = DisplayName,
                    Phone = Phone,
                    Email = Email,
                    Address = Address,
                    MoreInfo = MoreInfo,
                    ContractDate = ContractDate
                };

                kteamContext.Supliers.Add(suplier);
                kteamContext.SaveChanges();

                List.Add(suplier);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName))
                    return false;
                if (SelectedItem == null)
                    return false;
                if (kteamContext.Supliers.Any(x => x.DisplayName == DisplayName && x.Id != SelectedItem.Id))
                    return false;
                return true;
            }, (p) =>
            {
                var suplier = kteamContext.Supliers.Find(SelectedItem.Id);
                if (suplier == null) return;

                suplier.DisplayName = DisplayName;
                suplier.Phone = Phone;
                suplier.Email = Email;
                suplier.Address = Address;
                suplier.MoreInfo = MoreInfo;
                suplier.ContractDate = ContractDate;

                kteamContext.SaveChanges();

                SelectedItem = suplier;
            });
        }
    }
}
