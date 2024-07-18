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
        private readonly IPacienteRepositorio _pacienteRepositorio;
        public PacienteNegocio(IPacienteRepositorio pacienteRepositorio)
        {
            _pacienteRepositorio = pacienteRepositorio;
        }

        public Task<List<PacienteDTO>> FiltrarPaciente(string nome)
        {
            return _pacienteRepositorio.ListarPacientes(nome);

        }

    }
}
