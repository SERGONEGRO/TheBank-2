using Microsoft.EntityFrameworkCore;
using TheBank2.Model;
using MyLib;

namespace TheBank2.Data
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<User<int>> Users { get; set; }
        public DbSet<Department<int>> Departments { get; set; }
        public DbSet<Position<int>> Positions { get; set; }
        public DbSet<Client<int>> Clients { get; set; }
        public DbSet<Deposit<int>> Deposits { get; set; }

        /// <summary>
        /// конструктор
        /// </summary>
        public ApplicationContext()
        {
            Database.EnsureCreated();  //Если нет дб, то создаем ее
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TheBank2Db;Trusted_Connection=True;");
        }
    }
}
