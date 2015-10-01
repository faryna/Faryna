using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for FriendPage.xaml
    /// </summary>
    public partial class FriendPage : Page
    {
        public List<Friend> friendList;
        List<FriendItemControl> friendItemControl;
        public List<FriendItemControl> GetFriendItemControl { get { return friendItemControl; } }
        Frame frame;
        delegate List<Friend> asycGetFriendList(int userID);
        public event EventHandler initComplete;
        FriendItemControl fic = new FriendItemControl();
        int userID;
        public FriendPage(int userID)
        {
            InitializeComponent();
            friendItemControl = new List<FriendItemControl>();
            this.userID = userID;
            InitFriendFunc();
        }
        void InitFriendFunc()
        {
            asycGetFriendList aget = Friend.InitListFriend;
            IAsyncResult a = aget.BeginInvoke(userID, new AsyncCallback(CallBack), aget);
        }
        void CallBack(IAsyncResult a)
        {
            asycGetFriendList aget = a.AsyncState as asycGetFriendList;
            friendList = aget.EndInvoke(a);
            _listFriend.Dispatcher.Invoke(new Action(() => _listFriend.ItemsSource = friendList));
            #region
            // Thread.Sleep(5000);
            //friendList.ForEach(x =>_list.Dispatcher.Invoke(new Action(()=> {
            //    _list.Items.Add(x.LastName + "  " + x.Firstname);
            //    fic = new FriendItemControl(x);
            //})));

            //for (int i = 0; i < friendList.Count - 1; i++)
            //{
            //    fic.Dispatcher.Invoke(new Action(() => fic = new FriendItemControl(friendList[i])));
            //    friendItemControl.Add(fic);
            //}
            //for (int i = 0; i < friendList.Count - 1; i++)
            //{
            //   Dispatcher.Invoke(new Action(() => _friendList.Children.Add(friendItemControl[i])));
            //}
            //Dispatcher.InvokeAsync(new
            // Action(() =>
            // {
                 //friendList.ForEach(x =>
                 //{
                 //    fic.Dispatcher.Invoke(new Action(() =>
                 //        {
                 //            fic = new FriendItemControl(x);
                 //            friendItemControl.Add(fic);
                 //            _friendList.Children.Add(fic);
                 //            //friendItemControl.MouseDown+=fic_MouseDown;
                 //            _friendList.Height += fic.Height;
                 //        }));
                 //});
            // }));
            #endregion
            EventOK();
        }

        void EventOK()
        {
            if (initComplete != null)
            {
                initComplete.Invoke(null, EventArgs.Empty);
            }
        }
        private void fic_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _listFriend.ItemsSource = friendList.Where(x => x.Online != 0);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _listFriend.ItemsSource = friendList;
        }
    }
    
}
