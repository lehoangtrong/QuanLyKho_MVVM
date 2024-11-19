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
    public class UnitViewModel : BaseViewModel
    {
        private ObservableCollection<Unit> _unitList;
        public ObservableCollection<Unit> UnitList { get => _unitList; set { _unitList = value; OnPropertyChanged(); } }

        private Unit _selectedItem;
        public Unit SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null) DisplayName = SelectedItem.DisplayName;
            }
        }

        private string _displayName;
        public string DisplayName
        {
            get => _displayName; set
            {
                _displayName = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        private QuanLyKhoKteamContext kteamContext;

        public UnitViewModel()
        {
            kteamContext = new QuanLyKhoKteamContext();
            UnitList = new ObservableCollection<Unit>(kteamContext.Units);

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName))
                    return false;
                if (kteamContext.Units.Any(x => x.DisplayName == DisplayName))
                    return false;
                return true;

            }, (p) =>
            {
                Unit unit = new Unit() { DisplayName = DisplayName };

                kteamContext.Units.Add(unit);
                kteamContext.SaveChanges();

                UnitList.Add(unit);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName))
                    return false;
                if (kteamContext.Units.Any(x => x.DisplayName == DisplayName))
                    return false;
                return true;
            }, (p) =>
            {
                var unit = kteamContext.Units.Find(SelectedItem.Id);
                unit.DisplayName = DisplayName;
                kteamContext.SaveChanges();

                SelectedItem.DisplayName = DisplayName;
            });
        }
    }
}