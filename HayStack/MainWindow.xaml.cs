using HayStack;
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

namespace Hey_Stack_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TimetableBtnClick(object sender, RoutedEventArgs e)
        {
            ShowMyTimetable();
        }
        private void ShowMyTimetable()
        {
            Timetable MyPage = new Timetable();
            var TimetableContents = Content;
            Content = MyPage;
            MyPage.ladder += (object sender, EventArgs e) =>
            {
                Content = TimetableContents;
            };
        }


        private void ChatAppBtnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new Chatapp());
            this.Frame.Navigate(new Uri("ChatApp.xaml", UriKind.Relative));
        }

        private void ToDoBtnClick(object sender, RoutedEventArgs e)
        {
            ShowMyToDo();
        }
        private void ShowMyToDo()
        {
            Todo MyPage = new Todo();
            var TodoContents = Content;
            Content = MyPage;
            MyPage.ladder += (object sender, EventArgs e) =>
            {
                Content = TodoContents;
            };
        }

        private void ContactsBtnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new Contacts());
            this.Frame.Navigate(new Uri("Contacts.xaml", UriKind.Relative));
        }


        private void InfoBtnClick(object sender, RoutedEventArgs e)
        {
            ShowMyInfo();
        }
        private void ShowMyInfo()
        {
            Info MyPage = new Info();
            var InfoContents = Content;
            Content = MyPage;
            MyPage.ladder += (object sender, EventArgs e) =>
            {
                Content = InfoContents;
            };
        }


    }
}
