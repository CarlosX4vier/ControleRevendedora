using System.Text;
using System.Text.RegularExpressions;

namespace ControleRevendedora.Utils
{
    public class CodigoBarrasUtils
    {
        public static string Gerar(string codigoBarras)
        {
            string prefixo = "192";
            var codigoFinal = new StringBuilder(prefixo);

            codigoFinal.Append(codigoBarras.PadLeft(9, '0'));
            codigoFinal.Append(GerarDigitoValidador(codigoFinal.ToString()));
            return codigoFinal.ToString();
        }

        public static int GerarDigitoValidador(string codigo)
        {
            if (codigo != (new Regex("[^0-9]")).Replace(codigo, ""))
            {
                throw new System.Exception("O codigo deve ser numerico");
            }

            int[] a = new int[12];
            a[0] = int.Parse(codigo[0].ToString());
            a[1] = int.Parse(codigo[1].ToString()) * 3;
            a[2] = int.Parse(codigo[2].ToString());
            a[3] = int.Parse(codigo[3].ToString()) * 3;
            a[4] = int.Parse(codigo[4].ToString());
            a[5] = int.Parse(codigo[5].ToString()) * 3;
            a[6] = int.Parse(codigo[6].ToString());
            a[7] = int.Parse(codigo[7].ToString()) * 3;
            a[8] = int.Parse(codigo[8].ToString());
            a[9] = int.Parse(codigo[9].ToString()) * 3;
            a[10] = int.Parse(codigo[10].ToString());
            a[11] = int.Parse(codigo[11].ToString()) * 3;
            int soma = a[0] + a[1] + a[2] + a[3] + a[4] + a[5] + a[6] + a[7] + a[8] + a[9] + a[10] + a[11];
            int digito = (10 - (soma % 10)) % 10;

            return digito;
        }
    }
}
