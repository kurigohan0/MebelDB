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
    class EquipmentViewModel:BaseViewModel
    {
        private Page p;
        public EquipmentViewModel(Page p)
        {
            this.p = p;
            foreach (var type in GetEntities().Type_Equipment)
            {
                Types.Add(type.Type_Equipment1);
            }
            Update();
        }

        async void Update()
        {
            AllEquipments.Clear();

            await Task.Run((() =>
                    {
                        foreach (var equipment in GetEntities().Equipment)
                        {
                            p.Dispatcher.Invoke(() =>
                            {
                                allEquipments.Add(new Model.Equipment
                                {
                                    Marking = equipment.Marking,
                                    Specifications = equipment.Specifications,
                                    Type_Equipment = equipment.Type_Equipment
                                });
                            });
                        }
                    }
                ));
        }

        private string marking;

        public string Marking
        {
            get
            {
                return marking;
            }
            set
            {
                marking = value;
                OnPropertyChanged("Marking");
            }
        }

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private ObservableCollection<string> types = new ObservableCollection<string>();
        public ObservableCollection<string> Types
        {
            get
            {
                return types;
            }
            set
            {
                types = value;
                OnPropertyChanged("Types");
            }
        }

        private int selectedType;

        public int SelectedType
        {
            get
            {
                return selectedType;
            }
            set
            {
                selectedType = value;
                OnPropertyChanged("SelectedType");
            }
        }

        private DateTime selectedDate = new DateTime(DateTime.Now.Ticks);

        public DateTime SelectgedDate
        {
            get
            {
                return selectedDate;
            }
            set
            {
                selectedDate = value;
                OnPropertyChanged("SelectgedDate");
            }
        }

        private string specifications;

        public string Specifications
        {
            get
            {
                return specifications;
            }
            set
            {
                specifications = value;
                OnPropertyChanged("Specifications");
            }
        }
        private ObservableCollection<Model.Equipment> allEquipments = new ObservableCollection<Model.Equipment>();

        public ObservableCollection<Model.Equipment> AllEquipments
        {
            get
            {
                return allEquipments;
            }
            set
            {
                allEquipments = value;
            }

        }


        private RelayCommand addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        try
                        {
                            Model.Equipment NewEquipment = new Model.Equipment();

                            NewEquipment.Marking = Marking;
                            NewEquipment.Specifications = Specifications;
                            NewEquipment.Type_Equipment = Types[selectedType];
                            Model.MebelEntities entities = GetEntities();
                            entities.Equipment.Add(NewEquipment);
                            entities.SaveChanges();
                            Update();
                            OnPropertyChanged("AllEquipments");
                        }
                        catch (System.Data.Entity.Infrastructure.DbUpdateException updateException)
                        {
                            MessageBox.Show("Скорее всего есть повторяющиеся значения.", "Ошибка добавления.", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        catch (System.Data.Entity.Validation.DbEntityValidationException validationException)
                        {


                            MessageBox.Show("Скорее всего вы не заполнили поля.", "Ошибка добавления.", MessageBoxButton.OK, MessageBoxImage.Warning);

                        }
                    }));
            }

        }

    }
}
