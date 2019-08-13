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

namespace HayStack
{
    /// <summary>
    /// Interaction logic for Contacts.xaml
    /// </summary>
    public partial class Contacts : Page
    {
        public EventHandler ladder;
        public Contacts()
        {
            InitializeComponent();
        }

        public void ClimbLadder()
        {
            ladder(this, EventArgs.Empty);
        }

        private void Contacts_Return(object sender, RoutedEventArgs e)
        {
            ClimbLadder();
        }
    }
}
