using Agendamentos.Entidade.DTO;
using Agendamentos.Entidade.Entidades;
using Agendamentos.Repositorio.Interface.IAgendamentoRepositorio;

namespace Agendamentos.Repositorio.Repositorios
{
    public class AgendamentoRepositorio : IAgendamentoRepositorio
    {
        private static List<Agendamento> AgendamentosMarcados { get; set; } = new() { new("Ag1"), new("Ag2"), new("Ag3") };

        public void Deletar(Agendamento agendamento)
        {
            AgendamentosMarcados.Remove(agendamento);
        }

        public void Inserir(Agendamento agendamento)
        {
            AgendamentosMarcados.Add(agendamento);
        }

        public List<AgendamentoDTO> ListarAgendamentos(List<string> agendamentos)
        {                                                               //contém titulo maiúsculo
            return AgendamentosMarcados.Where(agendamento => agendamentos.Contains(agendamento.Titulo.ToUpper()))
                                       .OrderBy(agendamento => agendamento.Titulo)
                                       .Distinct()
                                       .Select(agendamento => new AgendamentoDTO
                                       {
                                           Titulo = agendamento.Titulo
                                       })
                                       .ToList();
        }
        public List<AgendamentoDTO> ListarTudo()
        {
            return AgendamentosMarcados.OrderBy(agendamento => agendamento.Titulo)
                                       .Distinct()
                                       .Select(agendamento => new AgendamentoDTO
                                       {
                                           Titulo = agendamento.Titulo
                                       })
                                       .ToList();
        }

        public Agendamento? ObterAg(string tituloAg)
        {
            return AgendamentosMarcados.Find(e => e.Titulo.ToLower() == tituloAg.ToLower());
        }
    }
}
