using ArmyBuilder.ViewModel;
using System.Windows;

namespace ArmyBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = MainViewModel.Instance;
            ViewModel.LoadArmies();
            ViewModel.LoadDetachments();
            ViewModel.LoadAttachments(ViewModel.Armies, ViewModel.Detachments);
            ViewModel.LoadUnits();
            ViewModel.LoadDetachmentUnits(ViewModel.Detachments, ViewModel.Units);
            DataContext = ViewModel;
            
        }
    }
}