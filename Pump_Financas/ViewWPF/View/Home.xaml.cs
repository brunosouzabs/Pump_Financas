using Controller;
using System.Windows;

namespace ViewWPF
{
    /// <summary>
    /// Lógica interna para Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnCadastroProd_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.ShowDialog();
        }

        private void btnLogoff_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            this.Close();
            login.ShowDialog();
            
        }

        private void lbltotresult_Loaded(object sender, RoutedEventArgs e)
        {
            lbltotresult.Content = new ProdutoController().TotalProdutos();
        }

        private void btnConfig_Click(object sender, RoutedEventArgs e)
        {
        
        }
    }
}
