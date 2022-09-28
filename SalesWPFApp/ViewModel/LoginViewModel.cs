using BusinessObject;
using SalesWPFApp.Ultility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SalesWPFApp.ViewModel
{
    public class LoginViewModel
    {
        public ICommand LoginCommand { get; set; }

        public WindowLogin windowLogin;

        public LoginViewModel(WindowLogin window)
        {
            this.windowLogin = window;

            LoginCommand = new RelayCommand<Credential>(
                (c) => true, // CanExecute()
                (c) => processLogin(c) // Execute()
            );
        }

        private void processLogin(Credential c)
        {
            if(c.Email.Equals("admin@fstore.com") && c.Password.Equals("admin@@"))
            {
                MainWindow mainWindow = new MainWindow();
                windowLogin.Close();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("You are not an admin");
            }
        }
    }
}
