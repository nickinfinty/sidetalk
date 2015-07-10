using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Xml;
using System.Xml.XPath;
using SideTalk.Resources;
using HtmlAgilityPack;

namespace SideTalk
{
    /// <summary>
    /// The Analysis Class.
    /// </summary>
    
    public class Analysis
    {
        #region Main
        /// <summary>
        /// Start a new Analysis.
        /// </summary>
        public Analysis() { }
        public string text = "";
        public string[] splited;
        public bool inited = false;
        public static string city;
        public static string ip;
        public static Dictionary<string, string> wt = new Dictionary<string, string>();
        public static user ur = new user();
        int i=0;
        TalkWindow tw = null;
        /// <summary>
        /// Give answer to your TalkWindow.
        /// </summary>
        /// <param name="tw">Your TalkWindow</param>
        public void Answer(TalkWindow tw)
        {
            
            this.tw = tw;
            string str = TalkWindow.question;
            #region Text-Analysis
            str = str.ToLower();
            str = Regex.Replace(str, "'s", " is");
            str = Regex.Replace(str, "'re", " are");
            str = Regex.Replace(str, "'ll", " will");
            str = Regex.Replace(str, "'", " is");
            str = Regex.Replace(str, "n't", " not");
            str = Regex.Replace(str, "sidetalk's", "your");
            str = Regex.Replace(str, "sidetalk", "you");
            text = str;
            char[] sp = { ' ' };
            Debug.WriteLine(text);
            splited = text.Split(sp);
            #endregion
            words.init();
            if (Regex.IsMatch(text, "i want to buy|buy me")) { buy(); return; }
            if (Regex.IsMatch(text, "aqi|air pollution")) { aqi(); return; }
            if (Regex.IsMatch(text,"translate")) { translate(); return; };
            if (Regex.IsMatch(text, "i want some images|where can i find some good pictures|suggest me some good pictures|i need some good pictures")) { pictures(); return; }
            if (Regex.IsMatch(text, "i want to go to|how to get to|i want to see the maps|google maps")) { map(); return; }
            if (Regex.IsMatch(text, "football news")) { foot(); return; }
            if (Regex.IsMatch(text,"search")){search();return; }
            if (Regex.IsMatch(text, "nba news|basketball news|the result of nba")) { nba(); return; }
            if (Regex.IsMatch(text, "sport news")) { sport(); return; }
            if (Regex.IsMatch(text, "news")) { news(); return; }
            if (Regex.IsMatch(text, "sing")) { sing(); return; }
            if (Regex.IsMatch(text, "play")) { music(); return; }
            if (Regex.IsMatch(text, "weather")) {weatherer();return;}
            foreach (string s in words.word.Keys)
            {
                if (Regex.IsMatch(text, s))
                {
                    string[] rt;
                    words.word.TryGetValue(s, out rt);
                    TalkWindow.answer = rt[Random(rt.Length)];
                    TalkWindow.extra = null;
                    return;
                }
                else
                {
                    unknownstc();
                }
                
            }
        }

        private void aqi()
        {
            
        }
        private void search()
        {
            text=Regex.Replace(text,"\"","");
            if(Regex.IsMatch(text,"search for")) text=Regex.Replace(text,"search for ","");
            else if(Regex.IsMatch(text,"search")) text=Regex.Replace(text,"search ","");
            TalkWindow.answer="All right.";
            Button b=new Button();
            b.Content="Search for \""+text+"\".";
            b.Click+=(s,e)=>System.Diagnostics.Process.Start("http://www.baidu.com/s?wd="+text);
            TalkWindow.extra = b;
            WebClient client = new WebClient();
            XmlDocument document = new XmlDocument();
            document.LoadXml(client.DownloadString("http://www.baidu.com/s?wd=" + text));
            XmlNodeList result = document.SelectNodes(@"//div[@class='result c-container ']");
            List<string> titles = new List<string>();
            List<string> details = new List<string>();
            List<string> uris = new List<string>();
            foreach (XmlNode div in result)
            {
                XmlNode a = div.SelectSingleNode(@"./h3/a");
                XmlNode d = div.SelectSingleNode(@"./div");
                titles.Add(a.InnerText);
                uris.Add(a.Attributes["href"].InnerText);
                details.Add(d.InnerText);
            }
            List<Label> l = new List<Label>();
            for (int i = 0; i < titles.Count; i++)
            {
                l[i].Content = titles[i] + details[i] + uris[i];
            }
            Grid g =new Grid();
            foreach(Label lb in l){
                g.Children.Add(lb);
            }
            TalkWindow.extra = g;

        }

