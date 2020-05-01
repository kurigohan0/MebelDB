using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MebelDB.ViewModel
{
    class AllOrdersViewModel : BaseViewModel
    {
        public AllOrdersViewModel()
        {
            Load();
        }

        private void Load()
        {
            Model.MebelEntities mebelEntities = new Model.MebelEntities();

            foreach (var item in mebelEntities.Orders)
            {
                allOrders.Add(item);
                
            }
            OnPropertyChanged("AllOrders");
        }

        private ObservableCollection<Model.Orders> allOrders = new ObservableCollection<Model.Orders>();

        public ObservableCollection<Model.Orders> AllOrders
        {
            get
            {
                return allOrders;
            }
            set
            {
                AllOrders = value;
            }
        }

      
    }
}
