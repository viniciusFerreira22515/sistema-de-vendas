using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_de_vendas
{
    public class ClienteDAO
    {
        public int gravar(Cliente cliente)
        {
            Banco banco;
            int qtde;

            try
            {
                banco = new Banco();
                banco.comando.CommandText = "INSERT INTO cliente(nome) VALUES(@n)";
                banco.comando.Parameters.Add("@n", NpgsqlDbType.Varchar).Value = cliente.nome;
                banco.comando.Prepare();
                qtde = banco.comando.ExecuteNonQuery();
                Banco.conexao.Close();
                return (qtde);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gravar o cliente: " + ex.Message);
            }
        }

        public int alterar(Cliente cliente)
        {
            Banco banco;
            int qtde;

            try
            {
                banco = new Banco();
                banco.comando.CommandText = "UPDATE cliente SET nome = @n WHERE codigo = @c";
                banco.comando.Parameters.Add("@n", NpgsqlDbType.Varchar).Value = cliente.nome;
                banco.comando.Parameters.Add("@c", NpgsqlDbType.Integer).Value = cliente.codigo;
                banco.comando.Prepare();
                qtde = banco.comando.ExecuteNonQuery();
                Banco.conexao.Close();
                return (qtde);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar o cliente: " + ex.Message);
            }
        }

        public int remover(Cliente cliente)
        {
            Banco banco;
            int qtde;

            try
            {
                banco = new Banco();
                banco.comando.CommandText = "DELETE FROM cliente WHERE codigo = @c";
                banco.comando.Parameters.Add("@c", NpgsqlDbType.Integer).Value = produto.codigo;
                banco.comando.Prepare();
                qtde = banco.comando.ExecuteNonQuery();
                Banco.conexao.Close();
                return (qtde);
            }
            catch (Exception ex)
            { 
                throw new Exception("Erro ao remover o cliente: " + ex.Message);
            }
        }

        public DataTable listar()
        {
            Banco banco;

            try
            {
                banco = new Banco();
                banco.comando.CommandText = "SELECT * FROM cliente ORDER BY 1";
                banco.dreader = banco.comando.ExecuteReader();
                banco.tabela = new DataTable();
                banco.tabela.Load(banco.dreader);
                Banco.conexao.Close();
                return (banco.tabela);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar os clientes: " + ex.Message);
            }
        }
    }
}
