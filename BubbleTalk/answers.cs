using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SideTalk
{
    class answers
    {
        public static string[] dWords = { "Don't be so rude." };
        public static string[] chinese = { "Be international,chief.", "I love Chinese,but I was made in English.","No Chinese, please." };
        public static string[] unknown = { "Sorry, but I didn't get you.", "I beg your pardon?", "Please check your grammar and punctuation." };
        public static string[] introduction = { "I'm Sidetalk.", "My name is SideTalk, the premium voice assistant", "This is SideTalk speaking.", "I'm SideTalk, glad to meet you." };
        public static string[] robot = { "In physical way,I am,but you human may not accept that AI has anamnesis." };
        public static string[] maker = { "That's George." };
        public static string[] ntmy = { "Nice to meet you,too." };
        public static string[] hi = { "Hello,"+TalkWindow.name +" ."};
        public static string[] howydo = { "Why so serious?" };
        public static string[] nfriends = { "You made me so sad.I need time crying." };
        public static string[] really = { "Certainly.Everybody knows that.","Of course,That's not a secret.","I'm going to say\"Yes\"." };
        public static string[] bye = { "Bye." };
        public static string[] no = { "Oh, I see." };
        
        public static string[] secret = { "If i have,say\"i love you\"to me,then i'll tell you. " };
        public static Dictionary<string,string[]> dict= new Dictionary<string,string[]>();
        public static bool inited = false;
        public static void init() {
            if (inited) return;
            inited = true;
        }
    }
}
