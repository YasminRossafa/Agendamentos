using Microsoft.VisualBasic;

namespace Agendamentos.Entidade.DTO
{
    public class AgendamentoDTO
    {
        public DateTime dat_agendamento { get; set; }

        public TimeSpan hor_agendamento { get; set; }

        public string dsc_status { get; set; }

    }
}
