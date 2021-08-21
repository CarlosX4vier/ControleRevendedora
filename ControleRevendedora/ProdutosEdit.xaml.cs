using ControleRevendedora.Contexto;
using ControleRevendedora.Modelos;
using ControleRevendedora.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        }

        public ProdutosEdit(int id)
        {
            InitializeComponent();

            VM.Produto = revendedoraContext.Produtos.Where(e => e.Id == id).FirstOrDefault();
            DataContext = VM;

            cbCodigoBarras.IsChecked = VM.Produto.CodigoBarras != null;
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
            var alteracoes = revendedoraContext.SaveChanges();
            if (alteracoes > 0)
            {
                MessageBox.Show("Alterado com sucesso");
            }
        }
    }
}
