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
                if(produto.Status == true) { cbxEditProdAtivo.IsChecked = true; };
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

        private void btnSaveEditProd_Click(object sender, RoutedEventArgs e)
        {
            Produto p = new Produto();
            p.Nome = cbxEditProduto.Text;
            p.CodInterno = txtCodInt.Text;
            if (txtEditQuantidade.Text != "")
            {
                p.Quantidade = Convert.ToInt32(txtEditQuantidade.Text);
            }
            if (txtEditValor.Text != "")
            {
                p.Valor = Convert.ToDecimal(txtEditValor.Text);
            }           
            if (cbxEditProdAtivo.IsChecked == true) { p.Status = true; } else { p.Status = false; }
            if (txtCodInt.Text == "" || txtEditQuantidade.Text == "" || txtEditValor.Text == "" )
            {
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                new ProdutoController().Editar(p.Nome, p);
                MessageBox.Show("Produto alterado com sucesso!");
                cbxEditProduto.SelectedIndex = -1;
                txtCodInt.Clear();
                txtEditQuantidade.Clear();
                txtEditValor.Clear();
                cbxEditProdAtivo.IsChecked = false;
            }
        }

        private void btnCancelEditProd_Click(object sender, RoutedEventArgs e)
        {
            Product prod = new Product();
            this.Close();
            prod.ShowDialog();
        }

        private void btnExcluirProd_Click(object sender, RoutedEventArgs e)
        {
            if (new ProdutoController().BuscarPorNome(cbxEditProduto.Text) != null)
            {
                if (MessageBox.Show("Deseja realmente excluir este produto?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    cbxEditProduto.SelectedIndex = -1;
                    txtCodInt.Clear();
                    txtEditQuantidade.Clear();
                    txtEditValor.Clear();
                    cbxEditProdAtivo.IsChecked = false;
                }
                else
                {
                    new ProdutoController().Excluir(cbxEditProduto.Text);
                    MessageBox.Show("Produto excluído com sucesso!");
                    EditProduto edit = new EditProduto();
                    this.Close();
                    edit.ShowDialog();
                }
            }
            else { MessageBox.Show("Selecione um produto para exclusão"); }
        }
    }
}
