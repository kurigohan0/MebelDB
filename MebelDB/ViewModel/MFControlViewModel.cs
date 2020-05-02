using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MebelDB.ViewModel
{
    class MFControlViewModel:BaseViewModel
    {
        Page p;
        public MFControlViewModel(Page p)
        {
            this.p = p;
            Refresh();
        }

        async public void Refresh()
        {
            furnitureSet.Clear();
            materialSet.Clear();
            await Task.Run(() =>
            {
                foreach (var item in GetEntities().Furniture)
                {
                    p.Dispatcher.Invoke(() =>
                    {
                        furnitureSet.Add(item);
                        OnPropertyChanged("FurnitureSet");

                    });
                }
                foreach (var item in GetEntities().Materials)
                {
                    p.Dispatcher.Invoke(() =>
                    {
                        materialSet.Add(item);
                        OnPropertyChanged("MaterialSet");

                    });
                }
            });
        }

        private ObservableCollection<Model.Furniture> furnitureSet = new ObservableCollection<Model.Furniture>();
        public ObservableCollection<Model.Furniture> FurnitureSet
        {
            get
            {
                return furnitureSet;
            }
            set
            {
                furnitureSet = value;
                OnPropertyChanged("FurnitureSet");
            }
        }

        private ObservableCollection<Model.Materials> materialSet = new ObservableCollection<Model.Materials>();
        public ObservableCollection<Model.Materials> MaterialSet
        {
            get
            {
                return materialSet;
            }
            set
            {
                materialSet = value;
                OnPropertyChanged("MaterialSet");
            }
        }
    }
}
