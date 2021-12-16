using ControleRevendedora.Contexto;
using ControleRevendedora.ViewModels.Produtos;
using NetBarcode;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Type = NetBarcode.Type;

namespace ControleRevendedora.Views.Produtos
{
    /// <summary>
    /// Interação lógica para ProdutosEdit.xam
    /// </summary>
    public partial class EditarProdutos : Window
    {
        private EditarProdutosVM VM = new EditarProdutosVM();
        private RevendedoraContext revendedoraContext = new RevendedoraContext();

        public EditarProdutos()
        {
            InitializeComponent();

            DataContext = VM;
            SpEmEstoque.Visibility = Visibility.Hidden;
        }

        public EditarProdutos(long identificador)
        {
            InitializeComponent();

            VM.Produto = revendedoraContext.Produtos
                                           .Where(e => e.Id == identificador)
                                           .FirstOrDefault() ?? new Modelos.Produto() { CodigoBarras = identificador.ToString() };
            DataContext = VM;

            cbCodigoBarras.IsChecked = !String.IsNullOrEmpty(VM.Produto.CodigoBarras);
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

        private void txtCodigoBarras_TextChanged(object sender, TextChangedEventArgs e)
        {
            var codigoBarras = VM.Produto.CodigoBarras;

            if (codigoBarras.ToString().Length == 13)
            {
                var barcode = new Barcode(codigoBarras, Type.EAN13, true);
                byte[] binaryData = Convert.FromBase64String(barcode.GetBase64Image());

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(binaryData);
                bi.EndInit();

                Image img = new Image();
                img.Source = bi;
                imgCodigoBarras.Source = bi;
            }
        }
    }
}
