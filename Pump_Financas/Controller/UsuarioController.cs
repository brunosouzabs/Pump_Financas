using Model;
using Model.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    class UsuarioController
    {
        Contexto contexto = new Contexto();

        //INSERIR NOVO USUÁRIO
        void Inserir(Usuario u)
        {
            contexto.Usuarios.Add(u);
            contexto.SaveChanges();
        }

        //LISTAS USUÁRIOS
        List<Usuario> ListarTodosUsuarios()
        {
            return contexto.Usuarios.ToList();
        }

        //BUSCA USUÁRIOS POR ID
        Usuario BuscarPorID(int id)
        {
            return contexto.Usuarios.Find(id);
        }

        //EXLUIR USUÁRIOS
        void Excluir(int id)
        {
            Usuario pExcluir = BuscarPorID(id);

            if (pExcluir != null)
            {

                contexto.Usuarios.Remove(pExcluir);
                contexto.SaveChanges();
            }
        }

        //EDITAR USUÁRIOS
        void Editar(int id, Usuario novoDadosUsuario)
        {
            Usuario usuarioAntigo = BuscarPorID(id);

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
        List<Usuario> PesquisarPorNome(string Nome)
        {
            var lista = from u in contexto.Usuarios where u.Nome == Nome select u;
            return lista.ToList();
        }
    }
}
