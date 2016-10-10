using SOSQL;
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
    /// Interaction logic for ItemRow.xaml
    /// </summary>
    public partial class ItemRow : UserControl
    {
        private bool Active = true;
        private LaunchScreen Parent;
        public ItemRow(LaunchScreen _Parent)
        {
            InitializeComponent();
            Parent = _Parent;
            UpdateButton.Click += UpdateButton_Click;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Active)
            {
                Active = false;
                Parent.NewRow();
            }
        }

        public MedicalDevice GetDate()
        {
            return new MedicalDevice(4);
        }
    }
}
