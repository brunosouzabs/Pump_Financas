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
        public Usuario BuscarPorEmail(string email)
        {
            return contexto.Usuarios.Find(email);
        }

        public Usuario ValidarLogin(string email, string senha)
        {
            if (new UsuarioController().BuscarPorEmail(email) == null)
            {
                return null;
            }
            else
            {
                Usuario u = new Usuario();
                u = BuscarPorEmail(email);
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
        void Excluir(string email)
        {
            Usuario pExcluir = BuscarPorEmail(email);

            if (pExcluir != null)
            {

                contexto.Usuarios.Remove(pExcluir);
                contexto.SaveChanges();
            }
        }

        //EDITAR USUÁRIOS
        void Editar(string email, Usuario novoDadosUsuario)
        {
            Usuario usuarioAntigo = BuscarPorEmail(email);

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
