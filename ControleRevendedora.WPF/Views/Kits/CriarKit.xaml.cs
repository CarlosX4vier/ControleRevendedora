using ControleRevendedora.ViewModels.Kits;
using System.Windows;

namespace ControleRevendedora.Views.Kits
{
    /// <summary>
    /// Lógica interna para CriarKit.xaml
    /// </summary>
    public partial class CriarKit : Window
    {
        private CriarKitVM VM = new CriarKitVM();
        public CriarKit()
        {
            InitializeComponent();
            DataContext = VM;
        }
    }
}
