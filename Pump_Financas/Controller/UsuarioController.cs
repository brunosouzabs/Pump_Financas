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
            List<Usuario> usuarios = new UsuarioController().ListarTodosUsuarios();
            foreach (Usuario item in usuarios)
            {
                if(item.User == user)
                {
                    return item;
                }
            }
            return null;
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
        public void Excluir(string user)
        {
            Usuario uExcluir = BuscarPorUser(user);

            if (uExcluir != null)
            {
                contexto.Usuarios.Remove(contexto.Usuarios.Find(uExcluir.ID));
                contexto.SaveChanges();
            }
        }

        //EDITAR USUÁRIOS
        public void Editar(string user, Usuario novoDadosUsuario)
        {
            Usuario usuarioAntigo = BuscarPorUser(user);

            if (usuarioAntigo != null)
            {
                usuarioAntigo.Nome = novoDadosUsuario.Nome;
                usuarioAntigo.Perfil = novoDadosUsuario.Perfil;

                contexto.Entry(usuarioAntigo).State =
                System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        //PESQUISAR USUÁRIOS POR NOME
        public List<Usuario> PesquisarPorUser(string user)
        {
            var lista = from u in contexto.Usuarios where u.User == user select u;
            return lista.ToList();
        }
    }
}
