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
        TabControl tabs;

        private List<ushort> tabindex = new List<ushort>();

        public NavViewModel(Window w, TabControl tabs, Frame f = null)
        {
            this.w = w;
            this.f = f;
            this.tabs = tabs;

            tipMsg = Model.CurrentUser.User.Name + ", выберите вкладку для начала работы. ";

            for (int i = 0; i < 10; i++)
            {
                tabindex.Add(0);
                
            }
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
                        tabindex[1] += 1;

                        tabs.Items.Add(new TabItem
                        {

                            Header = new TextBlock { Text = $"Создание заказа [{tabindex[1]}]" },

                            Content = new Frame().Content = new View.CreateOrderPage()

                        });
                        


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
                        tabindex[5] += 1;

                        tabs.Items.Add(new TabItem
                        {

                            Header = new TextBlock { Text = $"Учет фурнитуры и материалов [{tabindex[5]}]" },

                            Content = new Frame().Content = new View.MFControlPage()

                        });



                        //f.Content = new View.CreateOrderPage();
                        //f.Navigate(new View.CreateOrderPage());
                    }));
            }

        }

        private RelayCommand closeTab;

        public RelayCommand CloseTab
        {
            get
            {
                return closeTab ??
                    (closeTab = new RelayCommand(obj =>
                    {
                        if(tabs.SelectedIndex != -1)
                            tabs.Items.RemoveAt(tabs.SelectedIndex);

                        //f.Navigate(new View.EquipmentPage());
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
                        tabindex[4] += 1;
                        tabs.Items.Add(new TabItem
                        {

                            Header = new TextBlock { Text = $"Учет оборудования  [{tabindex[4]}]" },

                            Content = new Frame().Content = new View.EquipmentPage()

                        });

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
                        tabindex[0] += 1;
                        tabs.Items.Add(new TabItem
                        {

                            Header = new TextBlock { Text = $"Все заказы [{tabindex[0]}]" },

                            Content = new Frame().Content = new View.AllOrdersPage()

                        });

                        //f.Navigate(new View.AllOrdersPage());
                    }));
            }

        }

    }
}
