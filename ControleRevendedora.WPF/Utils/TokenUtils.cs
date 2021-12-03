using System;
using System.Runtime.Caching;

namespace ControleRevendedora.Helpers
{
    public class TokenUtils
    {
        public static int Selecionar(int tamanho, string nomeCache)
        {
            MemoryCache cache = MemoryCache.Default;
            int proximaChave = (int)(cache.Get(nomeCache) ?? 0);

            if (proximaChave > tamanho - 1)
            {
                proximaChave = 0;
            }
            cache.Set(nomeCache, proximaChave + 1, new CacheItemPolicy { SlidingExpiration = TimeSpan.FromMinutes(180) });
            return proximaChave;
        }
    }
}
