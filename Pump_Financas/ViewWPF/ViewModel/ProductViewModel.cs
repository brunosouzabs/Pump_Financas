using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewWPF.ViewModel
{
    class ProductViewModel
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region ProductViewModel
        private int produtoID;
        public int ProdutoID
        {
            get { return produtoID; }
            set
            {
                produtoID = value;
                NotifyPropertyChanged("ProdutoID");
            }
        }
        private int codigo;
        public int Codigo
        {
            get { return codigo; }
            set
            {
                codigo = value;
                NotifyPropertyChanged("Codigo");
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
        private int categoria;
        public int Categoria
        {
            get { return categoria; }
            set
            {
                categoria = value;
                NotifyPropertyChanged("Categoria");
            }
        }
        private decimal valor;
        public decimal Valor
        {
            get { return valor; }
            set
            {
                valor = value;
                NotifyPropertyChanged("Valor");
            }
        }
        private int quantidade;
        public int Quantidade
        {
            get { return quantidade; }
            set
            {
                quantidade = value;
                NotifyPropertyChanged("Quantidade");
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
        private string status;
        public string Status
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
