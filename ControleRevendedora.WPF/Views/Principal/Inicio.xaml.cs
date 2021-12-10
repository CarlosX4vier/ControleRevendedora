using AutoUpdaterDotNET;
using ControleRevendedora.Contexto;
using ControleRevendedora.Views.Estoque;
using ControleRevendedora.Views.Kits;
using ControleRevendedora.Views.Produtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Windows;

namespace ControleRevendedora.Views.Principal
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class Inicio : Window
    {
        public Inicio()
        {
            InitializeComponent();
            AutoUpdater.RunUpdateAsAdmin = true;
            AutoUpdater.Start("https://carlosx4vier.github.io/controlerevendedora.github.io/version.xml");

            Browser.Address = "https://app.confere.com.br/auth-by-token/eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjp7ImlkIjoxMDM1MTR9LCJjdXN0b21lcnMiOls4NTg4NV0sImlhdCI6MTYyODU1MDA5OCwiZXhwIjoyNDkyNDYzNjk4LCJpc3MiOiJjb25mZXJlLXByb2QifQ.xFyDDevnbd-5uXTE1zOAJBu_naiafDvV2doCg9kGUJE?utm_source=infinitepay&utm_medium=app&utm_campaign=infinite-confere";
            //          Database.SetInitializer(new MigrateDatabaseToLatestVersion<RevendedoraContext, Configuration>());
            RevendedoraContext r = new RevendedoraContext();

        }

        private void MiVerProdutos_Click(object sender, RoutedEventArgs e)
        {
            var tela = new VerProdutos();
            tela.Show();
        }

        private void Tela_Closed(object sender, EventArgs e)
        { }

        private void MiCadastroEstoque_Click(object sender, RoutedEventArgs e)
        {
            var tela = new CadastroEstoque();
            tela.Show();
        }

        private void MiCadastrarProduto_Click(object sender, RoutedEventArgs e)
        {
            var tela = new EditarProdutos();
            tela.Show();
        }

        private void MiCadastrarKit_Click(object sender, RoutedEventArgs e)
        {
            var tela = new CriarKit();
            tela.Show();
        }

        private void MiListarKit_Click(object sender, RoutedEventArgs e)
        {
            var tela = new VerKits();
            tela.Show();
        }
    }
}
