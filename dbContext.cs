using ghinelli.johan._5h.Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

    public class dbContext : DbContext
    {
        private readonly DbContextOptions? _options;
        public dbContext(){}

        protected override void 
                OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite("Data Source=database.db");

        public DbSet<Utente> Utenti { get ; set; }
        public DbSet<Auto> Auto { get; set; }
}
