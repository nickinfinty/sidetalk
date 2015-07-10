using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace SideTalk
{
    
    public class user
    {
        private bool isMale;
        private string name="";
        internal string city;
        public string Name
        {
            get { return name; }
            set { if (System.Text.RegularExpressions.Regex.IsMatch(value, "")) name = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(value); }
        }
        public bool IsMale { get { return isMale; } set { isMale = value; } }
        
        public user()
        {
            
            //if (this.name == "") throw new MyException("Please enter a valid name.");
            /*string ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
            HttpWebRequest hwr = WebRequest.Create("http://apistore.baidu.com/microservice/iplookup?ip=" + ip) as HttpWebRequest;
            hwr.Method = "GET";
            JsonReader jr = new JsonTextReader(new StreamReader(hwr.GetResponse().GetResponseStream()));
            JObject j = JObject.Parse(jr.ReadAsString());
            if ((int)j["errNum"] == 0) city = j["retData"]["city"].ToString();
            else throw new MyException(j["errMsg"].ToString());*/
        }
        
    }
}
