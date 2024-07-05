using Microsoft.AspNetCore.Mvc;

namespace Agendamentos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentosController : ControllerBase
    {
        private static List<string> AgendamentosMarcados { get; set; } = new() { "Ag1", "Ag2", "Ag3" };

        private readonly ILogger<AgendamentosController> _logger;

        public AgendamentosController(ILogger<AgendamentosController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAgendamentos")]
        public ActionResult<List<string>> Get()
        {
            return AgendamentosMarcados;
        }

        [HttpPost(Name = "PostAgendamentos")]
        public ActionResult<List<string>> Post(string novoAgendamento)
        {
            AgendamentosMarcados.Add(novoAgendamento);
            return AgendamentosMarcados;
        }

        [HttpDelete(Name = "DelAgendamentos")]
        public ActionResult<List<string>> Delete(string agendamento)
        {
            AgendamentosMarcados.Remove(agendamento);
            return AgendamentosMarcados;
        }

        [HttpPut(Name = "AltAgendamentos")]
        public ActionResult<List<string>> Put(string agendamento, string novoNomeAg)
        {
            var indexAgendamento = AgendamentosMarcados.FindIndex(ag => ag == agendamento);
            AgendamentosMarcados[indexAgendamento] = novoNomeAg;
            return AgendamentosMarcados;
        }
    }
}
