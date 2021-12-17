using System.Collections.Generic;
using System.Linq;

namespace ControleRevendedora.Modelos
{
    public abstract class ProdutoBase
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CodigoBarras { get; set; }
        public string Imagem { get; set; }
        public Marca Marca { get; set; }
        public virtual List<Transacao> Transacoes { get; set; } = new List<Transacao>();
        public virtual int EmEstoque { get => Transacoes.Where(x => !x.DataSaida.HasValue).Count(); }
    }
}
