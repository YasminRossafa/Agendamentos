using Agendamentos.Entidade.DTO;
using Agendamentos.Negocio.Interface.INegocios;
using Microsoft.AspNetCore.Mvc;

namespace Agendamentos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentosController : ControllerBase
    {
        private static List<string> AgendamentosMarcados { get; set; } = new() { "Ag1", "Ag2", "Ag3" };

        private readonly ILogger<AgendamentosController> _logger;
        private readonly IAgendamentoNegocio _agendamentoNegocio;

        public AgendamentosController(ILogger<AgendamentosController> logger, IAgendamentoNegocio agendamentoNegocio)
        {
            _logger = logger;
            _agendamentoNegocio = agendamentoNegocio;
        }

        [HttpGet("GetAgendamentos")] //retorna a lista de ag
        public ActionResult<List<AgendamentoDTO>> ListarTodos()
        {
            return _agendamentoNegocio.ListarAgendamentos(null);
        }

        [HttpGet("FilterAgendamentos")] //retorna o ag enviado
        public ActionResult<List<AgendamentoDTO>> FiltrarAgendamentos(string agendamentos)
        {
            return _agendamentoNegocio.ListarAgendamentos(new List<string>() { agendamentos });
        }

        [HttpPost("PostAgendamentos")] //adiciona um ag
        public ActionResult<List<AgendamentoDTO>> Post(string novoAgendamento)
        {
            return _agendamentoNegocio.InserirAgendamentos(novoAgendamento);
        }

        [HttpDelete("DelAgendamentos")]
        public ActionResult<List<AgendamentoDTO>> Delete(string agendamento) //remove um ag
        {
            return _agendamentoNegocio.DeletarAgendamentos(agendamento);
        }

        [HttpPut("AltAgendamentos")] //altera um ag
        public ActionResult<List<AgendamentoDTO>> Put(string agendamento, string novoNomeAg)
        {
            return _agendamentoNegocio.AlterarAgendamentos(agendamento, novoNomeAg);
        }
    }
}
