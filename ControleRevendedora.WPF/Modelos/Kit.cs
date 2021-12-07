using System.Collections.Generic;

namespace ControleRevendedora.Modelos
{
    public class Kit : ProdutoBase
    {
        public virtual List<Produto> KitProdutos { get; set; } = new List<Produto>();
    }
}
