using Model;
using Model.DAL;
using System.Windows;
using System.Windows.Controls;

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

            contexto.Usuarios.Add(u);
            contexto.SaveChanges();
        }

    }
}
