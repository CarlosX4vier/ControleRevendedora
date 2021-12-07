using System.Collections.Generic;

namespace ControleRevendedora.Modelos
{
    public class Produto : ProdutoBase
    {
        public List<Kit> Kits { get; set; }
    }
}
