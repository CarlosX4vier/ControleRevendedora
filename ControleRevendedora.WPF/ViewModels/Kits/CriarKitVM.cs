﻿using ControleRevendedora.Contexto;
using ControleRevendedora.Modelos;
using ControleRevendedora.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ControleRevendedora.ViewModels.Kits
{
    public class CriarKitVM : ViewModelBase
    {
        private RevendedoraContext contexto = new RevendedoraContext();
        public List<Produto> Produtos { get; set; }
        public Kit Kit { get; set; } = new Kit();

        public CriarKitVM()
        {
            Produtos = contexto.Produtos.ToList();
        }

        public CriarKitVM(Kit kit)
        {
            Kit = contexto.Kits.First(k => k.Id == kit.Id);
            Produtos = contexto.Produtos.ToList();
        }

        public void ProcurarProdutos(string nome)
        {
            using (var contextoAsync = new RevendedoraContext())
            {
                if (!string.IsNullOrEmpty(nome))
                    Produtos = contextoAsync.Produtos.Where(p => p.Nome.Contains(nome)).ToList();
                else
                    Produtos = contextoAsync.Produtos.ToList();
                OnPropertyChanged(nameof(this.Produtos));
            }
        }

        public bool CriarKit()
        {
            var transacao = contexto.Database.BeginTransaction();
            contexto.Add(Kit);
            var resultado = contexto.SaveChanges() > 0;
            if (resultado)
            {
                Kit.CodigoBarras = CodigoBarrasUtils.Gerar(Kit.Id.ToString());
                contexto.SaveChanges();
            }
            transacao.Commit();
            return resultado;
        }

        public bool AtualizarKit()
        {
            return contexto.SaveChanges() > 0;
        }
    }
}