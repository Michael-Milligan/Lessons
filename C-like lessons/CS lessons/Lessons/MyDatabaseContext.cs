using System;
using System.Data.Entity;

namespace Lessons
{
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext() : base("DBConnectionString")
        {

        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}
