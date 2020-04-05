using System;
using System.Collections.Generic;

namespace Lessons
{
    class Program
    {
        static void Main()
        {
            using (var Context = new MyDatabaseContext())
            {
                #region groups
                Group group1 = new Group()
                {
                    Name = "Rammstein",
                    BeginYear = 1994
                };

                Context.Groups.Add(group1);

                Group group2 = new Group()
                {
                    Name = "Linkin Park",
                    BeginYear = 1996
                };

                Context.Groups.Add(group2);
                Context.SaveChanges();
                #endregion

                var Songs = new List<Song>
                {
                    new Song() {Name = "In the end", GroupID = group2.ID},
                    new Song() {Name = "Numb", GroupID = group2.ID},
                    new Song() {Name = "Mutter", GroupID = group1.ID}
                };

                Context.Songs.AddRange(Songs);
                Context.SaveChanges();

                Console.WriteLine($"ID: {group2.ID}, Name: {group2.Name},  year: {group2.BeginYear}");
            }
        }
    }
}
