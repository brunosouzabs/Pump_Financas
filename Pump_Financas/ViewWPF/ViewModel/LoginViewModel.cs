using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewWPF.ViewModel
{
    class LoginViewModel
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region LoginViewModel
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
        #endregion
    }
}
