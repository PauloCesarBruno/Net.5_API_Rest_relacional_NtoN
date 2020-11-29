using EFCoreWebAPI.EFCoreWebAPIDomain.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWebAPI.EFCoreWebAPIDomain.Data
{
    public class DataCursoContext  : DbContext
    {
        public DataCursoContext(DbContextOptions<DataCursoContext> options)
            : base(options)
        {
        }

        public DbSet <Aluno> Alunos { get; set; }
        public DbSet <Curso> Cursos { get; set; }
        public DbSet <Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-PPP09CP;Database=Curso;User ID=sa;Password=Paradoxo22");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>()
                .HasKey(c => new { c.AlunoId });
        }

    }             
}