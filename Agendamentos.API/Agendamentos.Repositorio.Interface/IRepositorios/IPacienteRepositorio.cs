
using Agendamentos.Entidade.DTO;
using Agendamentos.Entidade.Entidades;

namespace Agendamentos.Repositorio.Interface.IRepositorios
{
    public interface IPacienteRepositorio : IRepositorioBase<Paciente>
    {
        Task<List<PacienteDTO>> ListarPacientes(string nomes);        
        Task<Paciente> ObterPc(string nome);
    }
}
