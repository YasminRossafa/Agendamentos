using Agendamentos.Negocio.Interface.INegocios;
using Agendamentos.Negocio.Negocios;
using Agendamentos.Repositorio.Interface.IAgendamentoRepositorio;
using Agendamentos.Repositorio.Interface.IRepositorios;
using Agendamentos.Repositorio.Repositorios;

namespace Agendamentos.API.Configuracao
{
    public static class InjecaoDependencia
    {
        public static void AddInjecaoDependencia(this IServiceCollection services, IConfiguration configuracao)
        {
            InjetarRepositorio(services);
            InjetarNegocio(services);
        }

        private static void InjetarNegocio(IServiceCollection services)
        {
            services.AddScoped<IAgendamentoNegocio, AgendamentoNegocio>();
            services.AddScoped<IPacienteNegocio, PacienteNegocio>();
        }

        private static void InjetarRepositorio(IServiceCollection services)
        {
            services.AddScoped<IAgendamentoRepositorio, AgendamentoRepositorio>();
            services.AddScoped<IPacienteRepositorio, PacienteRepositorio>();
        }
    }
}
