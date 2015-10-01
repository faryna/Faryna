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
using System.Windows.Media.Animation;
using VK_API;

namespace VK_API
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool leftPanel = false;
        ThicknessAnimation animationLeftPanel;
        Authorize auth;
        AccountGetProfileInfo p;
        List<PlayList> accountPlayList;
        List<PlayList> currentЗlaylist;
        AudioPage audioPage;
        FriendPage friendPage;
        ProfilePage profilePage;
        AudioController aController;
        public MainWindow()
        {
            InitializeComponent();
            animationLeftPanel = new ThicknessAnimation();
            auth = new Authorize();
            p = new AccountGetProfileInfo();
            profilePage = new ProfilePage();
            profilePage.GetProfileButton.ToList().ForEach(x=>x.Value.Click+=PageButtonClick);
            _userName.Content = p.Name + " " + p.Surname;
            InitPages();
            aController = new AudioController(currentЗlaylist);
        }

        private void ReInitialize()
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
            //InitializeComponent();
            
            //profilePage = new ProfilePage();
            //InitPages();
        }
        void PageButtonClick(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (b.Name == ProfileButton.FriendButton.ToString())
            {
                InitFriendPage(profilePage.GetUserInfo.ID);
            }
            //MessageBox.Show(b.Name+" "+ProfileButton.FriendButton.ToString());
        }

        private void Window_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            grid1.Height = this.Height;
            mainGrid.Height = this.Height;
            mainGrid.Width = this.Width;
            moveLeftPanel.Height = this.Height;
            moveLeftPanel.Padding = new Thickness(0, moveLeftPanel.Height / 2 - 50, 0, 0);
            
        }

        private void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            MoveLeftPanel();
        }

        private void _AudioButton_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            mainFrame.Navigate(audioPage);
            mainFrame.Width = audioPage.Width;
            mainFrame.Height = audioPage.Height;
            MoveLeftPanel();
        }

        private void _FriendButton_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            InitFriendPage(Authorize.UserID);
            MoveLeftPanel();
        }

        private void InitFriendPage(int userID)
        {
            friendPage = new FriendPage(userID);
            friendPage.initComplete += new EventHandler((obj, e1) =>
            friendPage._listFriend.SelectionChanged += _listFriend_SelectionChanged);
            mainFrame.Navigate(friendPage);
            mainFrame.Width = friendPage.Width;
            mainFrame.Height = friendPage.Height;
        }

        void _listFriend_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = sender as ListBox;
            var temp = lb.SelectedItem as Friend;
            InitProfilePage(temp.UserID);
        }

        private void MoveLeftPanel()
        {
            if (!leftPanel)
            {
                animationLeftPanel.From = new Thickness(grid1.Margin.Left, 0, 0, 0);
                animationLeftPanel.To = new Thickness(0, 0, 0, 0);
                animationLeftPanel.Duration = TimeSpan.FromSeconds(0.5);
                grid1.BeginAnimation(Grid.MarginProperty, animationLeftPanel);
                grid1.Focus();
                leftPanel = !leftPanel;
            }
            else
            {
                animationLeftPanel.From = new Thickness(grid1.Margin.Left, 0, 0, 0);
                animationLeftPanel.To = new Thickness(grid1.Margin.Left - grid1.Width + moveLeftPanel.Width, 0, 0, 0);
                animationLeftPanel.Duration = TimeSpan.FromSeconds(0.5);
                grid1.BeginAnimation(Grid.MarginProperty, animationLeftPanel);
                leftPanel = !leftPanel;
            }
        }

        private void InitPages()
        {
            audioPage = new AudioPage(mediaElement1);
        }

        private void _userName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            InitProfilePage(Authorize.UserID);
            MoveLeftPanel();
        }

        private void InitProfilePage(int userID)
        {
            profilePage.InitPage(new UserInfo(userID));
            mainFrame.Navigate(profilePage);
            mainFrame.Width = profilePage.Width + 20;
            mainFrame.Height = profilePage.Height + 20;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var foo = new Uri("langUK.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = foo });
            ReInitialize();
        }
    }
}
