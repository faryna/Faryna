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
    /// Interaction logic for FriendItemControl.xaml
    /// </summary>
    public partial class FriendItemControl : UserControl
    {
        Friend friend;
        public Friend GetFriend { get { return friend; } }
        public FriendItemControl() { }
        public FriendItemControl(Friend friend)
        {
            InitializeComponent();
            this.friend = friend;
            _nameLable.Content = friend.Firstname + " " + friend.LastName;
            BitmapImage ab = new BitmapImage(new Uri(friend.AvatarUrl));
            _avatar.Source = ab;
            if (friend.Online == 1)
            {
                Uri uri = new Uri("Online.png", UriKind.Relative);
                BitmapImage bitmap = new BitmapImage(uri);
                _onlineImage.Source = bitmap;
            }
            else if (friend.Online == 2)
            {
                Uri uri = new Uri("OnlinePhone.png", UriKind.Relative);
                BitmapImage bitmap = new BitmapImage(uri);
                _onlineImage.Source = bitmap;
            }
            
        }
    }
}
