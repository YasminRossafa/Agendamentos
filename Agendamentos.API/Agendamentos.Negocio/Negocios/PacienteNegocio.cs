using Agendamentos.Entidade.DTO;
using Agendamentos.Entidade.Entidades;
using Agendamentos.Entidade.Models;
using Agendamentos.Negocio.Interface.INegocios;
using Agendamentos.Repositorio.Interface.IRepositorios;
using Agendamentos.Utilitarios.Exceptions;
using Agendamentos.Utilitarios.Messages;
using log4net;

namespace Agendamentos.Negocio.Negocios
{
    public class PacienteNegocio : IPacienteNegocio
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(PacienteNegocio)); //para usar os logs

        private readonly IPacienteRepositorio _pacienteRepositorio;
        public PacienteNegocio(IPacienteRepositorio pacienteRepositorio)
        {
            _pacienteRepositorio = pacienteRepositorio;
        }

        public Task<List<PacienteDTO>> FiltrarPaciente(string nome)
        {
            return _pacienteRepositorio.ListarPacientes(nome);

        }

        public async Task<List<PacienteDTO>> InserirPaciente(CadastroPacienteModel novoPaciente)
        {
            var paciente = await _pacienteRepositorio.ObterPc(novoPaciente.dsc_nome);

            if (paciente != null)
            {
                _log.InfoFormat(BusinessMessages.PacienteExistente, paciente.dsc_nome);
                throw new BusinessException(string.Format(BusinessMessages.PacienteExistente, paciente.dsc_nome));
            }

            paciente = CriarPaciente(novoPaciente);

            await _pacienteRepositorio.Inserir(paciente);

            _log.InfoFormat("Paciente inserido.");

            return await _pacienteRepositorio.ListarTodos();
        }

        private static Paciente CriarPaciente(CadastroPacienteModel paciente)
        {
            var pc = new Paciente
            {
                dsc_nome = paciente.dsc_nome,
                dat_nascimento = paciente.dat_nascimento,
                dat_criacao = paciente.dat_criacao
            };
            return pc;
        }
    }
}
