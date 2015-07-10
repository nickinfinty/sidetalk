using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SideTalk.Resources
{
    /// <summary>
    /// Songs.xaml 的交互逻辑
    /// </summary>
    public partial class Songs : UserControl
    {
        private bool isPlaying = true;
        private Uri file;
        private Uri picture;
        private string name;
        private string singer;
        private System.Windows.Threading.DispatcherTimer t = new System.Windows.Threading.DispatcherTimer();
        /// <summary>
        /// Show a new song
        /// </summary>
        /// <param name="file">The file Uri</param>
        /// <param name="picture">The Uri of album image</param>
        /// <param name="name">The song's name</param>
        /// <param name="singer">The singer's name</param>
        /// <param name="i">The index of Songs.</param>
        public Songs(string file, string picture, string name, string singer, int i)
        {
            InitializeComponent();
            this.Name = "song" + Convert.ToString(i);
            this.file = new Uri(file);
            this.picture = new Uri(picture);
            this.name = name;
            this.singer = singer;
            t.Interval = new TimeSpan(500);
            t.Tick += t_Tick;

        }

        void t_Tick(object sender, EventArgs e)
        {
            
            //   pb.Value=me.Position.TotalSeconds/me.
        }






        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            me.Source = file;
            me.Play();
            songPic.Source = new BitmapImage(picture);
            songName.Content = name + " - " + singer;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying) me.Pause();
            else me.Play();
            isPlaying = !isPlaying;
        }

        private void me_MediaOpened(object sender, RoutedEventArgs e)
        {
            pb.Maximum = me.NaturalDuration.TimeSpan.TotalSeconds;
        }
    }
}
