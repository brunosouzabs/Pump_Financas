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
    /// Lógica interna para EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        public EditUser()
        {
            InitializeComponent();
        }
        private void btnCancelEdit_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            this.Close();
            user.ShowDialog();
        }

        private void cbxSelectUser_Loaded(object sender, RoutedEventArgs e)
        {
            List<Usuario> usuarios = new UsuarioController().ListarTodosUsuarios();

            foreach (Usuario item in usuarios)
            {
                cbxSelectUser.Items.Add(item.User);
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if(cbxSelectUser.SelectedIndex == -1) { MessageBox.Show("Selecione um usuário para buscar os dados"); }
            else
            {
                Usuario usuario = new UsuarioController().BuscarPorUser(cbxSelectUser.Text);
                txtNomeEdit.Text = usuario.Nome;
                if (usuario.Perfil == true)
                {
                    cbxEditAdmin.IsChecked = true;
                }
                if (usuario.Status == true)
                {
                    cbxEditStatus.IsChecked = true;
                }
            }
        }

        private void btnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            Usuario u = new Usuario();
            u.User = cbxSelectUser.Text;
            u.Nome = txtNomeEdit.Text;
            if (cbxEditAdmin.IsChecked == true) { u.Perfil = true; } else { u.Perfil = false; }
            if (cbxEditStatus.IsChecked == true) { u.Status = true; } else { u.Status = false; }
            if (pwdEditPassUser.Password != pwdEditConfirmPassUser.Password)
            {
                pwdEditPassUser.Clear();
                pwdEditConfirmPassUser.Clear();
                MessageBox.Show("Senhas não conferem");
            }
            else
            {
                u.Senha = pwdEditPassUser.Password;
            }
            if (txtNomeEdit.Text == "" || pwdEditPassUser.Password == "" || pwdEditConfirmPassUser.Password == "")
            {
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                new UsuarioController().Editar(u.User,u);
                MessageBox.Show("Usuário alterado com sucesso!");
                cbxSelectUser.SelectedIndex = -1;
                txtNomeEdit.Clear();
                cbxEditAdmin.IsChecked = false;
                cbxEditStatus.IsChecked = false;
            }
        }

        private void btnExcluirUser_Click(object sender, RoutedEventArgs e)
        {
            if(new UsuarioController().BuscarPorUser(cbxSelectUser.Text) != null)
            {
                if(MessageBox.Show("Deseja realmente excluir este usuário?","Question",MessageBoxButton.YesNo,MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    cbxSelectUser.SelectedIndex = -1;
                    txtNomeEdit.Clear();
                    cbxEditAdmin.IsChecked = false;
                    cbxEditStatus.IsChecked = false;

                }
                else
                {
                    new UsuarioController().Excluir(cbxSelectUser.Text);
                    MessageBox.Show("Usuário excluído com sucesso!");
                    EditUser edit = new EditUser();
                    this.Close();
                    edit.ShowDialog();

                }
            }
            else { MessageBox.Show("Selecione um usuário para exclusão"); }
        }
    }
}
