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
using System.Xml;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace SideTalk
{
    /// <summary>
    /// TalkWindow.xaml 的交互逻辑   
    /// </summary>
    public partial class TalkWindow : Window
    {
        private string accessToken;
        public static string answer;
        public static string question;
        Analysis ana = new Analysis();
        public static UIElement extra =null;
    public TalkWindow()
        {
            InitializeComponent();
    }

    private void getAccessToken()
    {
        HttpWebRequest getOAuth = WebRequest.Create("https://openapi.baidu.com/oauth/2.0/token?client_id=q6TFHKWt1GLko5nS8uAMw84m&client_secret=0a4d66a250e8a019c3a7e998db421e74&grant_type=client_credentials") as HttpWebRequest;
        getOAuth.Method = "GET";
        JObject oResp = JObject.Parse(new StreamReader(getOAuth.GetResponse().GetResponseStream()).ReadToEnd());
        accessToken = oResp["access_token"].ToString();
        
    }
        bool named = false;
        public static string name;
        //private static System.Timers.Timer aTimer;
        private void InputText_GotFocus(object sender, RoutedEventArgs e)
        {
            InputText.Text = "";
            InputText.Foreground = Brushes.Black;
        }
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.Show();
            this.Close();
        }

        private void UploadBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            question = InputText.Text;
            InputText.Text = "";
            ShowAsk();
            ana.Answer(this);
            ShowAns();
            return;       
        }

        private void InputText_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (!System.Text.RegularExpressions.Regex.IsMatch(this.InputText.Text, " "))
            {
                this.InputText.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.InputText.Text);
                this.InputText.Select(this.InputText.Text.Length, 0);
            }
           if (e.Key == Key.Enter)
            {
                if (!String.IsNullOrWhiteSpace(InputText.Text))                 
                {
                    if (!named) {
                        name = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.InputText.Text);
                        question = name;
                        InputText.Text = "";
                        ShowAsk();
                        answer = "Hi," + name+".We can start our conversation now.";
                        ShowAns();
                        named = true;
                       // try { ur.Name = name; }
                       // catch (Exception ex) { }
                       // MessageBox.Show(ur.city);
                        return;
                    } 
                    question = InputText.Text;
                    InputText.Text = "";
                    ShowAsk();
                    ana.Answer(this);
                    if (answer != "") ShowAns();
                    return;
                }               
            }
        }
        public void ShowAns()
        {
            //Paragraph ansPr = new Paragraph(new Run(answer));
            //ansPr.SetValue(Block.TextAlignmentProperty, TextAlignment.Left);
            //textfield.Blocks.Add(ansPr);
            //textBox.ScrollToEnd();
            Label lb = new Label();
            lb.HorizontalAlignment = HorizontalAlignment.Left;
            lb.MaxWidth = 270;
            TextBlock tb = new TextBlock();
            tb.Text = answer;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.FontSize = 18;
            FontFamilyConverter ffc = new FontFamilyConverter();
            tb.FontFamily = (FontFamily)ffc.ConvertFromString("Segoe UI");
            lb.Content = tb;
            textfield.Children.Add(lb);
            if (extra!=null)
            {
                textfield.Children.Add(extra);
                extra = null;
            }
            sv.ScrollToEnd();
            speak();
            
        }

        private void speak()
        {
            voice.Source = new Uri("http://tsn.baidu.com/text2audio?tex=" + answer + "&lan=en&cuid=" + name + "&ctp=1&per="+(mySettings.voicetype?"0":"1")+"&tok=" + accessToken);
        }
        public void ShowAsk()
        {
                       
            //Paragraph askPr = new Paragraph(new Run(question));
            //askPr.SetValue(Block.TextAlignmentProperty, TextAlignment.Right);
            //textfield.Blocks.Add(askPr);
            //textBox.ScrollToEnd();
            Label lb = new Label();
            lb.HorizontalAlignment = HorizontalAlignment.Right;
            lb.MaxWidth = 270;
            TextBlock tb = new TextBlock();
            tb.Text = question;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.FontSize = 18;
            FontFamilyConverter ffc = new FontFamilyConverter();
            tb.FontFamily = (FontFamily)ffc.ConvertFromString("Segoe UI");
            lb.Content = tb;
            textfield.Children.Add(lb);
            sv.ScrollToEnd();
            /*                  
            if (ans != "")
            {
                
            Paragraph ansPr = new Paragraph(new Run(ans));
            ansPr.SetValue(Block.TextAlignmentProperty, TextAlignment.Left);
            textfield.Blocks.Add(ansPr);
            textBox.ScrollToEnd();
            if (ans == "You made me so sad.I need time crying.")
            {
                aTimer = new System.Timers.Timer(10000);
                aTimer.Elapsed += (source, e) =>
                {
                    aTimer.Stop();
                    this.Close();
                    Application.Current.MainWindow.Close();
                }; 
                aTimer.Interval = 2000;
                aTimer.Enabled = true;             
            }
            }  */                    
            
        }
        System.Timers.Timer tm = new System.Timers.Timer();
        private void UploadBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InputText.Text)) return;
            question = InputText.Text;
            InputText.Text = "";
            ShowAsk();
            ana.Answer(this);
            ShowAns();
            return;            
        }

        /*private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }*/

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Image_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            textfield.Children.Clear();
        }

        private void minimize_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            this.DragMove();
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
           TalkWindowImage ab = new TalkWindowImage();
           ab.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InputText.Focus();
            getAccessToken();
            Analysis.ur.IsMale = mySettings.isMale;
            answer = mySettings.isMale ? "Hi, Mr. May I have your name ,please?" : "Hi, Ms. May I have your name ,please?";
            ShowAns();
        }

        private void settings_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            settings.Source=new BitmapImage(new Uri("settings_filled-32.png",UriKind.Relative));
        }

        private void settings_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            settings.Source = new BitmapImage(new Uri("settings-32.png", UriKind.Relative));
            Settings s = new Settings();
            s.Show();
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        
    }
}
