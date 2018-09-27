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
    /// Lógica interna para EditProduto.xaml
    /// </summary>
    public partial class EditProduto : Window
    {
        public EditProduto()
        {
            InitializeComponent();
        }

        private void btnBuscarProd_Click(object sender, RoutedEventArgs e)
        {
            if (cbxEditProduto.SelectedIndex == -1) { MessageBox.Show("Selecione um produto para buscar os dados"); }
            else
            {
                Produto produto = new ProdutoController().BuscarPorNome(cbxEditProduto.Text);
                txtCodInt.Text = produto.CodInterno;
                txtEditQuantidade.Text = Convert.ToString(produto.Quantidade);
                txtEditValor.Text = Convert.ToString(produto.Valor);
            }
        }

        private void cbxEditProduto_Loaded(object sender, RoutedEventArgs e)
        {
            List<Produto> produtos = new ProdutoController().ListarTodosProdutos();

            foreach (Produto item in produtos)
            {
                cbxEditProduto.Items.Add(item.Nome);
            }
        }
    }
}
