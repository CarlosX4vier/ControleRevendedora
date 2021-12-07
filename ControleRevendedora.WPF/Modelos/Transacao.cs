using System;

namespace ControleRevendedora.Modelos
{
    public class Transacao
    {
        public int Id { get; set; }
        public DateTime DataEntrada { get; set; } = DateTime.Now;
        public DateTime? DataSaida { get; set; }
        public float ValorEntrada { get; set; }
        public float? ValorSaida { get; set; }
        public virtual ProdutoBase Produto { get; set; }
        public long ProdutoID { get; set; }
    }
}
