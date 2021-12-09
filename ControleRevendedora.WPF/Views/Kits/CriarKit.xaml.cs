using ControleRevendedora.Relatorios;
using ControleRevendedora.ViewModels.Kits;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ControleRevendedora.Views.Kits
{
    /// <summary>
    /// Lógica interna para CriarKit.xaml
    /// </summary>
    public partial class CriarKit : Window
    {
        private CriarKitVM VM = new CriarKitVM();
        public CriarKit()
        {
            InitializeComponent();
            DataContext = VM;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            VM.Kit.KitProdutos.Remove((Modelos.Produto)dgProdutos.SelectedValue);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            VM.Kit.KitProdutos.Add((Modelos.Produto)dgProdutos.SelectedValue);
            ExportarKits exportar = new ExportarKits();
            exportar.Show();
            PrintDialog printDialog = new PrintDialog();
            var printDialogResultado = printDialog.ShowDialog();
            if (printDialogResultado.HasValue && printDialogResultado.Value)
            {
                printDialog.PrintDocument(exportar.idpSource.DocumentPaginator, "teste");


            }
        }

        private void TxtPesquisa_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var nome = txtPesquisa.Text;
            Task.Run(async () => { await VM.ProcurarProdutos(nome); });
        }
    }
}
