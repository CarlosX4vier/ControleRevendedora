using System.Collections.Generic;

namespace ControleRevendedora.Modelos
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "Não identificada";
        public virtual List<Produto> Produtos { get; set; }
    }
}
