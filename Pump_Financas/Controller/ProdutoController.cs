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
        public void Inserir(Produto u)
        {
            contexto.Produtos.Add(u);
            contexto.SaveChanges();
        }

        //LISTAS PRODUTO
        public List<Produto> ListarTodosProdutos()
        {
            return contexto.Produtos.ToList();
        }

        //BUSCA PRODUTO POR Nome
        public Produto BuscarPorNome(string nome)
        {
            List<Produto> produtos = new ProdutoController().ListarTodosProdutos();
            foreach (Produto item in produtos)
            {
                if (item.Nome == nome)
                {
                    return item;
                }
            }
            return null;
        }
        //EXLUIR PRODUTO
        public void Excluir(string nome)
        {
            Produto uExcluir = BuscarPorNome(nome);

            if (uExcluir != null)
            {
                contexto.Produtos.Remove(contexto.Produtos.Find(uExcluir.ProdutoID));
                contexto.SaveChanges();
            }
        }

        //EDITAR PRODUTO
        public void Editar(string nome, Produto novoDadosProduto)
        {
            Produto produtoAntigo = BuscarPorNome(nome);

            if (produtoAntigo != null)
            {
                produtoAntigo.Nome = novoDadosProduto.Nome;
                produtoAntigo.CodInterno = novoDadosProduto.CodInterno;
                produtoAntigo.Valor = novoDadosProduto.Valor;
                produtoAntigo.Quantidade = novoDadosProduto.Quantidade;
                produtoAntigo.Status = novoDadosProduto.Status;
                contexto.Entry(produtoAntigo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        //PESQUISAR PRODUTO POR NOME
        public List<Produto> PesquisarPorNome(string nome)
        {
            var lista = from p in contexto.Produtos where p.Nome == nome select p;
            return lista.ToList();
        }

        //RETORNA O NUMERO TOTAL DE PRODUTOS DIFERENTES EM ESTOQUE
        public int TotalProdutos()
        {
            int count = 0;
            List<Produto> produtos = new ProdutoController().ListarTodosProdutos();
            foreach (Produto item in produtos)
            {
                count += 1;
            }
            return count;
        }

        //RETORNAR O VALOR TOTAL DE TODOS OS PRODUTOS JUNTOS EM ESTOQUE
        public decimal ValorTotalEstoque()
        {
            decimal count = 0;
            List<Produto> produtos = new ProdutoController().ListarTodosProdutos();
            foreach (Produto item in produtos)
            {
                count += item.Valor;
            }
            return count;
        }
    }
}

