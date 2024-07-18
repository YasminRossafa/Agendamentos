using Agendamentos.Entidade.DTO;
using Agendamentos.Entidade.Entidades;
using Agendamentos.Repositorio.Interface.IAgendamentoRepositorio;
using Microsoft.EntityFrameworkCore;

namespace Agendamentos.Repositorio.Repositorios
{
    public class AgendamentoRepositorio : RepositorioBase<Agendamento>, IAgendamentoRepositorio
    {
        public AgendamentoRepositorio(Contexto contexto) : base(contexto) { }

        public Task<List<AgendamentoDTO>> ListarAgendamentos(List<DateTime> agendamentos)
        {
            var query = EntitySet.Include(ag => ag.Paciente)
                                 .Where(ag => agendamentos.Contains(ag.dat_agendamento))
                                 .OrderBy(ag => ag.dat_agendamento)
                                 .Distinct()
                                 .Select(ag => new AgendamentoDTO
                                 {
                                     dat_agendamento = ag.dat_agendamento,
                                     hor_agendamento = ag.hor_agendamento,
                                     dsc_status = ag.dsc_status,
                                     dsc_nome_paciente = ag.Paciente.dsc_nome
                                 });
            return query.ToListAsync();
        }

        public Task<List<AgendamentoDTO>> ListarTudo()
        {
            var query = EntitySet.Include(ag => ag.Paciente)
                                 .OrderBy(ag => ag.dat_agendamento)
                                 .Distinct()
                                 .Select(ag => new AgendamentoDTO
                                 {
                                     dat_agendamento = ag.dat_agendamento,
                                     hor_agendamento = ag.hor_agendamento,
                                     dsc_status = ag.dsc_status,
                                     dsc_nome_paciente = ag.Paciente.dsc_nome
                                 });
            return query.ToListAsync();
        }

        public Task<List<Agendamento>> ObterAg(DateTime dia, TimeSpan hora)
        {
            var query = EntitySet.Where(e => e.dat_agendamento == dia && e.hor_agendamento == hora);

            return query.ToListAsync();
        }
    }
}
