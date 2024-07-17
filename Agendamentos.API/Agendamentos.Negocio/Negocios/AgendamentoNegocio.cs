using Agendamentos.Entidade.DTO;
using Agendamentos.Entidade.Entidades;
using Agendamentos.Entidade.Models;
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

        public async Task<List<AgendamentoDTO>> AlterarAgendamentos(int idAgendamento, CadastroAgendamentoModel novoAg)
        {
            var ag = await _agendamentoRepositorio.ObterAg(idAgendamento); //encontra o ag na lista
            
            if (ag != null) // se não for nulo, altera
            {
                ag.dsc_status = novoAg.dsc_status;
                ag.dat_agendamento = novoAg.dat_agendamento;
                ag.hor_agendamento = novoAg.hor_agendamento;
                await _agendamentoRepositorio.Atualizar(ag);
                _log.InfoFormat("Agendamento atualizado!");
            }
            else
            {
                _log.InfoFormat("Esse agendamento não existe na base");
                throw new BusinessException(string.Format(BusinessMessages.AgendamentoInexistente, "ag"));
            }
            return await _agendamentoRepositorio.ListarTudo(); 
        }

        public async Task<List<AgendamentoDTO>> DeletarAgendamentos(int agendamento)
        {
            var ag = await _agendamentoRepositorio.ObterAg(agendamento);
            if(ag != null)
            {
                await _agendamentoRepositorio.Deletar(ag);
                _log.InfoFormat("Agendamento deletado.");
            }
            else
            {
                _log.InfoFormat("Esse agendamento não existe na base");
                throw new BusinessException(string.Format(BusinessMessages.AgendamentoInexistente, "ag"));
            }
            return await _agendamentoRepositorio.ListarTudo();
        }

        public async Task<List<AgendamentoDTO>> InserirAgendamentos(CadastroAgendamentoModel agendamento)
        {
            var ag = await _agendamentoRepositorio.ObterAg(agendamento.id_agendamento);
            if (ag != null)
                throw new BusinessException(string.Format(BusinessMessages.AgendamentoExistente, "ag"));
            
            ag = CriarAgendamento(agendamento);

            await _agendamentoRepositorio.Inserir(ag);

            _log.InfoFormat("Agendamento registrado!");
            return await _agendamentoRepositorio.ListarTudo();
        }

        private static Agendamento CriarAgendamento(CadastroAgendamentoModel agendamento)
        {
            var ag = new Agendamento
            {
                id_paciente = agendamento.id_paciente,
                dat_agendamento = agendamento.dat_agendamento,
                hor_agendamento = agendamento.hor_agendamento,
                dsc_status = agendamento.dsc_status,
                dat_criacao = agendamento.dat_criacao,
            };
            return ag;
        }

        public async Task<List<AgendamentoDTO>> ListarAgendamentos(List<int> agendamentos)
        {
            if (agendamentos == null) //se não receber nada, lista todos os agendamentos
                return await _agendamentoRepositorio.ListarTudo();
            else
            {
                agendamentos = agendamentos.Select(e => e)
                                           .ToList();
                return await _agendamentoRepositorio.ListarAgendamentos(agendamentos);
            }
        }
    }
}
