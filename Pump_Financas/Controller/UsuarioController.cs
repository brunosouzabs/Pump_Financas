using Model;
using Model.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    class UsuarioController
    {
        Contexto contexto = new Contexto();

        void Inserir(Usuario u)
        {
            contexto.Usuarios.Add(u);
            contexto.SaveChanges();
        }

        List<Usuario> ListarTodosPerson()
        {

            return contexto.Usuarios.ToList();
        }

        Usuario BuscarPorID(int id)
        {

            return contexto.Usuarios.Find(id);
        }

        void Excluir(int id)
        {
            Usuario pExcluir = BuscarPorID(id);

            if (pExcluir != null)
            {

                contexto.Usuarios.Remove(pExcluir);
                contexto.SaveChanges();
            }
        }

        void Editar(int id, Usuario novoDadosPerson)
        {
            Usuario personAntigo = BuscarPorID(id);

            if (personAntigo != null)
            {
                personAntigo.FirstName = novoDadosPerson.FirstName;
                personAntigo.LastName = novoDadosPerson.LastName;
                personAntigo.Title = novoDadosPerson.Title;

                contexto.Entry(personAntigo).State =
     System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        List<Usuario> PesquisarPorNome(string Nome)
        {

            var lista = from u in contexto.Usuarios
                        where u.Nome == Nome
                        select u;

            return lista.ToList();
        }
    }
}
