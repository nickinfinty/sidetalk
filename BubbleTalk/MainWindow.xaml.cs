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
using System.Xml;

namespace SideTalk
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Forms.NotifyIcon i; 
        public MainWindow()
        {
            InitializeComponent();
            icon();
        }

        private void icon()
        {
            i = new System.Windows.Forms.NotifyIcon();
            i.Icon = System.Drawing.SystemIcons.Application;
            i.BalloonTipText = "Interesting";
            i.BalloonTipTitle = "Hi.";
            i.Visible=true;
            i.BalloonTipClicked += (s, e) => MessageBox.Show("Hello Again.");
        }
            private void About_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.Show();
            
        }

        private void SettingsIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Settings st = new Settings();
            st.Show();
        }
        
        private void startTalk(object sender, MouseButtonEventArgs e)
        {                        
            if (mySettings.firstRun)
            {
                setup st = new setup();
                st.Show();
                this.Close();
                return;
            }
            TalkWindow tw = new TalkWindow();        
            tw.Show();            
            this.Hide();
        }

        private void Label_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void mainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void mainWindow_StateChanged(object sender, EventArgs e)
        {
            if(WindowState==WindowState.Minimized){
                this.Hide();
            }
        }                                             
    }
}
