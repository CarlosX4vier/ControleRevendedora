﻿using ControleRevendedora.Contexto;
using ControleRevendedora.Modelos;
using ControleRevendedora.Relatorios;
using ControleRevendedora.ViewModels.Kits;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ControleRevendedora.Views.Kits
{
    /// <summary>
    /// Lógica interna para ProdutosView.xaml
    /// </summary>
    public partial class VerKits : Window
    {
        public VerKitsVM VM = new VerKitsVM();
        public RevendedoraContext Contexto = new RevendedoraContext();

        public VerKits()
        {
            InitializeComponent();
            DataContext = VM;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var kit = (Kit)btn.DataContext;
            var tela = new CriarKit((Kit)dgProdutos.SelectedItem);
            tela.Show();
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            var kitSelecionado = (Kit) dgProdutos.SelectedItem;

            ExportarKits exportar = new ExportarKits(kitSelecionado);
            exportar.Exportar();
        }
    }
}
