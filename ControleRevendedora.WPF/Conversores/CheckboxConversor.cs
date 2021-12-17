using ControleRevendedora.Modelos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace ControleRevendedora.Conversores
{
    public sealed class CheckboxConversor : IMultiValueConverter
    {


        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Kit kit = (Kit)values[0];
            Produto produto = (Produto)values[1];
            if (kit != null && kit.KitProdutos.Count > 0)
            {
                var resultado = kit.KitProdutos.Any(p => p != null && p.Id == produto.Id);
                return resultado;
            }
            return false;
        }


        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { true };
        }
    }
}
