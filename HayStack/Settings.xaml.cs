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
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Windows.Threading;
using System.Net.Http.Headers;
namespace HayStack
{
    /// <summary>
    /// Interaction logic for Contacts.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public EventHandler ladder;
        public Settings()
        {
            InitializeComponent();
        }

        public void ClimbLadder()
        {
            ladder(this, EventArgs.Empty);
        }

        private void Settings_Return(object sender, RoutedEventArgs e)
        {
            ClimbLadder();
        }

        private void ImagePanel_Enter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.All;
        }
        private void ImagePanel_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in files)
            {
                MessageBox.Show(file);
            }
        }

    }

}


