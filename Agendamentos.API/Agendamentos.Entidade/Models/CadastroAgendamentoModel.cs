using Microsoft.VisualBasic;

namespace Agendamentos.Entidade.Models
{
    public class CadastroAgendamentoModel
    {
        public int id_agendamento { get; }

        public int id_paciente { get; set; }

        public DateTime dat_agendamento { get; set; }

        public TimeSpan hor_agendamento { get; set; }

        public string dsc_status { get; set; }

        public DateTime dat_criacao { get; set; } = DateTime.Now;
    }
}
