using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewWPF.ViewModel
{
    
    public class UserViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region UserViewModel
        private int usuarioID;
        public int UsuarioID
        {
            get { return usuarioID; }
            set
            {
                usuarioID = value;
                NotifyPropertyChanged("UsuarioID");
            }
        }
        private string nome;
        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value;
                NotifyPropertyChanged("Nome");
            }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                NotifyPropertyChanged("Email");
            }
        }
        private int perfil;
        public int Perfil
        {
            get { return perfil; }
            set
            {
                perfil = value;
                NotifyPropertyChanged("Perfil");
            }
        }
        private string senha;
        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                NotifyPropertyChanged("Senha");
            }
        }
        private bool status;
        public bool Status
        {
            get { return status; }
            set
            {
                status = value;
                NotifyPropertyChanged("Status");
            }
        }
        #endregion
    }
}
