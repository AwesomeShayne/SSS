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
        public LaunchScreen(MainWindow _Parent)
        {
            InitializeComponent();
            Parent = _Parent;
            SwitchContentButton.Click += SwitchContentButton_Click;
        }

        private void SwitchContentButton_Click(object sender, RoutedEventArgs e)
        {
            Parent.SetContent(new Visualizer());
        }
    }
}
