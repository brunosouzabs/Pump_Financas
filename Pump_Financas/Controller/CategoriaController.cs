using Model;
using Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class CategoriaController
    {
        Contexto contexto = new Contexto();

        //INSERIR NOVA CATEGORIA
        public void Inserir(Categoria c)
        {
            contexto.Categorias.Add(c);
            contexto.SaveChanges();
        }

        //LISTAS CATEGORIA
        List<Categoria> ListarTodosCategorias()
        {
            return contexto.Categorias.ToList();
        }

        //BUSCA CATEGORIA POR ID
        Categoria BuscarPorID(int id)
        {
            return contexto.Categorias.Find(id);
        }

        //EXLUIR CATEGORIA
        void Excluir(int id)
        {
            Categoria pExcluir = BuscarPorID(id);

            if (pExcluir != null)
            {

                contexto.Categorias.Remove(pExcluir);
                contexto.SaveChanges();
            }
        }

        //EDITAR CATEGORIA
        void Editar(int id, Categoria novoDadosCategoria)
        {
            Categoria categoriaAntigo = BuscarPorID(id);

            if (categoriaAntigo != null)
            {
                categoriaAntigo.Nome = novoDadosCategoria.Nome;
                categoriaAntigo.Status = novoDadosCategoria.Status;        
                

                contexto.Entry(categoriaAntigo).State =
                System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        //PESQUISAR CATEGORIAS POR NOME
        List<Categoria> PesquisarPorNome(string Categoria)
        {
            var lista = from c in contexto.Categorias where c.Nome == Categoria select c;
            return lista.ToList();
        }
    }
}

