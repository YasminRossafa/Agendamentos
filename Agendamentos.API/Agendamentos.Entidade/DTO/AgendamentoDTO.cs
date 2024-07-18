using Agendamentos.Entidade.Entidades;
using Microsoft.VisualBasic;
using System.Runtime.Intrinsics.X86;

namespace Agendamentos.Entidade.DTO
{
    public class AgendamentoDTO
    {
        public DateTime dat_agendamento { get; set; }

        public TimeSpan hor_agendamento { get; set; }

        public string dsc_status { get; set; }

        public string dsc_nome_paciente { get; set; }


    }
}
