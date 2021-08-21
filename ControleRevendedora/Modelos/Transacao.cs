using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleRevendedora.Modelos
{
    public class Transacao
    {
        public int Id { get; set; }
        public DateTime DataEntrada { get; set; } = DateTime.Now;
        public DateTime? DataSaida { get; set; }
        public float ValorEntrada { get; set; }
        public float? ValorSaida { get; set; }
        public virtual Produto Produto { get; set; }
        public int ProdutoID { get; set; }
    }
}
