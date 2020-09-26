using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Yandex_Cup
{
    class Program
    {
        static Query[] Queries;
        static Document[] Documents;
        static Host[] Hosts;
        static void Main(string[] args)
        {
            Queries = ReadQueries();
            Documents = ReadDocuments();
            Hosts = ReadHosts();

            var Groups = Hosts.GroupBy(item => item.HostID);
            List<Document> DistinctDocs = new List<Document>();
            foreach (var group in Groups)
            {
                var temp = group.ToArray();
                var Docs = GetDocsFromURLs(temp.Select(item => item.DocumentURL).ToArray()).ToArray();
                DistinctDocs.Add(Docs.Where(item => item.Relevance == Docs.Max(item => item.Relevance)).ToArray()[0]);
            }

            var DocGroups = DistinctDocs.GroupBy(item => item.QueryID).ToArray();
            var Max = new
            {
                Query = "",
                Found = 0.0
            };
            foreach (var group in DocGroups)
            {
                var temp = pFound(group);
                if (temp > Max.Found)
                {
                    Max = new
                    {
                        Query = group.Key,
                        Found = temp
                    };
                }
            }
            Console.WriteLine(Max.Query);

        }

        #region 1

        
        public class Order
        {
            public string Spectacle { get; set; }
            public string PhoneNumber { get; set; }
        }

        public static List<Order> ReadCsv(string Path)
        {
            string[] RawData = File.ReadAllLines(Path);
            string[][] Data = new string[RawData.Length][];
            List<Order> Results = new List<Order>();

            for (int i = 0; i < Data.GetLength(0); i++)
            {
                Data[i] = RawData[i].Split(',');
                Results.Add(new Order()
                {
                    Spectacle = Data[i][0],
                    PhoneNumber = Data[i][1]
                });
            }
            return Results;
        }

        public static void MakePhonesSameFormat(List<Order> Orders)
        {
            Regex Query = new Regex(@".*(\d).*(\d{3}).*(\d{3}).*(\d{2}).*(\d{2})");
            foreach (var order in Orders)
            {
                var match = Query.Match(order.PhoneNumber);
                order.PhoneNumber = $"{match.Groups[1]}{match.Groups[2]}{match.Groups[3]}{match.Groups[4]}{match.Groups[5]}";
            }
        }

        public static int FindMaxUniqueNumbers(List<Order> Orders)
        {
            var Groups = Orders.GroupBy(item => item.Spectacle).ToArray();
            int Max = 0;
            for (int i = 0; i < Groups.Count(); ++i)
            {
                var temp = Groups[i].ToArray().Distinct().ToArray();
                Max = temp.Length > Max ? temp.Length : Max;
            }
            return Max;
        }
        #endregion

        public class Query
        {
            public string ID { get; set; }
            public string Text { get; set; }
        }

        public class Document
        {
            public string QueryID { get; set; }
            public string URL { get; set; }
            public string Relevance { get; set; }
        }

        public class Host : IEquatable<Host>
        {
            public string HostID { get; set; }
            public string DocumentURL { get; set; }

            public bool Equals([AllowNull] Host other)
            {
                return other.HostID == HostID;
            }
        }

        public static Query[] ReadQueries()
        {
            string[] RawData = File.ReadAllLines(@"D:\qid_query.tsv");
            string[][] Data = new string[RawData.Length][];
            Query[] Results = new Query[Data.GetLength(0)];
            for (int i = 0; i < RawData.Length; ++i)
            {
                Results[i] = new Query();
                Data[i] = RawData[i].Split('\t');
                Results[i].ID = Data[i][0];
                Results[i].Text = Data[i][1];
            }
            return Results;
        }

        public static Document[] ReadDocuments()
        {
            string[] RawData = File.ReadAllLines(@"D:\qid_url_rating.tsv");
            string[][] Data = new string[RawData.Length][];
            Document[] Results = new Document[Data.GetLength(0)];
            for (int i = 0; i < RawData.Length; ++i)
            {
                Results[i] = new Document();
                Data[i] = RawData[i].Split('\t');
                Results[i].QueryID = Data[i][0];
                Results[i].URL = Data[i][1];
                Results[i].Relevance = Data[i][2];
            }
            return Results;
        }

        public static Host[] ReadHosts()
        {
            string[] RawData = File.ReadAllLines(@"D:\hostid_url.tsv");
            string[][] Data = new string[RawData.Length][];
            Host[] Results = new Host[Data.GetLength(0)];
            for (int i = 0; i < RawData.Length; ++i)
            {
                Results[i] = new Host();
                Data[i] = RawData[i].Split('\t');
                Results[i].HostID = Data[i][0];
                Results[i].DocumentURL = Data[i][1];
            }
            return Results;
        }

        public static IEnumerable<Document> GetDocsFromURLs(string[] URLs)
        {
            foreach (var url in URLs)
            {
                yield return Documents.Where(item => item.URL == url).ElementAt(0);
            }
        }

        public static void PrintMaxpFound()
        {

        }

        public static double pFound(IGrouping<string, Document> group)
        {
            var Query = group.Key;
            var Docs = group.ToArray().OrderByDescending(item => item.Relevance).ToArray().Take(10).ToArray();

            double Sum = 0;
            for (int i = 0; i < Docs.Length; i++)
            {
                Sum += pLook(Docs, i);
            }
            return Sum;
        }

        public static double pLook(Document[] Docs, int Index)
        {
            if (Index == 1) return 1;
            return pLook(Docs, Index - 1) * (1 - Convert.ToInt32(Docs[Index - 1].Relevance)) * (1 - 0.15);
        }
    }
}
