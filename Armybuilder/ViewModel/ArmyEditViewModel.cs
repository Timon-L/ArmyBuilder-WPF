using ArmyBuilder.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ArmyBuilder.ViewModel
{
    public class ArmyEditViewModel : INotifyPropertyChanged
    {
        private Unit? _selectedUnit;
        public ArmyEditViewModel() 
        {
            
        }
        public Unit SelectedUnit
        {
            get => _selectedUnit;
            set
            {
                if(_selectedUnit != value)
                {
                    _selectedUnit = value;
                    OnPropertyChanged(nameof(SelectedUnit));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
