using log4net.Config;
using log4net;
using System.Reflection;
using Microsoft.AspNetCore;
using Agendamentos.API;

namespace ControleTarefas.WebApi
{
    public static class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Program));

        public static void Main(string[] args)
        {
            try
            {
                var logRepository = LogManager.GetRepository(Assembly.GetCallingAssembly());
                XmlConfigurator.Configure(logRepository, new FileInfo("web.config"));

                _log.Info("Starting API");
                var webHost = WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();

                webHost.Build().Run();
            }
            catch (Exception ex)
            {
                _log.Fatal("Erro fatal", ex);
                throw;
            }
        }
    }
}