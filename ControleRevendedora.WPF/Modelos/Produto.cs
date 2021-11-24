using System.Collections.Generic;
using System.Linq;

namespace ControleRevendedora.Modelos
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long? CodigoBarras { get; set; }
        public string Imagem { get; set; }
        public Marca Marca { get; set; }

        public virtual List<Transacao> Transacoes { get; set; } = new List<Transacao>();
        public virtual int EmEstoque { get => Transacoes.Where(x => !x.DataSaida.HasValue).Count(); }
    }
}
