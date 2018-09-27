using Controller;
using Model;
using Model.DAL;
using System.Collections.Generic;
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
                Status = true
            };
            switch (cbxPerfil.Text)
            {
                case "Administrador":
                    u.Perfil = 1;
                break;
                case "Usuário Padrão":
                    u.Perfil = 2;
                    break;
                case "Convidado":
                    u.Perfil = 3;
                    break;
            }
            if (pwbSenha.Password != pwbConfirmaSenha.Password)
            {              
                pwbSenha.Clear();
                pwbConfirmaSenha.Clear();
                MessageBox.Show("Senhas não conferem");
            }
            else
            {
                u.Senha = pwbSenha.Password;
            }           
            if(txtNome.Text=="" || txtEmail.Text=="" || cbxPerfil.Text=="" || pwbSenha.Password=="" || pwbConfirmaSenha.Password == "")
            {
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                if(new UsuarioController().BuscarPorEmail(u.Email) != null)
                {
                    txtEmail.Clear();
                    MessageBox.Show("Usuário já existe");
                }
                else
                {
                    new UsuarioController().Inserir(u);
                    this.Close();
                }
            }
            
        }
        private void btnCancelarUser_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbxSelectUser_Loaded(object sender, RoutedEventArgs e)
        {

            List<Usuario> usuarios = new UsuarioController().ListarTodosUsuarios();

            foreach (Usuario item in usuarios)
            {
                cbxSelectUser.Items.Add(item.Nome);
            }
            
;        }
    }
 }
