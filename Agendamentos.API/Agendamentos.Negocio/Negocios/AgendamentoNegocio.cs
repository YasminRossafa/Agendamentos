using Agendamentos.Entidade.DTO;
using Agendamentos.Entidade.Entidades;
using Agendamentos.Entidade.Models;
using Agendamentos.Negocio.Interface.INegocios;
using Agendamentos.Repositorio.Interface.IAgendamentoRepositorio;
using Agendamentos.Repositorio.Interface.IRepositorios;
using Agendamentos.Utilitarios.Exceptions;
using Agendamentos.Utilitarios.Messages;
using log4net;

namespace Agendamentos.Negocio.Negocios
{
    public class AgendamentoNegocio : IAgendamentoNegocio
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(AgendamentoNegocio)); //para usar os logs

        private readonly IAgendamentoRepositorio _agendamentoRepositorio;
        private readonly IPacienteRepositorio _pacienteRepositorio;
        public AgendamentoNegocio(IAgendamentoRepositorio agendamentoRepositorio, IPacienteRepositorio pacienteRepositorio) { 
            _agendamentoRepositorio = agendamentoRepositorio;
            _pacienteRepositorio = pacienteRepositorio;
        }

        public async Task<List<AgendamentoDTO>> AlterarAgendamentos(DateTime dia, TimeSpan hora, string status)
        {
            var agExistente = await _agendamentoRepositorio.ObterAg(dia, hora); //encontra o ag na lista
            
            if (agExistente.Count == 0) // se não for nulo, altera
            {
                _log.InfoFormat("Esse agendamento não existe na base");
                throw new BusinessException(string.Format(BusinessMessages.AgendamentoInexistente, "ag"));
            }

            foreach (var ag in agExistente) {
                ag.dsc_status = status;
                await _agendamentoRepositorio.Atualizar(ag);
            }

            _log.InfoFormat("Agendamento atualizado!");
            return await _agendamentoRepositorio.ListarTudo(); 
        }

        public async Task<List<AgendamentoDTO>> InserirAgendamentos(CadastroAgendamentoModel agendamento)
        {
            var agExistente = await _agendamentoRepositorio.ObterAg(agendamento.dat_agendamento, agendamento.hor_agendamento);

            var paciente = await _pacienteRepositorio.ObterPc(agendamento.pc.dsc_nome);

            if (agExistente.Count >= 2)
                throw new BusinessException(string.Format(BusinessMessages.NumeroMaximo));

            if (paciente == null) //se o paciente não existir, cria um novo
            {
                paciente = CriarPaciente(agendamento.pc);

                await _pacienteRepositorio.Inserir(paciente);

                _log.InfoFormat("Novo paciente inserido.");
            }

            var ag = CriarAgendamento(agendamento, paciente.Id); //cria agendamento com o paciente

            await _agendamentoRepositorio.Inserir(ag);

            _log.InfoFormat("Agendamento registrado!");

            return await _agendamentoRepositorio.ListarTudo();
        }

        private static Paciente CriarPaciente(CadastroPacienteModel paciente)
        {
            var pc = new Paciente
            {
                dsc_nome = paciente.dsc_nome,
                dat_nascimento = paciente.dat_nascimento,
            };
            return pc;
        }

        private static Agendamento CriarAgendamento(CadastroAgendamentoModel agendamento, int id)
        {
            var ag = new Agendamento
            {
                id_paciente = id,
                dat_agendamento = agendamento.dat_agendamento,
                hor_agendamento = agendamento.hor_agendamento,
                dsc_status = "Agendado",
            };
            return ag;
        }

        public async Task<List<AgendamentoDTO>> ListarAgendamentos(List<DateTime> agendamentos)
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
