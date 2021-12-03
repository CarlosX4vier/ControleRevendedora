using ControleRevendedora.Configuracao;
using ControleRevendedora.Helpers;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;

namespace ControleRevendedora.Servicos
{
    public class CosmosServico
    {
        public Modelos.Produto BuscarProduto(long codigoBarras)
        {
            var url = $"https://api.cosmos.bluesoft.com.br/gtins/{codigoBarras.ToString()}.json";
            CosmosWebClient wc = new CosmosWebClient();
            string response = wc.DownloadString(url);
            var produtoVO = JsonConvert.DeserializeObject<ProdutoVO>(response);
            var produto = AutoMapperConfig.AutoMapper.Map<Modelos.Produto>(produtoVO);

            return produto;
        }

        public class CosmosWebClient : WebClient
        {
            protected readonly string CacheAPI = "cosmosAPIOrdem";
            protected string SelecionarToken()
            {
                var tokens = ConfigurationManager.AppSettings.Get("CosmosKey").Split(';');
                int proximaChave = TokenUtils.Selecionar(tokens.Length, CacheAPI);
                return tokens == null ? "DtJyL0uVt7LL96mTBv4Hbg" : tokens[proximaChave];
            }

            protected override WebRequest GetWebRequest(Uri address)
            {
                string cosmosKey = SelecionarToken();
                HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
                request.UserAgent = "Cosmos-API-Request";
                request.Headers["X-Cosmos-Token"] = cosmosKey;
                base.Encoding = System.Text.Encoding.UTF8;
                return request;
            }
        }
    }
}
