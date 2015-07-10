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
    /// minimize.xaml 的交互逻辑
    /// </summary>
    public partial class minimize : UserControl
    {
        public minimize()
        {
            InitializeComponent();
            //btn.Click += (sender, e) => {rt.Fill = new SolidColorBrush(Color.FromRgb(127, 140, 141));
            //Application.Current.Windows[0].Close();
            //}
            rt.MouseDown += (sender, e) => rt.Fill = new SolidColorBrush(Color.FromRgb(22, 160, 133));
            
        }
        private void rt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            Application.Current.Windows[0].WindowState = WindowState.Minimized;
        }

        private void rt_MouseUp(object sender, MouseButtonEventArgs e)
        {
            rt.Fill = new SolidColorBrush(Color.FromRgb(26, 188, 156));
            Application.Current.Windows[0].WindowState = WindowState.Minimized;
        }
    }
}