        private void sport()
        {
            TalkWindow.answer = "You can visit this link for sport news:";
            Button btn = new Button();
            btn.Content = "Go to \"http://bleacherreport.com/\"";
            btn.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            btn.Click += (s, e) => System.Diagnostics.Process.Start("http://bleacherreport.com/");
            TalkWindow.extra = btn;
        }

        private void pictures()
        {
            TalkWindow.answer = "You can visit this link for some nice pictures:";
            Button btn = new Button();
            btn.Content = "Search particular pictures";
            btn.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            btn.Click += (s, e) => System.Diagnostics.Process.Start("http://bleacherreport.com/");
            TalkWindow.extra = btn;
            Button bn = new Button();
            bn.Content = "Some excellent photos";
            bn.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            bn.Click += (s, e) => System.Diagnostics.Process.Start("http://www.lifeofpix.com/");
            TalkWindow.extra = bn;
        }
            //TalkWindow.extra=
        private void nba()
        {
            TalkWindow.answer = "You can visit this link for NBA news:";
            Button bn = new Button();
            bn.Content = "Go to \"http://bleacherreport.com/nba\"";
            bn.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            bn.Click += (s, e) => System.Diagnostics.Process.Start("http://bleacherreport.com/nba");
            TalkWindow.extra = bn;
        }


        private void translate()
        {
            text = Regex.Replace(text, "\"", "");
            if (Regex.IsMatch(text, "translate into")) text = Regex.Replace(text, "translate into ", "");
            else if (Regex.IsMatch(text, "translate")) text = Regex.Replace(text, "translate ", "");
            TalkWindow.answer = "All right.";
            Button b = new Button();
            b.Content = "Translate \"" + text + "\".";
            b.Click += (s, e) => System.Diagnostics.Process.Start("http://translate.google.cn/#en/zh-CN/" + text);
            TalkWindow.extra = b;
        }


        private void buy()
        {
            text = Regex.Replace(text, "\"", "");
            if (Regex.IsMatch(text, "buy me")) text = Regex.Replace(text, "buy me ", "");
            else if (Regex.IsMatch(text, "i want to buy")) text = Regex.Replace(text, "i want to buy ", "");
            TalkWindow.answer = "Here is your order at TaoBao.";
            Button b = new Button();
            b.Content = "RESULT of \"" + text + "\".";
            b.Click += (s, e) => System.Diagnostics.Process.Start("http://s.taobao.com/search?q=" + text);
            TalkWindow.extra = b;
        }

        private void foot()
        {
            TalkWindow.answer = "You can visit this link for football news:";
            Button bn = new Button();
            bn.Content = "Go to \"http://bleacherreport.com/world-football\"";
            bn.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            bn.Click += (s, e) => System.Diagnostics.Process.Start("http://bleacherreport.com/world-football");
            TalkWindow.extra = bn;
        }


        private void map()
        {
            TalkWindow.answer = "You can visit this link for football news:";
            Button bn = new Button();
            bn.Content = "Go to \"http://www.google.cn/maps\"";
            bn.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            bn.Click += (s, e) => System.Diagnostics.Process.Start("http://www.google.cn/maps");
            TalkWindow.extra = bn;
        }
       
        

        private void news()
        {
            HttpWebRequest hwr = WebRequest.Create(new Uri("http://feeds.abcnews.com/abcnews/internationalheadlines")) as HttpWebRequest;
            hwr.Method = "GET";
            XmlDocument xd = new XmlDocument();
            xd.Load(hwr.GetResponse().GetResponseStream());
            XmlNamespaceManager xnm = new XmlNamespaceManager(xd.NameTable);
            xnm.AddNamespace("media","http://search.yahoo.com/mrss/");
            XmlNodeList itemList = xd.GetElementsByTagName("item");
            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Vertical;
            
            for (int i = 0; i < 5; i++)
            {
                XmlNode item = itemList[i];
                news n = new news(item.SelectSingleNode("title").InnerText, item.SelectSingleNode("media:thumbnail[@width='144']", xnm).Attributes["url"].InnerText, item.SelectSingleNode("link").InnerText);
                sp.Children.Add(n);
            }
            TalkWindow.answer = "Here are the news:";
            TalkWindow.extra = sp;
        }

