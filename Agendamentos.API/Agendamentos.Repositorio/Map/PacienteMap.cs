using Agendamentos.Entidade.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agendamentos.Repositorio.Map
{
    public class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("tb_paciente");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("id_paciente")
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.dat_criacao)
                   .HasColumnName("dat_criacao")
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(e => e.dat_nascimento)
                   .HasColumnName("dat_nascimento")
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(e => e.dsc_nome)
                    .HasColumnName("dsc_nome")
                    .IsRequired()
                    .IsUnicode(false);
        }
    }
}
