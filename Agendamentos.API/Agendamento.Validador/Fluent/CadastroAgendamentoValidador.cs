using Agendamentos.Entidade.Models;
using Agendamentos.Utilitarios.Messages;
using FluentValidation;

namespace Agendamentos.Validador.Fluent
{
    public class CadastroAgendamentoValidador : AbstractValidator<CadastroAgendamentoModel>
    {
        public CadastroAgendamentoValidador() 
        {
            RuleFor(ag => ag.dsc_status)
               .NotNull().WithMessage(string.Format(BusinessMessages.CampoObrigatorio, "Status"))
               .NotEmpty().WithMessage(string.Format(BusinessMessages.CampoObrigatorio, "Status"))
               .MaximumLength(50).WithMessage(string.Format(BusinessMessages.TamanhoMaximo, "50", "Status"));

            RuleFor(ag => ag.dat_agendamento)
               .NotNull().WithMessage(string.Format(BusinessMessages.CampoObrigatorio, "Data do agendamento"))
               .NotEmpty().WithMessage(string.Format(BusinessMessages.CampoObrigatorio, "Data do agendamento"));
            
            RuleFor(ag => ag.hor_agendamento)
               .NotNull().WithMessage(string.Format(BusinessMessages.CampoObrigatorio, "Hora do agendamento"))
               .NotEmpty().WithMessage(string.Format(BusinessMessages.CampoObrigatorio, "Hora do agendamento"));

            RuleFor(ag => ag.id_paciente)
               .NotNull().WithMessage(string.Format(BusinessMessages.CampoObrigatorio, "Paciente"))
               .NotEmpty().WithMessage(string.Format(BusinessMessages.CampoObrigatorio, "Paciente"));
        }
    }
}
