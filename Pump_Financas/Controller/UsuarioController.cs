using Model;
using Model.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Controller
{
    public class UsuarioController
    {
        Contexto contexto = new Contexto();

        //INSERIR NOVO USUÁRIO
        public void Inserir(Usuario u)
        {
            contexto.Usuarios.Add(u);
            contexto.SaveChanges();
        }

        //LISTAS USUÁRIOS
        public List<Usuario> ListarTodosUsuarios()
        {
            return contexto.Usuarios.ToList();
        }

        //BUSCA USUÁRIOS POR ID
        public Usuario BuscarPorUser(string user)
        {
            return contexto.Usuarios.Find(user);
        }

        public Usuario ValidarLogin(string user, string senha)
        {
            if (new UsuarioController().BuscarPorUser(user) == null)
            {
                return null;
            }
            else
            {
                Usuario u = new Usuario();
                u = BuscarPorUser(user);
                if (u.Senha == senha)
                {
                    return u;
                }
                else
                {
                    return null;
                }
            }

        }
        //EXLUIR USUÁRIOS
        void Excluir(string user)
        {
            Usuario pExcluir = BuscarPorUser(user);

            if (pExcluir != null)
            {

                contexto.Usuarios.Remove(pExcluir);
                contexto.SaveChanges();
            }
        }

        //EDITAR USUÁRIOS
        void Editar(string user, Usuario novoDadosUsuario)
        {
            Usuario usuarioAntigo = BuscarPorUser(user);

            if (usuarioAntigo != null)
            {
                usuarioAntigo.Nome = novoDadosUsuario.Nome;
                usuarioAntigo.Email = novoDadosUsuario.Email;
                usuarioAntigo.Perfil = novoDadosUsuario.Perfil;

                contexto.Entry(usuarioAntigo).State =
                System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        //PESQUISAR USUÁRIOS POR NOME
        public List<Usuario> PesquisarPorNome(string Nome)
        {
            var lista = from u in contexto.Usuarios where u.Email == Nome select u;
            return lista.ToList();
        }
    }
}
