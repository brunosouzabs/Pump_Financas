using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class Contexto : DbContext
    {
        public Contexto() : base("pumpestoque")
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Produto> Perfil { get; set; }
        public DbSet<Produto> Categoria { get; set; }
    }
}
