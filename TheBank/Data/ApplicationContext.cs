using Microsoft.EntityFrameworkCore;
using TheBank2.Model;

namespace TheBank2.Data
{
    class ApplicationContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Deposit> Deposits { get; set; }

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
