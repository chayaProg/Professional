using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Intarfaces;

namespace DataContext
{
    public class Class1 : DbContext, IContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Professional> Professionals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Area> Areas { get; set; }
        //ככה כותבים?
        public async Task save()
        {
            SaveChangesAsync(); 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(DESKTOP-FVA15IL)\\MSSQLLocalDB;database=ProfessionalDataBase;trusted_connection=true");
        }
    }
}