using ControleRevendedora.Contexto;
using ControleRevendedora.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace ControleRevendedora.ViewModels.Kits
{
    public class CriarKitVM
    {
        private RevendedoraContext contexto;
        public List<Produto> Produtos { get; set; }
        public Kit Kit { get; set; } = new Kit();

        public CriarKitVM()
        {
            contexto = new RevendedoraContext();

            Produtos = contexto.Produtos.ToList();

        }
    }
}
