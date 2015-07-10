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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SideTalk
{
    /// <summary>
    /// TalkWindowImage.xaml 的交互逻辑
    /// </summary>
    public partial class TalkWindowImage : Window
    {
        public TalkWindowImage()
        {
            InitializeComponent();
        }

        private void label2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
         label2.Background = new SolidColorBrush(Color.FromRgb(241, 196, 15));
         this.Close();
        }



        ///private void Label_MouseDown(object sender, MouseButtonEventArgs e)
      //  {
        //    DoubleAnimation ok = new DoubleAnimation();
        //    ok.To = 1;
         //   ok.Duration = TimeSpan.FromMilliseconds(1);
         //   this.label2.BeginAnimation(Label.OpacityProperty,ok);
          //  this.Close();
       // }

        private void Label_MouseMove(object sender, MouseEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0.5;
            da.To = 1;
            
            da.Duration = TimeSpan.FromSeconds(3);
        
            this.St1.BeginAnimation(Label.OpacityProperty,da);

        }

        

       

        

         
         
    }
}
