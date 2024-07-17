

using Agendamentos.Entidade.DTO;
using Agendamentos.Entidade.Models;

namespace Agendamentos.Negocio.Interface.INegocios
{
    public interface IAgendamentoNegocio
    {
        Task<List<AgendamentoDTO>> ListarAgendamentos(List<int> agendamentos);
        Task<List<AgendamentoDTO>> InserirAgendamentos(CadastroAgendamentoModel agendamento);
        Task<List<AgendamentoDTO>> DeletarAgendamentos(int id);
        Task<List<AgendamentoDTO>> AlterarAgendamentos(int idAgendamento, CadastroAgendamentoModel novoAg);
    }
}
