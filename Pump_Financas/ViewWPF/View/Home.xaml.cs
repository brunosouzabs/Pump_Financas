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
    }
}
