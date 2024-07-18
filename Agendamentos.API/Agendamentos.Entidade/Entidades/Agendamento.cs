using Microsoft.VisualBasic;

namespace Agendamentos.Entidade.Entidades
{
    public class Agendamento : IdEntidade<int>
    {        
        public int id_paciente { get; set; }

        public DateTime dat_agendamento { get; set; }

        public TimeSpan hor_agendamento { get; set; }

        public string dsc_status { get; set; }

        public DateTime dat_criacao { get; set; } = DateTime.Now;

        public Paciente Paciente { get; set; }

        public Agendamento()
        {
            
        }

    }
}
