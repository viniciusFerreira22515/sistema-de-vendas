using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_de_vendas
{
    public class VendaDAO
    {
        public int gravar(Venda venda)
        {
            Banco banco;
            int qtde;

            try
            {
                banco = new Banco();
                banco.comando.CommandText = "INSERT INTO item(total, datav, codcli) VALUES(@t, @d, @cc)";
                banco.comando.Parameters.Add("@t", NpgsqlDbType.Double).Value = venda.total;
                banco.comando.Parameters.Add("@d", NpgsqlDbType.Date).Value = venda.datav;
                banco.comando.Parameters.Add("@cc", NpgsqlDbType.Integer).Value = venda.codcli;
                banco.comando.Prepare();
                qtde = banco.comando.ExecuteNonQuery();
                Banco.conexao.Close();
                return (qtde);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gravar a venda: " + ex.Message);
            }
        }

        public int alterar(Venda venda)
        {
            Banco banco;
            int qtde;

            try
            {
                banco = new Banco();
                banco.comando.CommandText = "UPDATE venda SET total = @t, datav = @d, codcli = @cc WHERE codigo = @c";
                banco.comando.Parameters.Add("@t", NpgsqlDbType.Double).Value = venda.total;
                banco.comando.Parameters.Add("@d", NpgsqlDbType.Date).Value = venda.datav;
                banco.comando.Parameters.Add("@cc", NpgsqlDbType.Integer).Value = venda.codcli;
                banco.comando.Parameters.Add("@c", NpgsqlDbType.Integer).Value = venda.codigo;
                banco.comando.Prepare();
                qtde = banco.comando.ExecuteNonQuery();
                Banco.conexao.Close();
                return (qtde);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar a venda: " + ex.Message);
            }
        }

        public int remover(Venda venda)
        {
            Banco banco;
            int qtde;

            try
            {
                banco = new Banco();
                banco.comando.CommandText = "DELETE FROM venda WHERE codigo = @c";
                banco.comando.Parameters.Add("@c", NpgsqlDbType.Integer).Value = venda.codigo;
                banco.comando.Prepare();
                qtde = banco.comando.ExecuteNonQuery();
                Banco.conexao.Close();
                return (qtde);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover a venda: " + ex.Message);
            }
        }
        public DataTable listar()
        {
            Banco banco;

            try
            {
                banco = new Banco();
                banco.comando.CommandText = "SELECT * FROM venda ORDER BY 1";
                banco.dreader = banco.comando.ExecuteReader();
                banco.tabela = new DataTable();
                banco.tabela.Load(banco.dreader);
                Banco.conexao.Close();
                return (banco.tabela);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar as vendas: " + ex.Message);
            }
        }
    }
}
