using ControleRevendedora.Modelos;
using System.Collections.ObjectModel;

namespace ControleRevendedora.ViewModels.Estoque
{
    public class CadastroEstoqueVM
    {
        public RangeObservableCollection<Produto> Produtos { get; set; } = new RangeObservableCollection<Produto>();
        public long? CodigoBarra { get; set; }
        public bool ViaLeitor { get; set; } = true;
        public int ProdutoSelecionado { get; set; }
    }
}
