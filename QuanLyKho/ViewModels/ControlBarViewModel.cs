using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyKho.ViewModels
{
    public class ControlBarViewModel : BaseViewModel
    {
        #region
        public ICommand CloseWindow { get; set; }
        public ICommand MaximizeWindow { get; set; }
        public ICommand MinimizeWindow { get; set; }
        public ICommand MouseLeftButtonDown { get; set; }
        #endregion

        public ControlBarViewModel()
        {
            CloseWindow = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = GetWindowParent(p);
                var w = window as Window;
                if (w != null)
                {
                    w.Close();
                }
            });

            MaximizeWindow = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = GetWindowParent(p);
                var w = window as Window;
                if (w != null)
                {
                    if (w.WindowState == WindowState.Maximized)
                        w.WindowState = WindowState.Normal;
                    else
                        w.WindowState = WindowState.Maximized;
                }
            });

            MinimizeWindow = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = GetWindowParent(p);
                var w = window as Window;
                if (w != null)
                {
                    w.WindowState = WindowState.Minimized;
                }
            });

            MouseLeftButtonDown = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = GetWindowParent(p);
                var w = window as Window;

                if (w != null)
                {
                    w.DragMove();
                }
            });
        }

        FrameworkElement GetWindowParent(UserControl p)
        {
            FrameworkElement element = p.Parent as FrameworkElement;

            while (element.Parent != null)
            {
                element = element.Parent as FrameworkElement;
            }

            return element;
        }
    }
}
