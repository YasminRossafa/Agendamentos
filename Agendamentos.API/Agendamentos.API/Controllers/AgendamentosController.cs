using Agendamentos.Entidade.DTO;
using Agendamentos.Entidade.Models;
using Agendamentos.Negocio.Interface.INegocios;
using Microsoft.AspNetCore.Mvc;

namespace Agendamentos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentosController : ControllerBase
    {
        private readonly IAgendamentoNegocio _agendamentoNegocio;

        public AgendamentosController(ILogger<AgendamentosController> logger, IAgendamentoNegocio agendamentoNegocio)
        {
            _agendamentoNegocio = agendamentoNegocio;
        }

        [HttpGet("GetAgendamentos")] //retorna a lista de ag
        public async Task<List<AgendamentoDTO>> ListarTodos()
        {
            return await _agendamentoNegocio.ListarAgendamentos(null);
        }

        [HttpGet("FilterAgendamentos")] //retorna o ag enviado
        public async Task<List<AgendamentoDTO>> FiltrarAgendamentos(DateTime agendamentos)
        {
            return await _agendamentoNegocio.ListarAgendamentos(new List<DateTime>() { agendamentos });
        }

        [HttpPost("PostAgendamentos")] //adiciona um ag
        public async Task<List<AgendamentoDTO>> Post(CadastroAgendamentoModel novoAgendamento)
        {
            return await _agendamentoNegocio.InserirAgendamentos(novoAgendamento);
        }

        [HttpPut("AltAgendamentos")] //altera um ag
        public async Task<List<AgendamentoDTO>> Put(DateTime dia, TimeSpan hora, string status)
        {
            return await _agendamentoNegocio.AlterarAgendamentos(dia, hora, status);
        }
    }
}
