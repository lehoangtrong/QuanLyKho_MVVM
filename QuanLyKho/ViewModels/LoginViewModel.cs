using QuanLyKho.Models;
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
    public class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; } = false;
        private string _userName;
        public string UserName { get => _userName; set { _userName = value; OnPropertyChanged(); } }
        private string _password;
        public string Password { get => _password; set { _password = value; OnPropertyChanged(); } }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Login(p);
            });

            PasswordChangeCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                if (p == null) return;
                Password = p.Password;
            });

            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null) return;
                p.Close();
            });
        }

        void Login(Window p)
        {
            if (p == null) return;
            QuanLyKhoKteamContext quanLyKho = new QuanLyKhoKteamContext();
            string passwordEndcode = Md5Encode(Base64Encode(Password)).ToLower();
            var user = quanLyKho.Users.FirstOrDefault(x => x.UserName == UserName);
            if (user == null)
            {
                MessageBox.Show("Tài khoản không tồn tại");
                return;
            }
            if (user.Password != passwordEndcode)
            {
                MessageBox.Show("Sai mật khẩu");
                return;
            }

            IsLogin = true;
            p.Close();
        }

        // string to base64 encoding
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        // base64 to md5 encoding
        public static string Md5Encode(string base64Text)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(base64Text);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
