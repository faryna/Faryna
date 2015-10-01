using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VK_API
{
    
    class AudioController
    {
        List<PlayList> currentPlaylist;
        System.Windows.Forms.Timer timer1;
        MediaElement mediaElement1;
        public int SliderPos { get; set; }
        public int SliderMax { get; set; }
        public event EventHandler CurrentTrekComlite;
        public event EventHandler PlayPauseChange;
        public event EventHandler NextTrekChange;
        public event EventHandler PrevTrekChange;
        public bool IsPlaying { get; set; }
        public int IndexCurrentList { get; set; }
        public AudioController(List<PlayList> playlist)
        {
            SliderPos = 0;
            IsPlaying = false;
            IndexCurrentList = 0;
            this.currentPlaylist = playlist;
            mediaElement1 = new MediaElement();
            //this.mediaElement1 = mediaElem;
            //mediaElem.Source = new Uri(@"C:\Users\Slavik\Music\InTheCar\e143648e3657e3.mp3");
            //mediaElem.Play();
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                SliderPos++;
                if (SliderPos == SliderMax)
                {
                    EventOKTrekComplite();
                    //mediaElement1.Source = new Uri(currentPlaylist[MusicBox.SelectedIndex].Url);
                }
            }
            catch (Exception ex) { }

        }

        //private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    try
        //    {
        //        mediaElement1.Source = new Uri(currentPlaylist[MusicBox.SelectedIndex].Url);
        //        slider1.Value = 0;
        //        mediaElement1.Play();
        //        buttonPlayPause.Content = "Pause";

        //        timer1.Start();
        //    }
        //    catch (Exception ex) { }
        //}

        private void buttonPlayPause_Click(object sender, RoutedEventArgs e)
        {
            if (IsPlaying == false)
            {
                try
                {
                    mediaElement1.Play();
                    IsPlaying = true;
                    timer1.Start();
                }
                catch (Exception ex) { }
            }
            else
            {
                try
                {
                    mediaElement1.Pause();
                    IsPlaying = false;
                    timer1.Stop();
                    //System.Windows.MessageBox.Show(mediaElement1.NaturalDuration.TimeSpan.Minutes.ToString());
                }
                catch (Exception ex) { }
            }
        }

        private void buttonPrev_Click(object sender, RoutedEventArgs e)
        {
            if (IndexCurrentList != 0)
            {
                IndexCurrentList--;
                mediaElement1.Source = new Uri(currentPlaylist[IndexCurrentList].Url);

            }
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            if (IndexCurrentList < currentPlaylist.Count)
            {
                IndexCurrentList++;
                mediaElement1.Source = new Uri(currentPlaylist[IndexCurrentList].Url);
            }
        }

        private void SliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider s = sender as Slider;
            mediaElement1.Volume = (double)s.Value;
        }

        private void mediaElement1_MediaOpened(object sender, RoutedEventArgs e)
        {
            SliderMax = mediaElement1.NaturalDuration.TimeSpan.Seconds + (mediaElement1.NaturalDuration.TimeSpan.Minutes * 60);
        }

        private void slider1_IsMouseCaptureWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Slider s = sender as Slider;
            int SliderValue = (int)s.Value;

            // Overloaded constructor takes the arguments days, hours, minutes, seconds, miniseconds.
            // Create a TimeSpan with miliseconds equal to the slider value.
            TimeSpan ts = new TimeSpan(0, 0, 0, SliderValue);
            mediaElement1.Position = ts;
            SliderPos = SliderValue;
        }

        #region EVENT FUNC
        void EventOKTrekComplite()
        {
            if (CurrentTrekComlite != null)
            {
                CurrentTrekComlite.Invoke(null, EventArgs.Empty);
            }
        }
        #endregion

    }
    
}
