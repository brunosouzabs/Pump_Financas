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

        private void cbxSelectUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxSelectUser.SelectedIndex.Equals("teste1"))
            {
                txtNomeEdit.Text = "teste1";
            }
        }

        private void btnCancelEdit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
            Usuario usuario = new UsuarioController().BuscarPorUser(cbxSelectUser.Text);
            txtNomeEdit.Text = usuario.Nome;
            if(usuario.Perfil == true)
            {
                cbxEditAdmin.IsChecked = true;
            }
            if(usuario.Status == true)
            {
                cbxEditStatus.IsChecked = true;
            }
        }

        private void btnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
