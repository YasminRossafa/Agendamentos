

using Agendamentos.Entidade.DTO;
using Agendamentos.Entidade.Entidades;

namespace Agendamentos.Repositorio.Interface.IAgendamentoRepositorio
{
    public interface IAgendamentoRepositorio
    {
        List<AgendamentoDTO> ListarAgendamentos(List<string> agendamentos);
        List<AgendamentoDTO> ListarTudo();
        void Inserir(Agendamento agendamento);
        void Deletar(Agendamento agendamento);
        Agendamento? ObterAg(string tituloAg);
    }
}
