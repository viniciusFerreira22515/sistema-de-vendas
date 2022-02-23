using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_de_vendas
{
    public class Venda
    {
        public int codigo { get; private set; }
        public double total { get; private set; }
        public DateTime datav { get; private set; }
        public int codcli { get; private set; }

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
                throw new Exception("Erro no setCodigo de Venda: " + ex.Message);
            }
        }

        public void setTotal(double t)
        {
            this.total = t;
        }

        public void setTotal(string t)
        {
            try
            {
                this.total = Convert.ToDouble(t);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no setTotal de Venda: " + ex.Message);
            }
        }

        public void setDatav(DateTime d)
        {
            this.datav = d;
        }

        public void setDatav(string d)
        {
            try
            {
                this.datav = Convert.ToDateTime(d);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no setDatav de Venda: " + ex.Message);
            }
        }
        public void setCodcli(int c)
        {
            this.codcli = c;
        }

        public void setCodcli(string c)
        {
            try
            {
                this.codcli = Convert.ToInt32(c);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no setCodcli de Venda: " + ex.Message);
            }
        }
    }
}
