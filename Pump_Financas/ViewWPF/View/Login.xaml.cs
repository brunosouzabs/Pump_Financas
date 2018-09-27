using Controller;
using Model;
using Model.DAL;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ViewWPF
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        Contexto contexto = new Contexto();

        public MainWindow()
        {
            InitializeComponent();
       
        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            if(new UsuarioController().ValidarLogin(txtLogin.Text, pwbLogin.Password) != null)
            {
                Home home = new Home();
                home.ShowDialog();
            }
            else
            {
                txtLogin.Clear();
                pwbLogin.Clear();
                MessageBox.Show("Usuário ou Senha inválido");
            }
        }

        private void btnCadastrarNovoUser_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.ShowDialog();
        }
    }
}
