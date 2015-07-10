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
    /// news.xaml 的交互逻辑
    /// </summary>
    public partial class news : UserControl
    {
        private string title;
        private string picLink;
        private string link;
        public news(string title,string picLink,string link)
        {
            InitializeComponent();
            this.title = title;
            this.picLink = picLink;
            this.link = link;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            newsPic.Source = new BitmapImage(new Uri(picLink));
            nTitle.Text = title;
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            g.Opacity = 1;
        }

        private void g_MouseUp(object sender, MouseButtonEventArgs e)
        {
            g.Opacity = 0.505;
            System.Diagnostics.Process.Start(link);
        }
    }
}
