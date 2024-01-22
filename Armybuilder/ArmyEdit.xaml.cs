using ArmyBuilder.Models;
using ArmyBuilder.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ArmyBuilder
{
    public partial class ArmyEdit : Window
    {
        MainViewModel viewmodel = MainViewModel.Instance;
        public ArmyEdit()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (viewmodel.SelectedArmy == null)
            {
                Army newarmy = new();
                newarmy.ArmyName = "new army";
                newarmy.FkFaction = viewmodel.FactionsViewModel.Factions_dic.Values.First();
                viewmodel.SelectedArmy = newarmy;
                viewmodel.ArmiesViewModel.Armies.Add(newarmy);
                viewmodel.ArmyFilter.FilterSelectedUnitsByFaction(newarmy.FkFaction);
            }
            FactionComboBox.ItemsSource = viewmodel.FactionsViewModel.Factions_dic.Values;
            FactionComboBox.DisplayMemberPath = "FactionName";
            this.DataContext = viewmodel;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close?", "Confirm", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
            {
                e.Cancel = true;
                return;
            }
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Column.Header.ToString() == "Quantity" && e.Row.DataContext is DetachmentUnit detachmentUnit)
            {
                var textBox = e.EditingElement as TextBox;
                if (int.TryParse(textBox.Text, out int newQuantity))
                {
                    detachmentUnit.Quantity = newQuantity;
                    setNewArmyPoints();
                }
            }
        }

        private void UnitCost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && sender is ComboBox comboBox)
            {
                var unitCost = comboBox.SelectedItem as UnitCost;
                var detachmentUnit = comboBox.DataContext as DetachmentUnit;

                if (detachmentUnit != null && unitCost != null)
                {
                    detachmentUnit.UnitCost = unitCost;
                    setNewArmyPoints();
                }
            }
        }

        private void setNewArmyPoints()
        {
            viewmodel.ArmyTotalCost = viewmodel.PointsCalculation.getTotalPoints(viewmodel.ArmyFilter.SelectedDetachments);
        }
    }
}
