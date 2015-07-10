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
using System.Windows.Shapes;

namespace SideTalk
{
    /// <summary>
    /// setup.xaml 的交互逻辑
    /// </summary>
    public partial class setup : Window
    {
        public setup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mySettings.isMale = true;
            mySettings.firstRun = false;         
            TalkWindow tw = new TalkWindow();
            tw.Show();
            this.Close();
         
        }

        private void fButton_Click(object sender, RoutedEventArgs e)
        {
            mySettings.isMale = false;
            mySettings.firstRun = false; 
            TalkWindow tw = new TalkWindow();            
            tw.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Oh,really?", "Sure?", MessageBoxButton.YesNo,MessageBoxImage.Warning);
        }
    }
}
