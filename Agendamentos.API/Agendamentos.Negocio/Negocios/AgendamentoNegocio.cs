using Agendamentos.Entidade.DTO;
using Agendamentos.Entidade.Entidades;
using Agendamentos.Negocio.Interface.INegocios;
using Agendamentos.Repositorio.Interface.IAgendamentoRepositorio;
using Agendamentos.Utilitarios.Exceptions;
using Agendamentos.Utilitarios.Messages;
using log4net;

namespace Agendamentos.Negocio.Negocios
{
    public class AgendamentoNegocio : IAgendamentoNegocio
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(AgendamentoNegocio)); //para usar os logs

        private readonly IAgendamentoRepositorio _agendamentoRepositorio;
        public AgendamentoNegocio(IAgendamentoRepositorio agendamentoRepositorio) { 
            _agendamentoRepositorio = agendamentoRepositorio;
        }

        public List<AgendamentoDTO> AlterarAgendamentos(string agendamento, string novoAg)
        {
            var ag = _agendamentoRepositorio.ObterAg(agendamento); //encontra o ag na lista
            if (ag != null) // se não for nulo, altera
            {
                ag.Titulo = novoAg;
                _log.InfoFormat("Agendamento atualizado!");
            }
            else
            {
                _log.InfoFormat("Esse agendamento não existe na base");
                throw new BusinessException(string.Format(BusinessMessages.AgendamentoInexistente));
            }
            return _agendamentoRepositorio.ListarTudo(); 
        }

        public List<AgendamentoDTO> DeletarAgendamentos(string agendamento)
        {
            var ag = _agendamentoRepositorio.ObterAg(agendamento);
            if(ag != null)
            {
                _agendamentoRepositorio.Deletar(ag);
                _log.InfoFormat("Agendamento deletado.");
            }
            else
            {
                _log.InfoFormat("Esse agendamento não existe na base");
                throw new BusinessException(string.Format(BusinessMessages.AgendamentoInexistente));
            }
            return _agendamentoRepositorio.ListarTudo();
        }

        public List<AgendamentoDTO> InserirAgendamentos(string agendamento)
        {
            var ag = _agendamentoRepositorio.ObterAg(agendamento);
            ag = new Agendamento(agendamento);
            _agendamentoRepositorio.Inserir(ag);
            _log.InfoFormat("Agendamento registrado!");
            return _agendamentoRepositorio.ListarTudo();
        }

        public List<AgendamentoDTO> ListarAgendamentos(List<string> agendamentos)
        {
            if (agendamentos == null) //se não receber nada, lista todos os agendamentos
                return _agendamentoRepositorio.ListarTudo();
            else
            {
                agendamentos = agendamentos.Select(e => e.ToUpper())
                                           .ToList();
                return _agendamentoRepositorio.ListarAgendamentos(agendamentos);
            }
        }
    }
}
