using Agendamentos.Entidade.DTO;
using Agendamentos.Entidade.Models;
using Agendamentos.Negocio.Interface.INegocios;
using Microsoft.AspNetCore.Mvc;

namespace Agendamentos.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteNegocio _pacienteNegocio;

        public PacientesController(IPacienteNegocio pacienteNegocio)
        {
            _pacienteNegocio = pacienteNegocio;
        }

        [HttpGet("FilterPacientes")]
        public async Task<List<PacienteDTO>> FiltrarPaciente(string nome)
        {
            return await _pacienteNegocio.FiltrarPaciente(nome);
        }
    }
}
