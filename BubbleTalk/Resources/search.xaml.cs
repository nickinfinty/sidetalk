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
    /// search.xaml 的交互逻辑
    /// </summary>
    public partial class search : UserControl
    {
        string text;
        string link;
        string detail;
        public search(string title,string detail,string link)
        {
            InitializeComponent();
            this.text = title;
            this.detail = detail;
            this.link = link;
        }

        private void content_Loaded(object sender, RoutedEventArgs e)
        {
            title.Content = text;
            content.Content = detail;
        }

        private void g_MouseDown(object sender, MouseButtonEventArgs e)
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
