using MebelDB.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MebelDB.ViewModel
{
    class RegistrationViewModel : BaseViewModel
    {
        Window window;
        public RegistrationViewModel(Window window)
        {
            this.window = window;
        }

        private RelayCommand registrationCommand;

        public RelayCommand RegistrationCommand
        {
            get
            {
                return registrationCommand ??
                    (registrationCommand = new RelayCommand(obj =>
                    {
        




                        window.Close();
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

        private string firstname;
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        private string lastname;
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

        private string patronic;
        public string Patronic
        {
            get
            {
                return patronic;
            }
            set
            {
                patronic = value;
            }
        }

    
    }
}
