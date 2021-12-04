using ControleRevendedora.Contexto;
using ControleRevendedora.ViewModels;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ControleRevendedora
{
    /// <summary>
    /// Interação lógica para ProdutosEdit.xam
    /// </summary>
    public partial class ProdutosEdit : Window
    {
        private ProdutosEditVM VM = new ProdutosEditVM();
        private RevendedoraContext revendedoraContext = new RevendedoraContext();

        public ProdutosEdit()
        {
            InitializeComponent();

            DataContext = VM;
            SpEmEstoque.Visibility = Visibility.Hidden;
        }

        public ProdutosEdit(long identificador)
        {
            InitializeComponent();

            VM.Produto = revendedoraContext.Produtos
                                           .Where(e => e.Id == identificador)
                                           .FirstOrDefault() ?? new Modelos.Produto() { CodigoBarras = identificador };
            DataContext = VM;

            cbCodigoBarras.IsChecked = VM.Produto.CodigoBarras.HasValue;
            txtCodigoBarras.IsReadOnly = !(cbCodigoBarras.IsChecked ?? false);
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        { }

        private void cbCodigoBarras_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            txtCodigoBarras.IsReadOnly = !(checkBox.IsChecked ?? false);

            if ((bool)!checkBox.IsChecked)
            {
                txtCodigoBarras.Text = null;
            }
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (VM.Produto.Id == 0)
            {
                revendedoraContext.Produtos.Add(VM.Produto);
            }

            var alteracoes = revendedoraContext.SaveChanges();
            if (alteracoes > 0)
            {
                MessageBox.Show("Alterado com sucesso");
            }
        }
    }
}
