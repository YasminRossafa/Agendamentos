using Agendamentos.Entidade.Models;
using Agendamentos.Utilitarios.Messages;
using FluentValidation;

namespace Agendamentos.Validador.Fluent
{
    public class CadastroAgendamentoValidador : AbstractValidator<CadastroAgendamentoModel>
    {
        public CadastroAgendamentoValidador() 
        {
            RuleFor(ag => ag.dat_agendamento)
               .NotNull().WithMessage(string.Format(BusinessMessages.CampoObrigatorio, "Data do agendamento"))
               .NotEmpty().WithMessage(string.Format(BusinessMessages.CampoObrigatorio, "Data do agendamento"));
            
            RuleFor(ag => ag.hor_agendamento)
               .NotNull().WithMessage(string.Format(BusinessMessages.CampoObrigatorio, "Hora do agendamento"))
               .NotEmpty().WithMessage(string.Format(BusinessMessages.CampoObrigatorio, "Hora do agendamento"));
        }
    }
}
