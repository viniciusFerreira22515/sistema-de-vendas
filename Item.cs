using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_de_vendas
{
    public class Item
    {
        public int codigo { get; private set; }
        public int qtde { get; private set; }
        public double valor { get; private set; }
        public int codproduto { get; private set; }
        public int codvenda { get; private set; }

        public void setCodigo(int c)
        {
            this.codigo = c;
        }

        public void setCodigo(string c)
        {
            try
            {
                this.codigo = Convert.ToInt32(c);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no setCodigo de Item: " + ex.Message);
            }
        }
        public void setQtde(int q)
        {
            this.qtde = q;
        }

        public void setQtde(string q)
        {
            try
            {
                this.qtde = Convert.ToInt32(q);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no setQtde de Item: " + ex.Message);
            }
        }

        public void setValor(double v)
        {
            this.valor = v;
        }

        public void setValor(string v)
        {
            try
            {
                this.valor = Convert.ToDouble(v);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no setValor de Item: " + ex.Message);
            }
        }
        public void setCodproduto(int c)
        {
            this.codproduto = c;
        }

        public void setCodproduto(string c)
        {
            try
            {
                this.codproduto = Convert.ToInt32(c);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no setCodproduto de Item: " + ex.Message);
            }
        }

        public void setCodvenda(int c)
        {
            this.codvenda = c;
        }

        public void setCodvenda(string c)
        {
            try
            {
                this.codvenda = Convert.ToInt32(c);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no setCodvenda de Item: " + ex.Message);
            }
        }
    }
}
