using ControleRevendedora.Contexto;
using ControleRevendedora.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ControleRevendedora.ViewModels.Kits
{
    public class CriarKitVM :ViewModelBase
    {
        private RevendedoraContext contexto;
        public List<Produto> Produtos { get; set; }
        public Kit Kit { get; set; } = new Kit();

        public CriarKitVM()
        {
            contexto = new RevendedoraContext();

            Produtos = contexto.Produtos.ToList();
        }


        public async System.Threading.Tasks.Task<List<Produto>> ProcurarProdutos(string nome)
        {
            if (!string.IsNullOrEmpty(nome))
                Produtos = await contexto.Produtos.Where(p => p.Nome.Contains(nome)).ToListAsync();
            else
                Produtos = await contexto.Produtos.ToListAsync();
            OnPropertyChanged(nameof(this.Produtos));
            return Produtos;
        }
    }
}
