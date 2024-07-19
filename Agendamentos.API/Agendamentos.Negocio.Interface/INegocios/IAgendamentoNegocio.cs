using Agendamentos.Entidade.DTO;
using Agendamentos.Entidade.Models;

namespace Agendamentos.Negocio.Interface.INegocios
{
    public interface IAgendamentoNegocio
    {
        Task<List<AgendamentoDTO>> ListarAgendamentos(List<DateTime> agendamentos);
        Task<List<AgendamentoDTO>> InserirAgendamentos(CadastroAgendamentoModel agendamento);
        Task<List<AgendamentoDTO>> DeletarAgendamentos(DateTime dia, TimeSpan hora);
        Task<List<AgendamentoDTO>> AlterarAgendamentos(DateTime dia, TimeSpan hora, string status);
    }
}
