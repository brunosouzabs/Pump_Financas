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
using System.Windows.Shapes;

namespace ViewWPF
{
    /// <summary>
    /// Lógica interna para User.xaml
    /// </summary>
    public partial class User : Window
    {
        Contexto contexto = new Contexto();

        public User()
        {
            InitializeComponent();
        }

        private void ltbPerfil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbxPerfil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSalvarUser_Click(object sender, RoutedEventArgs e)
        {
            Usuario u = new Usuario
            {
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Perfil = 1,
                Status = true
            };
            if (pwbSenha.Password == pwbConfirmaSenha.Password)
            {
                u.Senha = pwbSenha.Password;
            }
            else
                lblConfirmacaoUser.Content = "Senhas não conferem";

            contexto.SaveChanges();
            Close();
        }

    }
}
