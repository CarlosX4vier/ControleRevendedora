using ControleRevendedora.Contexto;
using ControleRevendedora.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ControleRevendedora.ViewModels.Kits
{
    public class VerKitsVM : ViewModelBase
    {
        public RevendedoraContext Contexto { get; set; }
        public List<Kit> Kits { get; set; }
        public VerKitsVM()
        {
            Contexto = new RevendedoraContext();
            Kits = Contexto.Kits.Include(x => x.Transacoes).OrderByDescending(x => x.Id).ToList();
        }
    }
}
