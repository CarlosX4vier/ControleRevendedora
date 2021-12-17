using ControleRevendedora.Modelos;
using System.Collections.ObjectModel;

namespace ControleRevendedora.ViewModels.Estoque
{
    public class CadastroEstoqueVM
    {
        public RangeObservableCollection<ProdutoBase> Produtos { get; set; } = new RangeObservableCollection<ProdutoBase>();
        public long? CodigoBarra { get; set; }
        public bool ViaLeitor { get; set; } = true;
        public long ProdutoSelecionado { get; set; }
    }
}
