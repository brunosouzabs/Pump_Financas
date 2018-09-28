using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ViewWPF.View
{
    /// <summary>
    /// Lógica interna para ListarProdutos.xaml
    /// </summary>
    public partial class ListarProdutos : Window
    {
        public ListarProdutos()
        {
            InitializeComponent();
        }
        private void dtgProd_Loaded(object sender, RoutedEventArgs e)
        {
            Produto prod = new Produto();
            DataGridTextColumn c1 = new DataGridTextColumn();
            DataGridRow r1 = new DataGridRow();
            c1.Header = "ID Produto";

            List<Produto> produtos = new ProdutoController().ListarTodosProdutos();

            dtgProd.ItemsSource = produtos.ToList();

            DataGridTextColumn c2 = new DataGridTextColumn();
            c2.Header = "Nome do Produto";
            dtgProd.Columns.Add(c2);

            DataGridTextColumn c3 = new DataGridTextColumn();
            c3.Header = "Codigo Interno";
            dtgProd.Columns.Add(c3);

            DataGridTextColumn c4 = new DataGridTextColumn();
            c4.Header = "Quantidade";
            dtgProd.Columns.Add(c4);

            DataGridTextColumn c5 = new DataGridTextColumn();
            c5.Header = "Valor";
            dtgProd.Columns.Add(c5);

            DataGridTextColumn c6 = new DataGridTextColumn();
            c6.Header = "Status";
            dtgProd.Columns.Add(c6);
        }
    }
}
