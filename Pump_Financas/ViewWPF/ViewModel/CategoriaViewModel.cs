using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewWPF.ViewModel
{
    class CategoriaViewModel    
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region CategoriaViewModel 
        private int categoriaID;
        public int CategoriaID
        {
            get { return categoriaID; }
            set
            {
                categoriaID = value;
                NotifyPropertyChanged("CategoriaID");
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