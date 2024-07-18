using Agendamentos.Entidade.DTO;
using Agendamentos.Entidade.Entidades;
using Agendamentos.Repositorio.Interface.IRepositorios;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Agendamentos.Repositorio.Repositorios
{
    public class PacienteRepositorio : RepositorioBase<Paciente>, IPacienteRepositorio
    {
        public PacienteRepositorio(Contexto contexto) : base(contexto) { }

        public Task<List<PacienteDTO>> ListarPacientes(string nome)
        {
            var query = EntitySet.Where(pc => nome.Contains(pc.dsc_nome))
                                 .OrderBy(pc => pc.dsc_nome)
                                 .Distinct()
                                 .Select(pc => new PacienteDTO
                                 {
                                     dsc_nome = pc.dsc_nome,
                                     dat_nascimento = pc.dat_nascimento
                                 });
            return query.ToListAsync();
        }

        public Task<Paciente> ObterPc(string nome)
        {
            var query = EntitySet.Where(e => e.dsc_nome == nome);

            return query.FirstOrDefaultAsync();
        }
    }
}
