using Microsoft.EntityFrameworkCore;

namespace api_rte_technical_evaluation.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Unidade> Unidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasIndex(u => u.Login).IsUnique();
            modelBuilder.Entity<Colaborador>()
                .HasOne(c => c.Unidade)
                .WithMany()
                .HasForeignKey(c => c.UnidadeId);

            modelBuilder.Entity<Colaborador>()
                .HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.UsuarioId);
        }
    }

}
