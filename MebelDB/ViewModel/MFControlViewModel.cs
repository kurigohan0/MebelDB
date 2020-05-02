using MebelDB.API;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MebelDB.ViewModel
{
    class MFControlViewModel:BaseViewModel
    {
        Page p;
        public MFControlViewModel(Page p)
        {
            this.p = p;
            EditFurniture = Visibility.Hidden;
            EditMaterial = Visibility.Hidden;


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

        private int selectedMaterial;
        public int SelectedMaterial
        {
            get
            {
                return selectedMaterial;
            }
            set
            {
                selectedMaterial = value;
                MaterialName = MaterialSet[SelectedMaterial].Name;
                MaterialMeasuring = MaterialSet[SelectedMaterial].Unit_measuring;
                MaterialQuantity = MaterialSet[SelectedMaterial].Quantity;
                MaterialType = MaterialSet[SelectedMaterial].Type_material;
                MaterialPrice = MaterialSet[SelectedMaterial].Purchase_price;
                MaterialLength = MaterialSet[SelectedMaterial].Length.ToString();
                MaterialGOST = MaterialSet[SelectedMaterial].GOST;
                OnPropertyChanged("SelectedMaterial");
            }
        }

        private int selectedFurniture;
        public int SelectedFurniture
        {
            get
            {
                return selectedFurniture;
            }
            set
            {
                selectedFurniture = value;
                FurnitureName = FurnitureSet[SelectedFurniture].Name;
                FurnitureMeasuring = FurnitureSet[SelectedFurniture].Unit_measuring;
                FurnitureQuantity = FurnitureSet[SelectedFurniture].Quantity.ToString();
                FurnitureType = FurnitureSet[SelectedFurniture].Type_component;
                FurniturePrice = FurnitureSet[SelectedFurniture].Purchase_price.ToString();

                OnPropertyChanged("SelectedFurniture");
            }
        }

        //----------------------------------------------------Edit properties

        #region MaterialEditor


        private RelayCommand editMaterialCommand;

        public RelayCommand EditMaterialCommand
        {
            get
            {
                return editMaterialCommand ??
                    (editMaterialCommand = new RelayCommand(obj =>
                    {
                        EditMaterial = Visibility.Visible;
                        
                    }));
            }

        }

        private RelayCommand materialCancelCommand;

        public RelayCommand MaterialCancelCommand
        {
            get
            {
                return materialCancelCommand ??
                    (materialCancelCommand = new RelayCommand(obj =>
                    {
                        EditMaterial = Visibility.Hidden;

                    }));
            }

        }

        private RelayCommand materialDeleteCommand;

        public RelayCommand MaterialDeleteCommand
        {
            get
            {
                return materialDeleteCommand ??
                    (materialDeleteCommand = new RelayCommand(obj =>
                    {
                        //TODO

                    }));
            }

        }

        private RelayCommand materialSaveCommand;

        public RelayCommand MaterialSaveCommand
        {
            get
            {
                return materialSaveCommand ??
                    (materialSaveCommand = new RelayCommand(obj =>
                    {
                        //TODO

                    }));
            }

        }

        private Visibility editMaterial;
        public Visibility EditMaterial
        {
            get
            {
                return editMaterial;
            }
            set
            {
                editMaterial = value;
                OnPropertyChanged("EditMaterial");
            }
        }

        private string materialName;
        public string MaterialName
        {
            get
            {
                return materialName;
            }
            set
            {
                materialName = value;
                OnPropertyChanged("MaterialName");

            }
        }

        private string materialMeasuring;
        public string MaterialMeasuring
        {
            get
            {
                return materialMeasuring;

            }
            set
            {
                materialMeasuring = value;
                OnPropertyChanged("MaterialMeasuring");

            }
        }

        private string materialQuantity;
        public string MaterialQuantity
        {
            get
            {
                return materialQuantity;

            }
            set
            {
                materialQuantity = value;
                OnPropertyChanged("MaterialQuantity");

            }
        }

        private string materialType;
        public string MaterialType
        {
            get
            {
                return materialType;

            }
            set
            {
                materialType = value;
                OnPropertyChanged("MaterialType");

            }
        }

        private string materialPrice;
        public string MaterialPrice
        {
            get
            {
                return materialPrice;

            }
            set
            {
                materialPrice = value;
                OnPropertyChanged("MaterialPrice");

            }
        }

        private string materialLength;
        public string MaterialLength
        {
            get
            {
                return materialLength;

            }
            set
            {
                materialLength = value;
                OnPropertyChanged("MaterialLength");

            }
        }

        private string materialGOST;
        public string MaterialGOST
        {
            get
            {
                return materialGOST;

            }
            set
            {
                materialGOST = value;
                OnPropertyChanged("MaterialGOST");
            }
        }
        #endregion



        #region FurnitureEditor

        private RelayCommand editFurnitureCommand;

        public RelayCommand EditFurnitureCommand
        {
            get
            {
                return editFurnitureCommand ??
                    (editFurnitureCommand = new RelayCommand(obj =>
                    {
                        EditFurniture = Visibility.Visible;

                    }));
            }

        }

        private RelayCommand furnitureCancelCommand;

        public RelayCommand FurnitureCancelCommand
        {
            get
            {
                return furnitureCancelCommand ??
                    (furnitureCancelCommand = new RelayCommand(obj =>
                    {
                        EditFurniture = Visibility.Hidden;
                    }));
            }

        }

        private RelayCommand furnitureDeleteCommand;

        public RelayCommand FurnitureDeleteCommand
        {
            get
            {
                return furnitureDeleteCommand ??
                    (furnitureDeleteCommand = new RelayCommand(obj =>
                    {
                        //TODO

                    }));
            }

        }

        private RelayCommand furnitureSaveCommand;

        public RelayCommand FurnitureSaveCommand
        {
            get
            {
                return furnitureSaveCommand ??
                    (furnitureSaveCommand = new RelayCommand(obj =>
                    {
                        //TODO

                    }));
            }

        }

        private Visibility editFurniture;
        public Visibility EditFurniture
        {
            get
            {
                return editFurniture;
            }
            set
            {
                editFurniture = value;
                OnPropertyChanged("EditFurniture");
            }
        }

        


        private string furnitureName;
        public string FurnitureName
        {
            get
            {
                return furnitureName;
            }
            set
            {
                furnitureName = value;
                OnPropertyChanged("FurnitureName");

            }
        }

        private string furnitureMeasuring;
        public string FurnitureMeasuring
        {
            get
            {
                return furnitureMeasuring;

            }
            set
            {
                furnitureMeasuring = value;
                OnPropertyChanged("FurnitureMeasuring");

            }
        }

        private string furnitureQuantity;
        public string FurnitureQuantity
        {
            get
            {
                return furnitureQuantity;

            }
            set
            {
                furnitureQuantity = value;
                OnPropertyChanged("FurnitureQuantity");

            }
        }

        private string furnitureType;
        public string FurnitureType
        {
            get
            {
                return furnitureType;

            }
            set
            {
                furnitureType = value;
                OnPropertyChanged("FurnitureType");

            }
        }

        private string furniturePrice;
        public string FurniturePrice
        {
            get
            {
                return furniturePrice;

            }
            set
            {
                furniturePrice = value;
                OnPropertyChanged("FurniturePrice");

            }
        }

       
        #endregion



    }
}
