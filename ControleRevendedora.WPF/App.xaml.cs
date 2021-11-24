using ControleRevendedora.Configuracao;
using ControleRevendedora.Contexto;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;

namespace ControleRevendedora
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : Application
    {

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
