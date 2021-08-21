using ControleRevendedora.Contexto;
using ControleRevendedora.Modelos;
using ControleRevendedora.Servicos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ControleRevendedora
{
    /// <summary>
    /// Lógica interna para CadastroEstoque.xaml
    /// </summary>
    public partial class CadastroEstoque : Window
    {
        private RevendedoraContext context = new RevendedoraContext();
        public CadastroEstoqueVM VM = new CadastroEstoqueVM();
        public CadastroEstoque()
        {
            //this.Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);

            InitializeComponent();

            VM.Produtos.AddRange(context.Produtos.ToList());
            DataContext = VM;
            txtCodigoBarras.Focus();
        }

        private void txtCodigoBarras_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (Key.Enter == e.Key)
            {
                try
                {
                    var codigoBarras = txtCodigoBarras.Text;
                    if (codigoBarras.Length == 13)
                    {
                        ProdutosServico produtosServico = new ProdutosServico();
                        var produtoBuscado = (Produto)produtosServico.Buscar(context, long.Parse(codigoBarras));
                        if (!VM.Produtos.Contains(produtoBuscado))
                        {
                            VM.Produtos.Add(produtoBuscado);
                        }
                        cbProdutos.SelectedItem = produtoBuscado;
                    }
                    txtCodigoBarras.Text = "";

                }

                catch (Exception exception)
                {
                    MessageBox.Show($"{exception.Message}", "Falha ao buscar");
                }
            }
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {

            context.SaveChanges();
            MessageBox.Show($"Produto atualizado com sucesso!", "OK!");
            dgEstoque.Items.Refresh();
        }


        private void dgEstoque_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Key.Delete == e.Key)
            {
                var removido = context.Transacoes.Remove((Transacao)dgEstoque.SelectedItem);
                dgEstoque.Items.Refresh();
            }
        }

        private void cbProdutos_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                VM.ProdutoSelecionado = ((Produto)cbProdutos.SelectedItem).Id;
                dgEstoque.ItemsSource = ((Produto)cbProdutos.SelectedItem).Transacoes;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Erro {exception.Message}", "Falha ao atualizar");
            }
        }

        private void dgEstoque_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Column.DisplayIndex == ValorSaida.DisplayIndex)
            {
                ((Transacao)(sender as DataGrid).SelectedItem).DataSaida = DateTime.Now;
            }
        }
    }

    public class CadastroEstoqueVM
    {
        public RangeObservableCollection<Produto> Produtos { get; set; } = new RangeObservableCollection<Produto>();
        public long? CodigoBarra { get; set; }
        public bool ViaLeitor { get; set; } = true;
        public int ProdutoSelecionado { get; set; }

    }



}
