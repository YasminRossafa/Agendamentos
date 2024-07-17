using Agendamentos.Validador.Fluent;
using FluentValidation.AspNetCore;

namespace Agendamentos.API.Configuraçao
{
    public static class FluentConfig
    {
        public static void AddFluentConfig(this IServiceCollection services)
        {
            services.AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<CadastroAgendamentoValidador>());
            services.AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<CadastroPacienteValidador>());
        }
    }
}
