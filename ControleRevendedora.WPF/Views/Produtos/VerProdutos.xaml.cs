using ControleRevendedora.Contexto;
using ControleRevendedora.Modelos;
using ControleRevendedora.ViewModels.Produtos;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ControleRevendedora.Views.Produtos
{
    /// <summary>
    /// Lógica interna para ProdutosView.xaml
    /// </summary>
    public partial class VerProdutos : Window
    {
        public List<Produto> Produto = new List<Produto>();
        public ProdutosViewVM VM = new ProdutosViewVM();
        public RevendedoraContext contexto = new RevendedoraContext();

        public VerProdutos()
        {
            InitializeComponent();
            Produto = contexto.Produtos.Include("Transacoes").OrderByDescending(x => x.Id).ToList();
            VM.Produtos = Produto;
            DataContext = VM;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var pessoa = (Produto)btn.DataContext;
            new EditarProdutos(pessoa.Id).Show();
        }
    }
}
