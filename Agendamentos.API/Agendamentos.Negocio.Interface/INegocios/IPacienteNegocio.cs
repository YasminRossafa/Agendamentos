using Agendamentos.Entidade.DTO;
using Agendamentos.Entidade.Models;

namespace Agendamentos.Negocio.Interface.INegocios
{
    public interface IPacienteNegocio
    {
        Task<List<PacienteDTO>> InserirPaciente(CadastroPacienteModel novoPaciente);
        Task<List<PacienteDTO>> FiltrarPaciente(string nome);

    }
}
