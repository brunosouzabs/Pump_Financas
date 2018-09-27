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
using System.Text.RegularExpressions;
using ViewWPF.View;

namespace ViewWPF
{
    /// <summary>
    /// Lógica interna para Product.xaml
    /// </summary>
    public partial class Product : Window
    {
        public Product()
        {
            InitializeComponent();
        }

        private void cbxCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Produto p = new Produto
            {
                Nome = txtNome.Text,
                CodInterno = txtCodigo.Text,
                Status = true,
            };
            if (txtQuantidade.Text != "")
            {
                p.Quantidade = Convert.ToInt32(txtQuantidade.Text);
            }
            if (txtValor.Text != "")
            {
                p.Valor = Convert.ToDecimal(txtValor.Text);
            }
            if (txtNome.Text=="" || txtCodigo.Text =="" || txtValor.Text == "" || txtQuantidade.Text == "")
            {
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                new ProdutoController().Inserir(p);
                Home home = new Home();
                this.Close();
                home.ShowDialog();
            }         
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            EditProduto editProd = new EditProduto();
            this.Close();
            editProd.ShowDialog();
        }
    }
}
