using Gerador_de_Recibos.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerador_de_Recibos.Classes
{
    class Comandos
    {
       
        
        public string selectSimples = "SELECT *FROM cliente";
        public string selectPesquisa = "SELECT codigo, cliente, cep, endereco, tipo_pgto, valor_atual, porce_reajuste, vlr_reajuste, vlr_com_reajuste, vencimento, mes FROM cliente";
        public void usuario(string usuario)
        {
         
        }

    }
}