        private void sing(){
            if (Regex.IsMatch(text, "sing a song"))
            {
                Random r = new System.Random();
                String[] s = { "play sing", "play take me to church", "play cheerleader", "play firestone" };
                text = s[r.Next(4) - 1];
                music();
            }
            else
            {
                text = Regex.Replace(text, "sing", "play");
            }
        }
        
        #endregion
        private string declarativestc()
        {
            string rttext = "";
            if (Regex.IsMatch(text, "tell") && Regex.IsMatch(text, "joke"))
            {
                XmlDocument xd = new XmlDocument();
                List<string> jokes = new List<string>();
                xd.Load(@"..\..\Resources\jokes.xml");
                XmlNodeList xnl = xd.GetElementsByTagName("joke");
                foreach (XmlNode xn in xnl)
                {
                    jokes.Add(xn.InnerText);
                }
                rttext = jokes[1];
            }
            return rttext;
        }
        private void unknownstc()
        {
            /*HttpWebRequest hwr = WebRequest.Create("http://www.baidu.com/s?wd=" + text) as HttpWebRequest;
            Stream s1 =hwr.GetResponse().GetResponseStream();
            StreamReader sr =new StreamReader(s1);
            string st = sr.ReadToEnd();
            XmlDocument xd = new XmlDocument();
            xd.Load(hwr.GetResponse().GetResponseStream());
            XmlNodeList xnl = xd.SelectNodes("//h3[@class='t']");
            List<string> titles = new List<string>();
            List<string> links = new List<string>();
            List<string> details = new List<string>();
            List<search> searches = new List<search>(5);
            foreach (XmlNode xn in xnl)
            {
                titles.Add(xn.SelectSingleNode("a").InnerText);
                links.Add(xn.SelectSingleNode("a").Attributes["href"].InnerText);
                details.Add(xn.NextSibling.InnerText);
            }
            for (int i = 0; i < 5; i++)
            {
                searches[i] = new search(titles[i], details[i], links[i]);
            }
            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Vertical;
            foreach (search s in searches)
            {
                sp.Children.Add(s);
            }*/
            TalkWindow.answer = "Sorry,I don't know the answer.";
            Button b = new Button();
            b.Content = "Search for " + text + ".";
            b.Click += b_Click;
            TalkWindow.extra = b;
            
        }

