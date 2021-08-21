using AutoUpdaterDotNET;
using ControleRevendedora.Contexto;
using ControleRevendedora.Migrations;
using ControleRevendedora.Servicos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControleRevendedora
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AutoUpdater.RunUpdateAsAdmin = true;
            AutoUpdater.Start("https://carlosx4vier.github.io/controlerevendedora.github.io/version.xml");

            Browser.Address = "https://app.confere.com.br/auth-by-token/eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjp7ImlkIjoxMDM1MTR9LCJjdXN0b21lcnMiOls4NTg4NV0sImlhdCI6MTYyODU1MDA5OCwiZXhwIjoyNDkyNDYzNjk4LCJpc3MiOiJjb25mZXJlLXByb2QifQ.xFyDDevnbd-5uXTE1zOAJBu_naiafDvV2doCg9kGUJE?utm_source=infinitepay&utm_medium=app&utm_campaign=infinite-confere";

            //          Database.SetInitializer(new MigrateDatabaseToLatestVersion<RevendedoraContext, Configuration>());

            try
            {
                new DbMigrator(new Migrations.Configuration(), new RevendedoraContext()).Update();
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message}", "Falha ao atualizar banco de dados");
            }


        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var tela = new ProdutosView();
            tela.Show();

        }

        private void Tela_Closed(object sender, EventArgs e)
        { }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var tela = new CadastroEstoque();
            tela.Show();

        }
    }
}
