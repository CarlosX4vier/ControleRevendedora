using ControleRevendedora.Contexto;
using ControleRevendedora.Extensoes;
using ControleRevendedora.Modelos;
using NetBarcode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public string Titulo { get; set; } = "Teste";
        public List<Produto> Produtos { get; set; }
        public string CodigoBarras = "1234567891234";
        public ExportarKits()
        {
            InitializeComponent();
            Produtos = new RevendedoraContext().Produtos.Take(10).ToList();
            base.DataContext = this;

            GerarCodigoBarras();

            tbProdutos.InicializarTable();

            tbProdutos.AdicionarColuna(largura: 1);
            tbProdutos.AdicionarColuna(largura: 10);

            tbProdutos.AdicionarLinha(new object[] { "ID", "Nome" });

            foreach (var produto in Produtos)
            {
                tbProdutos.AdicionarLinha(new object[] { produto.Id, produto.Nome });
            }

            idpSource = Document;
        }

        public void GerarCodigoBarras()
        {
            if (CodigoBarras.Length == 13)
            {
                var barcode = new Barcode(CodigoBarras, NetBarcode.Type.EAN13, true);
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

        public void Exportar()
        {
            var pd = new PrintDialog();
            pd.PrintDocument(idpSource.DocumentPaginator, "Document");

        }
    }
}
