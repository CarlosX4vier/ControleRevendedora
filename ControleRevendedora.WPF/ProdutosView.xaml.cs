using ControleRevendedora.Contexto;
using ControleRevendedora.Modelos;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ControleRevendedora
{
    /// <summary>
    /// Lógica interna para ProdutosView.xaml
    /// </summary>
    public partial class ProdutosView : Window
    {

        public List<Produto> Produto = new List<Produto>();

        public ProdutosView()
        {
            InitializeComponent();
            RevendedoraContext contexto = new RevendedoraContext();

            Produto = contexto.Produtos.OrderByDescending(x => x.Id).ToList();
            dgProdutos.ItemsSource = Produto;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var pessoa = (Produto)btn.DataContext;
            new ProdutosEdit(pessoa.Id).Show();
        }
    }
}
