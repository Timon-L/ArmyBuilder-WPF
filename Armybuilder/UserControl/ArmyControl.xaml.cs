using ArmyBuilder.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ArmyBuilder.Controls
{
    [ContentProperty(name:nameof(Army))]
    public partial class ArmyControl : UserControl
    {
        public static readonly DependencyProperty ArmyProperty =
            DependencyProperty.Register("Army", typeof(Army),
                typeof(ArmyControl), new PropertyMetadata(null));
        public ArmyControl()
        {
            InitializeComponent();
        }

        public Army Army
        {
            get { return  (Army)GetValue(ArmyProperty);}
            set { SetValue(ArmyProperty, value);}
        }
    }
}
