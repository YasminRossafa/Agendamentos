using Agendamentos.Entidade.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Agendamentos.Repositorio
{
    public class Contexto : DbContext
    {
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Agendamento> Pacientes { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Contexto).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
