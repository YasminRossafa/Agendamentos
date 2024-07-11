namespace Agendamentos.Entidade.Entidades
{
    public class Agendamento
    {
        public string Titulo { get; set; }
        public Agendamento() { }

        public Agendamento(string titulo) {
            Titulo = titulo;
        }
    }
}
