using Agendamentos.API.Configuracao;
using Agendamentos.API.Configuraçao;
using Agendamentos.API.Middleware;
using Microsoft.OpenApi.Any;

namespace Agendamentos.API
{
    public class Startup
    {
        public IConfiguration Configuracao { get; }
        public Startup(IConfiguration configuracao) 
        { 
            Configuracao = configuracao;
        }

        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddControllers();

            services.AddInjecaoDependencia(Configuracao);

            services.AddDataBaseConfig(Configuracao);

            services.AddFluentConfig();

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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        {
            if (env.IsDevelopment()) 
                app.UseDeveloperExceptionPage();

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
