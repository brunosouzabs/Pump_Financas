using Controller;
using Model;
using Model.DAL;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ViewWPF.View;

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
                User = txtUser.Text,
                Nome = txtNome.Text,
                Status = true
            };
            if (ckbAdm.IsEnabled)
            {
                u.Perfil = true;
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
            if(txtNome.Text=="" || pwbSenha.Password=="" || pwbConfirmaSenha.Password == "")
            {
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                if(new UsuarioController().BuscarPorUser(u.User) != null)
                {
                    txtUser.Clear();
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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditarUser_Click(object sender, RoutedEventArgs e)
        {
            EditUser edituser = new EditUser();
            edituser.ShowDialog();
        }
    }
 }
