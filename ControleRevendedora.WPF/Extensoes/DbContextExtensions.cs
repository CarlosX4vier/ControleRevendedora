using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.IO;

namespace ControleRevendedora.Extensoes
{
    public static class DbContextExtensions
    {

        public static string GetConnectionString(this DbContext context, string nome)
        {

            if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.ConnectionStrings[nome]?.ConnectionString))
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings[nome].ConnectionString;
            }
            string pathToContentRoot = Directory.GetCurrentDirectory();
            string json = Path.Combine(pathToContentRoot, "App.config");

            if (!File.Exists(json))
            {
                string pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                pathToContentRoot = Path.GetDirectoryName(pathToExe);
            }

            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(pathToContentRoot)
                .AddXmlFile("App.config");

            IConfiguration configuration = configurationBuilder.Build();
            var conexao = configuration.GetSection($"connectionStrings:add:{nome}:connectionString").Value;

            return conexao;
        }
    }
}
