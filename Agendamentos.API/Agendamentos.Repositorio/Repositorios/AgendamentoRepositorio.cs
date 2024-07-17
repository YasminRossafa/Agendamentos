using Agendamentos.Entidade.DTO;
using Agendamentos.Entidade.Entidades;
using Agendamentos.Repositorio.Interface.IAgendamentoRepositorio;
using Microsoft.EntityFrameworkCore;

namespace Agendamentos.Repositorio.Repositorios
{
    public class AgendamentoRepositorio : RepositorioBase<Agendamento>, IAgendamentoRepositorio
    {
        public AgendamentoRepositorio(Contexto contexto) : base(contexto) { }

        public Task<List<AgendamentoDTO>> ListarAgendamentos(List<int> agendamentos)
        {
            var query = EntitySet.Where(ag => agendamentos.Contains(ag.Id))
                                 .OrderBy(ag => ag.dat_agendamento)
                                 .Distinct()
                                 .Select(ag => new AgendamentoDTO
                                 {
                                     dat_agendamento = ag.dat_agendamento,
                                     hor_agendamento = ag.hor_agendamento,
                                     dsc_status = ag.dsc_status
                                 });
            return query.ToListAsync();
        }

        public Task<List<AgendamentoDTO>> ListarTudo()
        {
            var query = EntitySet.OrderBy(ag => ag.dat_agendamento)
                                 .Distinct()
                                 .Select(ag => new AgendamentoDTO
                                 {
                                     dat_agendamento = ag.dat_agendamento,
                                     hor_agendamento = ag.hor_agendamento,
                                     dsc_status = ag.dsc_status
                                 });
            return query.ToListAsync();
        }

        public Task<Agendamento> ObterAg(int id)
        {

            return ObterPorId(id);
            //var query = EntitySet.Include(e => e.Id)
            //                     .Where(e => e.Id == id);
            //return query.FirstOrDefaultAsync();
        }
    }
}
