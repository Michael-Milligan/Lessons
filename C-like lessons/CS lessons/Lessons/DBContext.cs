using System.Data.Entity;

namespace Lessons
{
    class DBContext : DbContext
    {
        public DBContext():base("DBConnectionString")
        {

        }

        public DbSet<Country> Country { get; set; }
        public DbSet<Tank> Tank { get; set; }

    }
}
