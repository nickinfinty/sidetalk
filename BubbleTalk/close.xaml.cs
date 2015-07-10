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

namespace SideTalk
{
    /// <summary>
    /// close.xaml 的交互逻辑
    /// </summary>
    public partial class close : UserControl
    {
        public close()
        {
            InitializeComponent();
            rt.MouseDown += (sender, e) => rt.Fill = new SolidColorBrush(Color.FromRgb(243,156,18));
        }

        private void rt_MouseUp(object sender, MouseButtonEventArgs e)
        {
            rt.Fill = new SolidColorBrush(Color.FromRgb(241, 196, 15));
            Application.Current.Windows[0].Close();
        }
    }
}
