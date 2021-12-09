using System.Windows;
using System.Windows.Documents;

namespace ControleRevendedora.Extensoes
{
    public static class TableExtensions
    {
        public static void InicializarTable(this Table tabela)
        {
            tabela.RowGroups.Add(new TableRowGroup());
        }

        public static void AdicionarColunas(this Table tabela, int quantidade)
        {
            for (int i = 0; i < quantidade; i++)
            {
                tabela.Columns.Add(new TableColumn());
            }
        }
        public static void AdicionarColuna(this Table tabela, double? largura = null, int grupoLinha = 0)
        {
            var GridLengthLargura = largura.HasValue ? new GridLength(largura.Value, GridUnitType.Star) : GridLength.Auto;

            tabela.Columns.Add(new TableColumn() { Width = GridLengthLargura });
        }

        public static void AdicionarLinha(this Table tabela, TableRow linha, int grupoLinha = 0)
        {
            tabela.RowGroups[grupoLinha].Rows.Add(linha);
        }

        public static void AdicionarLinha(this Table tabela, object[] valores, int grupoLinha = 0,
            FontWeight? fontWeights = null)
        {
            var linha = new TableRow();
            foreach (object valor in valores)
            {
                var celula = new TableCell(new Paragraph(new Run
                {
                    Text = valor.ToString(),
                    FontWeight = fontWeights ?? FontWeights.Regular
                }));

                linha.Cells.Add(celula);
            }
            tabela.RowGroups[grupoLinha].Rows.Add(linha);
        }
    }
}
