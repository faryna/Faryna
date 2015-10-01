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

namespace VK_API
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    enum ProfileButton
    {
        FriendButton,
        SharedButton,
        AudiosButton,
        PhotosButton
    }
    public partial class ProfilePage : Page
    {
        Dictionary<string, Button> buttons;
        UserInfo ui;
        string[] bm = { ProfileButton.FriendButton.ToString(), ProfileButton.SharedButton.ToString(), ProfileButton.AudiosButton.ToString(), ProfileButton.PhotosButton.ToString() };
        public ProfilePage()
        {
            InitializeComponent();
            ResourceDictionary rd = new ResourceDictionary();
            
            buttons = new Dictionary<string, Button>();
            foreach (string i in bm)
            {
                Button b = new Button();
                b.Width = 135;
                b.Height = 40;
                b.FontSize = 20;
                b.Margin = new Thickness(2, 2, 0, 0);
                b.Name = i;
                buttons.Add(i, b);
            }
        }
        public void InitPage(UserInfo ui)
        {
            this.ui = ui;
            _buttonsWrap.Children.Clear();
            if (ui.CountFriend != 0)
            {
                buttons["FriendButton"].Content = (string)Application.Current.Resources["ProfilePageFriendsButton"] + " " + ui.CountFriend;
                _buttonsWrap.Children.Add(buttons["FriendButton"]);
            }
            if (ui.CountShared != 0)
            {
                buttons["SharedButton"].Content = (string)Application.Current.Resources["ProfilePageSharedButton"] + " " + ui.CountShared;
                _buttonsWrap.Children.Add(buttons["SharedButton"]);
            }
            if (ui.CountPhotos != 0)
            {
                buttons["PhotosButton"].Content = (string)Application.Current.Resources["ProfilePagePhotosButton"] + " " + ui.CountPhotos;
                _buttonsWrap.Children.Add(buttons["PhotosButton"]);
            }
            if (ui.CountAudios != 0)
            {
                buttons["AudiosButton"].Content = (string)Application.Current.Resources["ProfilePageAudiosButton"] + " " + ui.CountAudios;
                _buttonsWrap.Children.Add(buttons["AudiosButton"]);
            }
            if (ui.Online == 1)
            {
                Uri uri = new Uri("Online.png", UriKind.Relative);
                BitmapImage bitmap = new BitmapImage(uri);
                _onlineImage.Source = bitmap;
            }
            else if (ui.Online == 2)
            {
                Uri uri = new Uri("OnlinePhone.png", UriKind.Relative);
                BitmapImage bitmap = new BitmapImage(uri);
                _onlineImage.Source = bitmap;
            }
            _nameLable.Content = ui.Name + " " + ui.Surname;
            _satusLable.Content = ui.Status;
            BitmapImage bi = new BitmapImage(new Uri(ui.Avatar));
            _avatarImage.Source = bi;
        }
        public Dictionary<string, Button> GetProfileButton { get { return buttons; } }

        public UserInfo GetUserInfo { get { return ui; } }
    }
}
