using Model;
using Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ProdutoController
    {
        Contexto contexto = new Contexto();

        //INSERIR NOVO PRODUTO
        public void Inserir(Produto p)
        {
            contexto.Produtos.Add(p);
            contexto.SaveChanges();
        }

        //LISTAS PRODUTO
        List<Produto> ListarTodosProdutos()
        {
            return contexto.Produtos.ToList();
        }

        //BUSCA PRODUTO POR ID
        Produto BuscarPorID(int id)
        {
            return contexto.Produtos.Find(id);
        }

        //EXLUIR PRODUTO
        void Excluir(int id)
        {
            Produto pExcluir = BuscarPorID(id);

            if (pExcluir != null)
            {

                contexto.Produtos.Remove(pExcluir);
                contexto.SaveChanges();
            }
        }

        //EDITAR PRODUTO
        void Editar(int id, Produto novoDadosProduto)
        {
            Produto produtoAntigo = BuscarPorID(id);

            if (produtoAntigo != null)
            {
                produtoAntigo.Codigo = novoDadosProduto.Codigo;
                produtoAntigo.Nome = novoDadosProduto.Nome;
                produtoAntigo.Categoria = novoDadosProduto.Categoria;
                produtoAntigo.Valor = novoDadosProduto.Valor;
                produtoAntigo.Quantidade = novoDadosProduto.Quantidade;
                produtoAntigo.Status = novoDadosProduto.Status;
                


                contexto.Entry(produtoAntigo).State =
                System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        //PESQUISAR PRODUTOS POR NOME
        List<Produto> PesquisarPorNome(string Nome)
        {
            var lista = from p in contexto.Produtos where p.Nome == Nome select p;
            return lista.ToList();
        }
    }
}

