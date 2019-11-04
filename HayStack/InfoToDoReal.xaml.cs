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
    public partial class ToDoRealInfo : Page
    {
        public EventHandler ladder;

        public void ClimbLadder()
        {
            ladder(this, EventArgs.Empty);
        }

        public ToDoRealInfo()
        {
            InitializeComponent();
        }

        private void ReturnToDoBtnClick(object sender, RoutedEventArgs e)
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

    }
}
