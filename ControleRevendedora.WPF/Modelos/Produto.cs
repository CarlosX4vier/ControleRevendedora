using System.Collections.Generic;

namespace ControleRevendedora.Modelos
{
    public class Produto : ProdutoBase
    {
        public virtual List<Kit> Kits { get; set; }
    }
}
