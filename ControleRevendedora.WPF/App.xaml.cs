using ControleRevendedora.Configuracao;
using ControleRevendedora.Contexto;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Runtime.Caching;
using System.Windows;
using System.Windows.Markup;

namespace ControleRevendedora
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
        }

        public App()
        {
            AutoMapperConfig autoMapperConfig = new AutoMapperConfig();


            FrameworkElement.LanguageProperty.OverrideMetadata(
            typeof(FrameworkElement),
            new FrameworkPropertyMetadata(
         XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
            try
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<RevendedoraContext, Migrations.Configuration>());
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message}", "Falha ao atualizar banco de dados");
            }
        }
    }
}
