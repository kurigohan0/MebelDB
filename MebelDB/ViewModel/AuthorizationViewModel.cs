using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MebelDB.API;

namespace MebelDB.ViewModel
{
    class AuthorizationViewModel : BaseViewModel
    {
        Window w;
        public AuthorizationViewModel(Window w)
        {
            this.w = w;
        }

        private RelayCommand authorizationCommand;

        public RelayCommand AuthorizationCommand 
        {   
            get 
            {
                return authorizationCommand ??
                    (authorizationCommand = new RelayCommand(obj =>
                    {
                        switch(Model.Authorization.Auth(login, password))
                        {
                            case Model.Authorization.Role.Manager:
                                View.NavWindow navWindow = new View.NavWindow();
                                navWindow.Show();
                                w.Close();
                                break;
                            case Model.Authorization.Role.None:
                                MessageBox.Show("Не правильный логин или пароль");
                                break;
                        }
                    }));
            }

        }

        private RelayCommand registrationCommand;

        public RelayCommand RegistrationCommand
        {
            get
            {
                return registrationCommand ??
                    (registrationCommand = new RelayCommand(obj =>
                    {
                        View.RegistrationWindow regWin = new View.RegistrationWindow();
                        regWin.Show();

                    }));
            }

        }

        private string login;
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
    }
}
