using Agendamentos.Entidade.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agendamentos.Repositorio.Map
{
    public class AgendamentoMap : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("tb_agendamento");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("id_agendamento")
                   .IsRequired()
                   .ValueGeneratedOnAdd();

           builder.Property(e => e.id_paciente)
                   .HasColumnName("id_paciente")
                   .IsRequired();

            builder.Property(e => e.dat_agendamento)
                   .HasColumnName("dat_agendamento")
                   .HasColumnType("date")
                   .IsRequired();

            builder.Property(e => e.hor_agendamento)
                   .HasColumnName("hor_agendamento")
                   .HasColumnType("time")
                   .IsRequired();

            builder.Property(e => e.dat_criacao)
                   .HasColumnName("dat_criacao")
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(e => e.dsc_status)
                   .HasColumnName("dsc_status")
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

            // Configurar o relacionamento com Paciente
            builder.HasOne(a => a.Paciente)
                   .WithMany(p => p.Agendamentos)
                   .HasForeignKey(a => a.id_paciente)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
