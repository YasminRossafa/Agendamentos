using Microsoft.VisualBasic;

namespace Agendamentos.Entidade.Models
{
    public class CadastroAgendamentoModel
    {
        public DateTime dat_agendamento { get; set; }

        public TimeSpan hor_agendamento { get; set; }

        public CadastroPacienteModel pc { get; set; }
    }
}
