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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SSS
{
    /// <summary>
    /// Interaction logic for LaunchScreen.xaml
    /// </summary>
    public partial class LaunchScreen : UserControl
    {
        private MainWindow Parent;
        private int RowCount = 0;
        private List<ItemRow> Items;
        public LaunchScreen(MainWindow _Parent)
        {
            InitializeComponent();
            Parent = _Parent;
            ItemRows.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            var _ItemRow = new ItemRow(this);
            Grid.SetRow(_ItemRow, RowCount);
            Grid.SetColumnSpan(_ItemRow, 5);
            ItemRows.Children.Add(_ItemRow);
            ContinueButton.Click += ContinueButton_Click;
            
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            Parent.SetContent(new Visualizer(Parent, this));
        }

        internal void NewRow()
        {
            RowCount++;
            ItemRows.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            var _ItemRow = new ItemRow(this);
            Grid.SetRow(_ItemRow, RowCount);
            Grid.SetColumnSpan(_ItemRow, 5);
            ItemRows.Children.Add(_ItemRow);
        }
    }
}
