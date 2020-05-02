using MebelDB.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MebelDB.ViewModel
{
    class NavViewModel : BaseViewModel
    {
        Window w;
        Frame f;


        public NavViewModel(Window w, Frame f)
        {
            this.w = w;
            this.f = f;

            tipMsg = Model.CurrentUser.User.Name + ", выберите вкладку для начала работы. ";

        }

        private Page windowPage;

        public Page WindowPage
        {
            get
            {
                return windowPage;
            }
            set
            {
                windowPage = value;
            }
        }

        private RelayCommand createOrder;

        public RelayCommand CreateOrder
        {
            get
            {
                return createOrder ??
                    (createOrder = new RelayCommand(obj =>
                    {
                        f.Navigate(new View.CreateOrderPage());
                        


                        //f.Content = new View.CreateOrderPage();
                        //f.Navigate(new View.CreateOrderPage());
                    }));
            }

        }

        private RelayCommand mfcontrol;

        public RelayCommand MFControl
        {
            get
            {
                return mfcontrol ??
                    (mfcontrol = new RelayCommand(obj =>
                    {
                        f.Navigate(new View.MFControlPage());


                        //f.Content = new View.CreateOrderPage();
                        //f.Navigate(new View.CreateOrderPage());
                    }));
            }

        }

       

        private string tipMsg;
        public string TipMsg
        {
            get
            {
                return tipMsg;
            }
            
        }

        private RelayCommand allEquipment;

        public RelayCommand AllEquipment
        {
            get
            {
                return allEquipment ??
                    (allEquipment = new RelayCommand(obj =>
                    {
                        f.Navigate(new View.EquipmentPage());

                        //f.Navigate(new View.EquipmentPage());
                    }));
            }

        }

        private RelayCommand allOrders;

        public RelayCommand AllOrders
        {
            get
            {
                return allOrders ??
                    (allOrders = new RelayCommand(obj =>
                    {
                        f.Navigate(new View.AllOrdersPage());

                        //f.Navigate(new View.AllOrdersPage());
                    }));
            }

        }

    }
}
