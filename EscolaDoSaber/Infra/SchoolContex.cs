using EscolaDoSaber.Model;
using Microsoft.EntityFrameworkCore;

namespace EscolaDoSaber.Infra
{
    public class SchoolContex : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        private string dbString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EscolaDoSaber;" +
            "Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;" +
            "Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(dbString).UseLazyLoadingProxies();
        }
    }
}
