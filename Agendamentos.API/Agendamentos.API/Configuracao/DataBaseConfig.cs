using Agendamentos.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Agendamentos.API.Configuracao
{
    public static class DataBaseConfig
    {
        public static void AddDataBaseConfig(this IServiceCollection services, IConfiguration configuracao)
        {
            services.AddDbContext<Contexto>(options => options.UseSqlServer(configuracao.GetConnectionString("DefaultConnection")));
        }
    }
}
