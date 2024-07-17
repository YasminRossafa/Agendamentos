using Agendamentos.Entidade.DTO;
using Agendamentos.Entidade.Entidades;
using Agendamentos.Repositorio.Interface.IRepositorios;

namespace Agendamentos.Repositorio.Interface.IAgendamentoRepositorio
{
    public interface IAgendamentoRepositorio : IRepositorioBase<Agendamento>
    {
        Task<List<AgendamentoDTO>> ListarAgendamentos(List<int> agendamentos);
        Task<List<AgendamentoDTO>> ListarTudo();
        Task<Agendamento> ObterAg(int id);
    }
}
