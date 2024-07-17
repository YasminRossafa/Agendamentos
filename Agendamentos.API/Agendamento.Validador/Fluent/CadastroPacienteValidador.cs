using Agendamentos.Entidade.Models;
using Agendamentos.Utilitarios.Messages;
using FluentValidation;

namespace Agendamentos.Validador.Fluent
{
    public class CadastroPacienteValidador : AbstractValidator<CadastroPacienteModel>
    {
        public CadastroPacienteValidador()
        {
            RuleFor(pc => pc.dsc_nome)
               .NotNull().WithMessage(string.Format(BusinessMessages.CampoObrigatorio, "Nome"))
               .NotEmpty().WithMessage(string.Format(BusinessMessages.CampoObrigatorio, "Nome"));

            RuleFor(pc => pc.dat_nascimento)
               .NotNull().WithMessage(string.Format(BusinessMessages.CampoObrigatorio, "Data de Nascimento"))
               .NotEmpty().WithMessage(string.Format(BusinessMessages.CampoObrigatorio, "Data de Nascimento"));

        }
    }
}
