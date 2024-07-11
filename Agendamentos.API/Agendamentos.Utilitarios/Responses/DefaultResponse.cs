using System.Net;

namespace Agendamentos.Utilitarios.Responses
{
    public class DefaultResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public List<string> Messages { get; set; }
        public DefaultResponse(HttpStatusCode status, List<string> messages)
        {
            StatusCode = status;
            Messages = messages;
        }
    }
}
