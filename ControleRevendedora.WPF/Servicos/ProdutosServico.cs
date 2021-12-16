using ControleRevendedora.Contexto;
using ControleRevendedora.Modelos;
using System;
using System.Linq;

namespace ControleRevendedora.Servicos
{
    public class ProdutosServico
    {
        public ProdutoBase Buscar(RevendedoraContext revendedoraContext, string codigoBarras)
        {
            ProdutoBase produto = revendedoraContext.ProdutosBase.FirstOrDefault(e => e.CodigoBarras == codigoBarras);
            if (produto == null)
            {
                CosmosServico cosmosServico = new CosmosServico();
                produto = cosmosServico.BuscarProduto(codigoBarras);
                if (String.IsNullOrEmpty(produto.Marca.Nome))
                    produto.Marca = null;
                else
                {
                    var aux = revendedoraContext.Marcas.First(x => x.Nome == produto.Marca.Nome);
                    if (aux != null)
                    {
                        produto.Marca = aux;
                    }
                }

                revendedoraContext.Produtos.AddIfNotExists<Produto>(produto, x => x.CodigoBarras == produto.CodigoBarras);
                revendedoraContext.SaveChangesAsync();
            }

            return revendedoraContext.Produtos.FirstOrDefault(e => e.CodigoBarras == codigoBarras);
        }
    }
}
