


using ApiCrud.Estudantes;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Estudante> Estudantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            {
                optionsBuilder.UseSqlite(connectionString: "Data Source=Banco.sqlite");
                optionsBuilder.LogTo(Console.WriteLine);
                

                base.OnConfiguring(optionsBuilder);
            }
        }
    }
}
