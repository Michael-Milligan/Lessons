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

            
        }
    }
}
