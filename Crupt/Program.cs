using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Crupt
{
    public delegate void ExampleCallback(string text);
    public class cruptum
    {

    
        public string text = "";
        public string key = "";

        private ExampleCallback callback;
        public cruptum(ExampleCallback callbackDelegate)
        {
            callback = callbackDelegate;
        }
        public void Crupt()//object a)
        {
            //cruptum tmp = (cruptum)a;
            //List<string> text = new List<string>();
            //for (int i = 0; i < tmp.text.Length; i+=tmp.key.Length)
            //{
            //    char[] textTMP = new char[tmp.key.Length];
            //    tmp.text.CopyTo(i, textTMP, 0, tmp.key.Length);
            //    text.Add(textTMP.ToString());
            //}
            //foreach (var item in text)
            //{
            //    crupto_text += (string)(item.ToString() ^ tmp.key);
            //}
            string crupto_text = new string(text.Select((c, index) => (char)(c ^ key[index % key.Length])).ToArray());
            string decrupt_tect = new string(crupto_text.Select((c, index) => (char)(c ^ key[index % key.Length])).ToArray());
            Console.WriteLine(crupto_text);
            //return crupto_text;
            string[] result = { $"text -> {text}", $"key -> {key}", $"encrupt text -> {crupto_text}", $"decrupt text -> {decrupt_tect}" };
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\shpak_d\Documents\1.txt"))
            {
                foreach (string line in result)
                {
                    file.WriteLine(line);   
                }
            }
            callback?.Invoke("Complete");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ExampleCallback myCallBack = new ExampleCallback(ResultCallback);
            cruptum inCrupt = new cruptum(myCallBack);
            Console.WriteLine("enter pleas text");
            inCrupt.text = Console.ReadLine();
            Console.WriteLine("enter pleas key");
            inCrupt.key = Console.ReadLine();
            //inCrupt.text = Crupt(inCrupt);
            Thread t = new Thread(inCrupt.Crupt);
            t.Start();
            //inCrupt.Crupt();
            Console.ReadKey();
        }

        public static void ResultCallback(string text)
        {
            Console.WriteLine(text);
            
        }
    }
}
