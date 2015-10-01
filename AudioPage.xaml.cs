using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VK_API
{
    /// <summary>
    /// Interaction logic for AudioPage.xaml
    /// </summary>
    public partial class AudioPage : Page
    {
        List<PlayList> accountPlayList;
        List<PlayList> currentPlaylist;
        System.Windows.Forms.Timer timer1;
        List<Friend> listFriend;
        MediaElement mediaElement1;
        
        public AudioPage(MediaElement me)
        {
            mediaElement1 = me;
            mediaElement1.MediaOpened += mediaElement1_MediaOpened;
            InitializeComponent();
            Thread t = new Thread(InitPlayList);
            t.Start();
            
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            
        }
        void InitPlayList()
        {
            Dispatcher.Invoke(new Action(() =>
            {
                if (accountPlayList == null)
                {
                    listFriend = Friend.InitListFriend(Authorize.UserID);
                    _lisFriendMusic.Items.Clear();
                    listFriend.ForEach(x => _lisFriendMusic.Items.Add(x.LastName + " " + x.Firstname));
                    asynGetPlaylist aget = VKMusic.AddMusic;
                    try
                    {
                        //currentPlaylist = VKMusic.AddMusic(listFriend[_lisFriendMusic.SelectedIndex].UserID);
                        IAsyncResult a = aget.BeginInvoke(Authorize.UserID, new AsyncCallback(CallBackGetMusic), aget);

                    }
                    catch (Exception ex) { }
                }
                else
                {
                    currentPlaylist = accountPlayList;
                    MusicBox.Items.Clear();
                    currentPlaylist.ForEach(x => MusicBox.Items.Add(x.Artist + "- " + x.Title));
                }
            }));
        }
        //MEDIA CONTROL
        void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //timelineSlider.Maximum = mediaElement1.NaturalDuration.TimeSpan.TotalMilliseconds;
                //slider1.Maximum = mediaElement1.NaturalDuration.TimeSpan.Seconds + (mediaElement1.NaturalDuration.TimeSpan.Minutes * 60);
                slider1.Value++;// = mediaElement1.Position.Seconds;
                if (slider1.Value == slider1.Maximum)
                {
                    MusicBox.SelectedIndex++;
                    mediaElement1.Source = new Uri(currentPlaylist[MusicBox.SelectedIndex].Url);
                }
            }
            catch (Exception ex) { }

        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                mediaElement1.Source = new Uri(currentPlaylist[MusicBox.SelectedIndex].Url);
                slider1.Value = 0;
                mediaElement1.Play();
                buttonPlayPause.Content = "Pause";

                timer1.Start();
            }
            catch (Exception ex) { }
        }

        private void buttonPlayPause_Click(object sender, RoutedEventArgs e)
        {
            if (buttonPlayPause.Content == "Play")
            {
                try
                {
                    mediaElement1.Play();
                    buttonPlayPause.Content = "Pause";
                    timer1.Start();
                }
                catch (Exception ex) { }
            }
            else
            {
                try
                {
                    mediaElement1.Pause();
                    buttonPlayPause.Content = "Play";
                    timer1.Stop();
                    //System.Windows.MessageBox.Show(mediaElement1.NaturalDuration.TimeSpan.Minutes.ToString());
                }
                catch (Exception ex) { }
            }
        }

        private void buttonPrev_Click(object sender, RoutedEventArgs e)
        {
            if (MusicBox.SelectedIndex != 0)
            {
                MusicBox.SelectedIndex--;
                mediaElement1.Source = new Uri(currentPlaylist[MusicBox.SelectedIndex].Url);

            }
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            if (MusicBox.SelectedIndex < MusicBox.Items.Count)
            {
                MusicBox.SelectedIndex++;
                mediaElement1.Source = new Uri(currentPlaylist[MusicBox.SelectedIndex].Url);
            }
        }

        private void SliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //mediaElement1.Volume = (double)SliderVolume.Value;
        }

        private void mediaElement1_MediaOpened(object sender, RoutedEventArgs e)
        {
            slider1.Maximum = mediaElement1.NaturalDuration.TimeSpan.Seconds + (mediaElement1.NaturalDuration.TimeSpan.Minutes * 60);
        }

        private void slider1_IsMouseCaptureWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            int SliderValue = (int)slider1.Value;

            // Overloaded constructor takes the arguments days, hours, minutes, seconds, miniseconds.
            // Create a TimeSpan with miliseconds equal to the slider value.
            TimeSpan ts = new TimeSpan(0, 0, 0, SliderValue);
            mediaElement1.Position = ts;
        }
        delegate List<PlayList> asynGetPlaylist(int userID);
        private void _lisFriendMusic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            asynGetPlaylist aget = VKMusic.AddMusic;
            try
            {
                //currentPlaylist = VKMusic.AddMusic(listFriend[_lisFriendMusic.SelectedIndex].UserID);
                IAsyncResult a = aget.BeginInvoke(listFriend[_lisFriendMusic.SelectedIndex].UserID, new AsyncCallback(CallBackGetMusic), aget);
                
            }
            catch (Exception ex) { }
        }
        void CallBackGetMusic(IAsyncResult a)
        {
            asynGetPlaylist tmp = a.AsyncState as asynGetPlaylist;
            Dispatcher.Invoke(new
             Action(() =>
             {
                 currentPlaylist = tmp.EndInvoke(a);
                 MusicBox.Items.Clear();
                 //currentPlaylist.ForEach(x => MusicBox.Items.Add(x.Artist + "- " + x.Title));
                 foreach (var x in currentPlaylist)
                 {
                     MusicBox.Items.Add(x.Artist + "- " + x.Title);
                 }
             }));
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            listFriend = Friend.InitListFriend(listFriend[_lisFriendMusic.SelectedIndex].UserID);
            _lisFriendMusic.Items.Clear();
            listFriend.ForEach(x => _lisFriendMusic.Items.Add(x.LastName + " " + x.Firstname));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (accountPlayList == null)
            {
                listFriend = Friend.InitListFriend(Authorize.UserID);
                _lisFriendMusic.Items.Clear();
                listFriend.ForEach(x => _lisFriendMusic.Items.Add(x.LastName + " " + x.Firstname));
                accountPlayList = VKMusic.AddMusic(Authorize.UserID);
                currentPlaylist = accountPlayList;
                currentPlaylist.ForEach(x => MusicBox.Items.Add(x.Artist + "- " + x.Title));
            }
            else
            {
                currentPlaylist = accountPlayList;
                MusicBox.Items.Clear();
                currentPlaylist.ForEach(x => MusicBox.Items.Add(x.Artist + "- " + x.Title));
            }
        }
    }
}
