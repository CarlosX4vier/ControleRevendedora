using ControleRevendedora.Extensoes;
using ControleRevendedora.Modelos;
using NetBarcode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace ControleRevendedora.Relatorios
{
    /// <summary>
    /// Lógica interna para ExportarKits.xaml
    /// </summary>
    public partial class ExportarKits : Window
    {
        public IDocumentPaginatorSource idpSource;
        public string Titulo { get; set; }
        public List<Produto> Produtos { get; set; }
        public string CodigoBarras { get; set; }
        public ExportarKits(Kit kit)
        {
            InitializeComponent();

            base.DataContext = this;

            Titulo = kit.Nome;
            Produtos = kit.KitProdutos;
            CodigoBarras = kit.CodigoBarras;

            imgCodigoBarras.Source = GerarCodigoBarras(CodigoBarras);

            tbProdutos.InicializarTable();
            tbProdutos.AdicionarColuna(largura: 3);
            tbProdutos.AdicionarColuna(largura: 10);
            tbProdutos.AdicionarLinha(new object[] { "Codigo de Barras", "Nome" }, fontWeights: FontWeights.Bold, padding: new Thickness(2));

            foreach (var produto in Produtos)
            {
                var imagem = new Image
                {
                    Margin = new Thickness(4, 0, 4, 0),
                    Source = GerarCodigoBarras(produto.CodigoBarras)
                };

                tbProdutos.AdicionarLinha(new TabelaCelula[] {
                    new TabelaCelula(){Conteudo = imagem, BorderColor="#FFF" },
                    new TabelaCelula(){Conteudo =  produto.Nome }
                });
            }

            idpSource = Document;
        }

        public BitmapImage GerarCodigoBarras(string codigoBarras)
        {
            if (CodigoBarras.Length == 13)
            {
                var barcode = new Barcode(codigoBarras, NetBarcode.Type.EAN13, true);
                byte[] binaryData = Convert.FromBase64String(barcode.GetBase64Image());

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(binaryData);
                bi.EndInit();
                return bi;
            }
            return null;
        }

        public void Exportar()
        {
            var pd = new PrintDialog();
            pd.PrintTicket.PageOrientation = System.Printing.PageOrientation.Portrait;
            var printDialogResultado = pd.ShowDialog();
            if (printDialogResultado.HasValue && printDialogResultado.Value)
            {
                string nomeDocumento = nameof(this.Name) + DateTime.Now.ToString("ddMMyyyyHHmmfff");
                pd.PrintDocument(idpSource.DocumentPaginator, nomeDocumento);
            }
        }
    }
}