        void b_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            WebBrowser wb = new WebBrowser();
            Panel.SetZIndex(wb, 98);
            wb.Width = 410;
            wb.Height = 300;
            wb.Margin = new System.Windows.Thickness(0, 20, 0, 0);
            Button cb = new Button();
            cb.Content = "Close";
            wb.Source = new Uri("http://www.baidu.com/s?wd=" + text);
            tw.myGrid.Children.Add(wb);
            tw.clb.Visibility = System.Windows.Visibility.Visible;
            tw.clb.Click += (s, e0) => { wb.Dispose(); tw.clb.Visibility = System.Windows.Visibility.Collapsed; };
        }
        #region questionarea
        private string questionstc()
        {
            string rttext = "";

            string f = splited[0];
            switch (f)
            {

                case "are": rttext = are();
                    break;

                case "do": rttext = dowhat();
                    break;
            }
            return rttext;

        }
        private string dowhat()
        {
            string rttext = "";
            if (Regex.IsMatch(text, "you know")) rttext = "Internet,friend. He will tell you everything.";
            return rttext;
        }
        private string are()
        {
            if (Regex.IsMatch(text, "you a robot"))
            {
                string i = "In physical way,I am,but you human may not accept that AI has anamnesis.";
                return i;
            }
            return "Silly fool.";
        }
        public void music()
        {
            
            try
            {
                string songName = text.Replace("play ", ""); //Regex.Match(text, ".+(?= play)").ToString();
                HttpWebRequest hwr1 = WebRequest.Create(new Uri("http://tingapi.ting.baidu.com/v1/restserver/ting?from=webapp_music&method=baidu.ting.search.catalogSug&format=json&callback=&_=" + ((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds).ToString() + "&query=" + songName)) as HttpWebRequest;
                hwr1.Method = "GET";
                TalkWindow.answer = "Try playing the song...";
                Stream st = hwr1.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(st);
                JObject j = JObject.Parse(sr.ReadToEnd());
                JArray ja = JArray.Parse(j["song"].ToString());
                if (ja[0] == null) throw new System.NotImplementedException("Can't find the song.");
                HttpWebRequest hwr2 = WebRequest.Create(new Uri("http://tingapi.ting.baidu.com/v1/restserver/ting?from=webapp_music&method=baidu.ting.song.downWeb&songid=" + ja[0]["songid"].ToString() + "&bit=64&_=" + ((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds).ToString() + "&query=" + songName)) as HttpWebRequest;
                hwr2.Method = "GET";
                StreamReader sr2 = new StreamReader(hwr2.GetResponse().GetResponseStream());
                JObject jo = JObject.Parse(sr2.ReadToEnd());
                string songFile = jo["bitrate"][0]["file_link"].ToString();
                songName = jo["songinfo"]["title"].ToString();
                string songPic = jo["songinfo"]["pic_small"].ToString();
                string singer = jo["songinfo"]["author"].ToString();
                Songs s = new Songs(songFile, songPic, songName, singer,i);
                TalkWindow.extra = s;
                tw.textfield.Children.Remove((System.Windows.UIElement)tw.textfield.FindName("song" + Convert.ToString(i)));
                i++;
            }
            catch (Exception ex)
            {
                TalkWindow.answer = "Can't play the song.Please check your spelling and Internet connection.";
            }                
           
           
        }

        
        #endregion
        private int Random(int a)
        {
            long now = (long)((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds);
            int key = Convert.ToInt32(now % a);

            return key;
        }
        private string introduction(ref string rttext)
        {
            return answers.introduction[Random(answers.introduction.Length)];
        }
        //"特大暴雨", "阵雪", "小雪", "中雪", "大雪", "暴雪","雾", "冻雨", "沙尘暴","小到中雨", "中到大雨","大到暴雨", "暴雨到大暴雨", "大暴雨到特大暴雨", "小到中雪", "中到大雪", "大到暴雪", "浮尘", "扬沙", "强沙尘暴", "霾"
        public void weatherer()
        {
            try{
            ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
            HttpWebRequest hwr = WebRequest.Create("http://apistore.baidu.com/microservice/iplookup?ip=27.17.40.29") as HttpWebRequest;
            hwr.Method = "GET";
            Stream se = hwr.GetResponse().GetResponseStream();
            StreamReader sr = new StreamReader(se);
            JObject j = JObject.Parse(sr.ReadToEnd());

            if ((int)j["errNum"] == 0) city = j["retData"]["city"].ToString();
            //     else throw new MyException(j["errMsg"].ToString());
            IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipa = ipe.AddressList[0];
            ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
            if (!inited)
            {
                wt.Add("晴", "sunny");
                wt.Add("多云", "cloudy");
                wt.Add("阴", "overcast");
                wt.Add("阵雨", "shower");
                wt.Add("雷阵雨", "thundershower");
                wt.Add("雷阵雨伴有冰雹", "thundershower with hail");
                wt.Add("雨夹雪", "rain with snow");
                wt.Add("小雨", "light rain");
                wt.Add("大暴雨", "downpour");
                wt.Add("中雨", "moderate rain");
                wt.Add("大雨", "heavy rain");
                wt.Add("暴雨", "rainstorm");
                wt.Add("特大暴雨", "torrential rain");
                //wt.Add("大暴雨", "downpour");
               // wt.Add("大暴雨", "downpour");
                //wt.Add("大暴雨", "downpour");
                inited = true;
            }
            HttpWebRequest hwr0 = WebRequest.Create("http://apistore.baidu.com/microservice/weather?cityname="+city) as HttpWebRequest;
            hwr0.Method = "GET";
            Stream st = hwr0.GetResponse().GetResponseStream();
            StreamReader sr0 = new StreamReader(st);
            JObject j0 = JObject.Parse(sr0.ReadToEnd());
            string sd = j0["errNum"].ToString();
            if ((int)j["errNum"] == 0)
            {
                string weather;
                wt.TryGetValue(j0["retData"]["weather"].ToString(), out weather);
                TalkWindow.answer = "It's " + weather + " at the moment.";
            }
            //else throw new MyException(j["errMsg"].ToString());
                }
            catch (Exception ex)
            {
                TalkWindow.answer = "Can't get weather.Please check your Internet connection.";
            }
        }
        public enum asking
        {
            name =1,
            city,
            confirm,
        }

    }
}
