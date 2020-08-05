using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace Network_Usage
{
    class Program
    {
        static void Main()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://www.profinance.ru/currency_eur.asp");
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            string Html;
            using (var Content = webResponse.GetResponseStream())
            {
                using (var Reader = new StreamReader(Content))
                {
                    Html = Reader.ReadToEnd();
                }
            }
            Regex Query = new Regex(@"<td class=cell align=center colspan=.2.><font color=.Red.><b>(\d{2}\.\d{4})");
            var Matches = Query.Matches(Html);
            Console.WriteLine(Matches[0].Groups[1]);
        }
    }
}
