using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_de_vendas
{
    public class Cliente
    {
        public int codigo { get; private set; }
        public string nome { get; private set; }

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
                throw new Exception("Erro no setCodigo do Cliente: " + ex.Message);
            }
        }

        public void setNome(string n)
        {
            this.nome = n;
        }
    }
}
