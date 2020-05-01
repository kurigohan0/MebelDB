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
                    }));
            }

        }

    }
}
