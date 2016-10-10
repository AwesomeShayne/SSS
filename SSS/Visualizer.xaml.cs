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
    /// Interaction logic for Visualizer.xaml
    /// </summary>
    public partial class Visualizer : UserControl
    {
        private LaunchScreen PreviousScreen;
        private MainWindow Parent;
        public Visualizer(MainWindow _Parent, LaunchScreen _PreviousScreen)
        {
            InitializeComponent();
            Parent = _Parent;
            PreviousScreen = _PreviousScreen;
            BackButton.Click += BackButton_Click;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Parent.SetContent(PreviousScreen);
        }
    }
}
