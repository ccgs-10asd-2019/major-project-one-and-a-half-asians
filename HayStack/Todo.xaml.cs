using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for Todo.xaml
    /// </summary>
    public partial class Todo : Page
    {
        public int TitleSize = 2;
        public EventHandler ladder;
        public Todo()
        {
            InitializeComponent();
        }
        public void ClimbLadder()
        {
            ladder(this, EventArgs.Empty);
        }

        private void Todo_Return(object sender, RoutedEventArgs e)
        {
            ClimbLadder();
        }

        private void Fade(object sender, RoutedEventArgs e)
        {
            FadeGrid.Visibility = Visibility.Visible;
            string chbxName = ((Button)sender).Name;
            Title.Text = chbxName;

        }


        private void ToDoBtnClick(object sender, RoutedEventArgs e)
        {
            ShowMyToDo();
        }
        private void ShowMyToDo()
        {
            ToDoReal MyPage = new ToDoReal();
            var TodoContents = Content;
            Content = MyPage;
            MyPage.ladder += (object sender, EventArgs e) =>
            {
                Content = TodoContents;
            };
        }

        private void UnFade(object sender, RoutedEventArgs e)
        {
            FadeGrid.Visibility = Visibility.Collapsed;
            //Row1.Height = new GridLength(TitleSize);
        }

    }
}
