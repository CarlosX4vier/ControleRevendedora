using ControleRevendedora.Modelos;
using ControleRevendedora.Relatorios;
using ControleRevendedora.ViewModels.Kits;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ControleRevendedora.Views.Kits
{
    public partial class CriarKit : Window
    {
        private CriarKitVM VM = new CriarKitVM();
        public CriarKit()
        {
            InitializeComponent();
            DataContext = VM;
        }

        public CriarKit(Kit kit)
        {
            InitializeComponent();
            VM.Kit = kit;
            DataContext = VM;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            VM.Kit.KitProdutos.Remove((Modelos.Produto)dgProdutos.SelectedValue);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            VM.Kit.KitProdutos.Add((Modelos.Produto)dgProdutos.SelectedValue);
        }

        private async void TxtPesquisa_TextChanged(object sender, TextChangedEventArgs e)
        {
            var nome = txtPesquisa.Text;
            Task.Run(() => VM.ProcurarProdutos(nome));
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var mensagem = "";
                if (VM.Kit.Id > 0)
                {
                    VM.AtualizarKit();
                    mensagem = "Kit atualizado com sucesso!";
                }
                else
                {
                    VM.CriarKit();
                    mensagem = "Kit adicionado com sucesso!";
                }
                MessageBox.Show(mensagem, "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
