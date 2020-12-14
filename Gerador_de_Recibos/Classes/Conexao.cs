using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerador_de_Recibos.Classes
{



    class Conexao
    {
        
        public void conectar()
        {
            var connString = "Server=localhost;Database=recibo;Uid=root;Pwd=";
            var connection = new MySqlConnection(connString);
            var command = connection.CreateCommand();

            connection.Open();

        }

    }
}
