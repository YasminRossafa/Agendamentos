using Agendamentos.API.Middleware;
using Agendamentos.Negocio.Interface.INegocios;
using Agendamentos.Negocio.Negocios;
using Agendamentos.Repositorio.Interface.IAgendamentoRepositorio;
using Agendamentos.Repositorio.Repositorios;
using Microsoft.OpenApi.Any;

namespace Agendamentos.API
{
    public class Startup
    {
        public Startup() { }

        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();

            services.AddScoped<IAgendamentoRepositorio, AgendamentoRepositorio>();
            services.AddScoped<IAgendamentoNegocio, AgendamentoNegocio>();
            services.AddTransient<ApiMiddleware>();

            services.AddSwaggerGen(c =>
            {
                c.MapType(typeof(TimeSpan), () => new() { Type = "string", Example = new OpenApiString("00:00:00") });
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Agendamentos",
                    Version = "v1",
                    Description = "Agendamentos para a vacina COVID-19"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) { 
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Agendamentos v1");
                c.RoutePrefix = string.Empty;
            });
            app.UseRouting();
            app.UseMiddleware<ApiMiddleware>();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
