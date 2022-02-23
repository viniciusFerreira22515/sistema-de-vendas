using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_de_vendas
{
    public class ItemDAO
    {
        public int gravar(Item item)
        {
            Banco banco;
            int qtde;

            try
            {
                banco = new Banco();
                banco.comando.CommandText = "INSERT INTO item(qtde, valor, codproduto, codvenda) VALUES(@q, @v, @cp, @cv)";
                banco.comando.Parameters.Add("@q", NpgsqlDbType.Integer).Value = item.qtde;
                banco.comando.Parameters.Add("@v", NpgsqlDbType.Double).Value = item.valor;
                banco.comando.Parameters.Add("@cp", NpgsqlDbType.Integer).Value = item.codproduto;
                banco.comando.Parameters.Add("@cv", NpgsqlDbType.Integer).Value = item.codvenda;
                banco.comando.Prepare();
                qtde = banco.comando.ExecuteNonQuery();
                Banco.conexao.Close();
                return (qtde);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gravar o item: " + ex.Message);
            }
        }

        public int alterar(Item item)
        {
            Banco banco;
            int qtde;

            try
            {
                banco = new Banco();
                banco.comando.CommandText = "UPDATE item SET qtde = @q, valor = @v, codproduto = @cp, codvenda = @cv WHERE codigo = @c";
                banco.comando.Parameters.Add("@q", NpgsqlDbType.Integer).Value = item.qtde;
                banco.comando.Parameters.Add("@v", NpgsqlDbType.Double).Value = item.valor;
                banco.comando.Parameters.Add("@cp", NpgsqlDbType.Integer).Value = item.codproduto;
                banco.comando.Parameters.Add("@cv", NpgsqlDbType.Integer).Value = item.codvenda;
                banco.comando.Prepare();
                qtde = banco.comando.ExecuteNonQuery();
                Banco.conexao.Close();
                return (qtde);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar o item: " + ex.Message);
            }
        }

        public int remover(Item item)
        {
            Banco banco;
            int qtde;

            try
            {
                banco = new Banco();
                banco.comando.CommandText = "DELETE FROM item WHERE codigo = @c";
                banco.comando.Parameters.Add("@c", NpgsqlDbType.Integer).Value = item.codigo;
                banco.comando.Prepare();
                qtde = banco.comando.ExecuteNonQuery();
                Banco.conexao.Close();
                return (qtde);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover o item: " + ex.Message);
            }
        }
        public DataTable listar()
        {
            Banco banco;

            try
            {
                banco = new Banco();
                banco.comando.CommandText = "SELECT * FROM item ORDER BY 1";
                banco.dreader = banco.comando.ExecuteReader();
                banco.tabela = new DataTable();
                banco.tabela.Load(banco.dreader);
                Banco.conexao.Close();
                return (banco.tabela);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar os itens: " + ex.Message);
            }
        }
    }
}
