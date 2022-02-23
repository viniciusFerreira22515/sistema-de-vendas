using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_de_vendas
{
    public class Produto
    {
        public int codigo { get; private set; }
        public string descr { get; private set; }
        public double preco { get; private set; }
        public int qtde { get; private set; }

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
                throw new Exception("Erro no setCodigo de Produto: " + ex.Message);
            }
        }

        public void setDescr(string d)
        {
            this.descr = d;
        }

        public void setPreco(double p)
        {
            this.preco = p;
        }

        public void setPreco(string p)
        {
            try
            {
                this.preco = Convert.ToDouble(p);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no setPreco de Produto: " + ex.Message);
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
                throw new Exception("Erro no setQtde de Produto: " + ex.Message);
            }
        }
    }
}