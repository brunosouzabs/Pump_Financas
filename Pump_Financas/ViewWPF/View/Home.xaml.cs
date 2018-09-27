using Controller;
using Model;
using System;
using System.Collections.Generic;
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
            this.Close();
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

        private void lbltotValEstoque_Loaded(object sender, RoutedEventArgs e)
        {
            lbltotValEstoque.Content = "R$" + new ProdutoController().ValorTotalEstoque();
        }

        private void cbxBuscaProdHome_Loaded(object sender, RoutedEventArgs e)
        {
            List<Produto> produtos = new ProdutoController().ListarTodosProdutos();

            foreach (Produto item in produtos)
            {
                cbxBuscaProdHome.Items.Add(item.Nome);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cbxBuscaProdHome.SelectedIndex == -1) { MessageBox.Show("Selecione um produto para buscar os dados"); }
            else
            {
                Produto produto = new ProdutoController().BuscarPorNome(cbxBuscaProdHome.Text);
                lblQtdEstoque.Content = produto.Quantidade;
                lblValorUnidade.Content = "R$" + produto.Valor;
                lblValorTotalLote.Content = "R$" + produto.Valor * produto.Quantidade;
                lblCodInterno.Content = produto.CodInterno;
            }
        }
    }
}
