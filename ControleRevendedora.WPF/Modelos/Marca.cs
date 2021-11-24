using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleRevendedora.Modelos
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "Não identificada";
        public virtual List<Produto> Produtos { get; set; }
    }
}
