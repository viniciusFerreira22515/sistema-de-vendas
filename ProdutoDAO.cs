using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_de_vendas
{
    public class ProdutoDAO
    {
        public int gravar(Produto produto)
        {
            Banco banco;
            int qtde;

            try
            {
                banco = new Banco();
                banco.comando.CommandText = "INSERT INTO produto(descr, preco, qtde) VALUES(@d, @p, @q)";
                banco.comando.Parameters.Add("@d", NpgsqlDbType.Varchar).Value = produto.descr;
                banco.comando.Parameters.Add("@p", NpgsqlDbType.Double).Value = produto.preco;
                banco.comando.Parameters.Add("@q", NpgsqlDbType.Integer).Value = produto.qtde;
                banco.comando.Prepare();
                qtde = banco.comando.ExecuteNonQuery();
                Banco.conexao.Close();
                return (qtde);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gravar o produto: " + ex.Message);
            }
        }

        public int alterar(Produto produto)
        {
            Banco banco;
            int qtde;

            try
            {
                banco = new Banco();
                banco.comando.CommandText = "UPDATE produto SET descr = @n, preco = @p, qtde = @q WHERE codigo = @c";
                banco.comando.Parameters.Add("@d", NpgsqlDbType.Varchar).Value = produto.descr;
                banco.comando.Parameters.Add("@p", NpgsqlDbType.Double).Value = produto.preco;
                banco.comando.Parameters.Add("@q", NpgsqlDbType.Integer).Value = produto.qtde;
                banco.comando.Prepare();
                qtde = banco.comando.ExecuteNonQuery();
                Banco.conexao.Close();
                return (qtde);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar o produto: " + ex.Message);
            }
        }

        public int remover(Produto produto)
        {
            Banco banco;
            int qtde;

            try
            {
                banco = new Banco();
                banco.comando.CommandText = "DELETE FROM produto WHERE codigo = @c";
                banco.comando.Parameters.Add("@c", NpgsqlDbType.Integer).Value = produto.codigo;
                banco.comando.Prepare();
                qtde = banco.comando.ExecuteNonQuery();
                Banco.conexao.Close();
                return (qtde);
            }
            catch (Exception ex)
            { 
                throw new Exception("Erro ao remover o produto: " + ex.Message);
            }
        }
        public DataTable listar()
        {
            Banco banco;

            try
            {
                banco = new Banco();
                banco.comando.CommandText = "SELECT * FROM produto ORDER BY 1";
                banco.dreader = banco.comando.ExecuteReader();
                banco.tabela = new DataTable();
                banco.tabela.Load(banco.dreader);
                Banco.conexao.Close();
                return (banco.tabela);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar os produtos: " + ex.Message);
            }
        }
    }
}
