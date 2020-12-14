using Gerador_de_Recibos.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerador_de_Recibos.Classes
{
    class Chamadas
    {
        //Pesquisa pesquisa = new Pesquisa();
        public List<client> listaClientes = new List<client>();
        public string comando = "";
        public void chamar()
        {
            //Pesquisa pesquisa = new Pesquisa();
            //pesquisa.Show();
        }

        public class client
        {
            public string clientId { get; set; }

            public client()
            { }

            public client(string id)
            {
                clientId = id;

            }
        }

        public void select()
        {
            using (var connection = new SQLiteConnection("Data Source=recibo"))
            {
                var command = connection.CreateCommand();

                try
                {
                    connection.Open();
                    Comandos comando = new Comandos();

                    command.CommandText = comando.selectSimples;
                    command.ExecuteNonQuery();
                    System.Data.DataTable dt = new System.Data.DataTable();
                    string selectCommand = string.Format(comando.selectSimples);
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command.CommandText, connection);
                    dt = new System.Data.DataTable("recibo");
                    //Preenche a DataTable com os dados do adaptar     
                    adapter.Fill(dt);
                    //pesquisa.lista.DataSource = dt;
                    //pesquisa.lista.Columns["valor_atual"].DefaultCellStyle.Format = "c2";
                    //pesquisa.lista.Columns["Mes_referencia"].DefaultCellStyle.Format = "00/0000";
                    //pesquisa.lista.Columns["Data_Vencimento"].DefaultCellStyle.Format = "00/0000";

                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }
        //public void dados()
        //{
            
        //    int i;
        //    string cod;
        //    ReciboTeste novo;
        //    bool atv = true;

        //    foreach (DataGridViewRow row in pesquisa.lista.Rows)
        //    {

        //        if (row.IsNewRow) continue;
        //        if (Convert.ToBoolean(row.Cells["Coluna"].FormattedValue))
        //        {
        //            cod = Convert.ToString(row.Cells[1].Value);
        //            var cliente = new client(cod);
        //            listaClientes.Add(cliente);


        //            if (atv == true)
        //            {
        //                comando = $" codigo = '{cod}'";



        //                atv = false;
        //            }
        //            else
        //            {
        //                comando += $" || codigo = '{cod}'";

        //            }
        //            Comandos comandos = new Comandos();
        //            comandos.codigo = comando;


        //        }
        //    }

        //}
    }
}
