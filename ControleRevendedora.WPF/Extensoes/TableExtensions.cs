using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace ControleRevendedora.Extensoes
{
    public class TabelaCelula
    {
        public object Conteudo { get; set; }
        public FontWeight? FontWeights { get; set; }
        public Thickness? Padding { get; set; }
        public double FontSize { get; set; } = 12;
        public string BorderColor { get; set; } = "#000";
    }

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
        public static void AdicionarColuna(this Table tabela, double? largura = null)
        {
            var GridLengthLargura = largura.HasValue ? new GridLength(largura.Value, GridUnitType.Star) : GridLength.Auto;

            tabela.Columns.Add(new TableColumn() { Width = GridLengthLargura });
        }

        public static void AdicionarLinha(this Table tabela, TableRow linha, int grupoLinha = 0)
        {
            tabela.RowGroups[grupoLinha].Rows.Add(linha);
        }

        public static void AdicionarLinha(this Table tabela, object[] valores, int grupoLinha = 0,
            FontWeight? fontWeights = null, Thickness? padding = null)
        {
            var linha = new TableRow();

            foreach (object valor in valores)
            {
                Block celulaConteudo;

                if (valor.GetType().IsPrimitive || valor.GetType() == typeof(string))
                {
                    celulaConteudo = new Paragraph(new Run
                    {
                        Text = valor.ToString(),
                        FontWeight = fontWeights ?? FontWeights.Regular,
                    });
                }
                else
                {
                    var paragrafo = new Paragraph();
                    paragrafo.Inlines.Add((UIElement)valor);
                    celulaConteudo = paragrafo;
                }

                var celula = new TableCell(celulaConteudo);

                if (padding.HasValue)
                    celula.Padding = padding.Value;
                celula.BorderThickness = new Thickness(1);
                celula.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#000");

                linha.Cells.Add(celula);
            }

            tabela.RowGroups[grupoLinha].Rows.Add(linha);
        }

        public static void AdicionarLinha(this Table tabela, TabelaCelula[] celulas, int grupoLinha = 0)
        {
            var linha = new TableRow();

            foreach (TabelaCelula valor in celulas)
            {
                Block celulaConteudo;
                if (valor.Conteudo.GetType().IsPrimitive || valor.Conteudo.GetType() == typeof(string))
                {
                    celulaConteudo = new Paragraph(new Run
                    {
                        Text = valor.Conteudo.ToString(),
                        FontSize = valor.FontSize,
                        FontWeight = valor.FontWeights ?? FontWeights.Regular,
                    });
                }
                else
                {
                    var paragrafo = new Paragraph();
                    paragrafo.Inlines.Add((UIElement)valor.Conteudo);
                    celulaConteudo = paragrafo;
                }

                var celula = new TableCell(celulaConteudo);

                if (valor.Padding.HasValue)
                    celula.Padding = valor.Padding.Value;
                celula.BorderThickness = new Thickness(1);
                celula.BorderBrush = (Brush)new BrushConverter().ConvertFrom(valor.BorderColor);

                linha.Cells.Add(celula);
            }
            tabela.RowGroups[grupoLinha].Rows.Add(linha);
        }
    }
}
