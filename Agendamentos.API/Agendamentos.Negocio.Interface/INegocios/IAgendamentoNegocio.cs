

using Agendamentos.Entidade.DTO;

namespace Agendamentos.Negocio.Interface.INegocios
{
    public interface IAgendamentoNegocio
    {
        List<AgendamentoDTO> ListarAgendamentos(List<string> agendamentos);
        List<AgendamentoDTO> InserirAgendamentos(string agendamento);
        List<AgendamentoDTO> DeletarAgendamentos(string agendamento);
        List<AgendamentoDTO> AlterarAgendamentos(string agendamento, string novoAg);
    }
}
