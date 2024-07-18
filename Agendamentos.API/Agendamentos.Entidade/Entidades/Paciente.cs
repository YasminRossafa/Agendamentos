using Microsoft.VisualBasic;

namespace Agendamentos.Entidade.Entidades
{
    public class Paciente : IdEntidade<int>
    {
        public string dsc_nome { get; set; }
        public DateTime dat_nascimento { get; set; }
        public DateTime dat_criacao { get; set; } = DateTime.Now;

        public ICollection<Agendamento> Agendamentos { get; set; }

        public Paciente()
        {
            
        }
    }
}
