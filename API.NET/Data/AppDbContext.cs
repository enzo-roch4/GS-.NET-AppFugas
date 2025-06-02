using API.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace API.NET.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<PontoRota> PontoRota { get; set; }  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .ToTable("USUARIO", schema: "RM553643");

            modelBuilder.Entity<PontoRota>()
                .ToTable("PONTO_ROTA", schema: "RM553643");

        }
    }
}
