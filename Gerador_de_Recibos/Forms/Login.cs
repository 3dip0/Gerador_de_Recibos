using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using Gerador_de_Recibos.Classes;
using System.Data.SQLite;

namespace Gerador_de_Recibos.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            senha.PasswordChar = '*';
        }
     
        public static string usuarioTxt;
        public bool atv = false;
        public string nivel;
        private void Button1_Click(object sender, EventArgs e)
        {
            logar();
   
        }

        public void logar()
        {

            using (var connection = new SQLiteConnection("Data Source=recibo"))
            {
                


                var command = connection.CreateCommand();
                Comandos comandos = new Comandos();

                SQLiteCommand query = new SQLiteCommand("select count(*)" + $"from usuario where usuario = '{usuario.Text}' and senha = '{senha.Text}' and nivel >=0", connection);

                SQLiteCommand query2 = new SQLiteCommand("select *" + $"from usuario where usuario = '{usuario.Text}' and senha = '{senha.Text}' and nivel >=0", connection);
                UsuarioLogado.NomeUsuario = usuario.Text;
                connection.Open();
                DataTable dataTable = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(query);
                DataTable dataTable2 = new DataTable();
                SQLiteDataAdapter da2 = new SQLiteDataAdapter(query2);
                da.Fill(dataTable);
                da2.Fill(dataTable2);
                Principal principal = new Principal();

                foreach (DataRow list in dataTable.Rows)
                {
                    if (Convert.ToInt64(list.ItemArray[0]) > 0)
                    {
                        UsuarioLogado.nivel = dataTable2.Rows[0]["nivel"].ToString();
                        if (UsuarioLogado.nivel == "0")
                        {


                            principal.nivel = dataTable2.Rows[0]["nivel"].ToString();
                            atv = true;
                            connection.Close();
                            this.Close();


                        }
                        else
                        {
                            principal.novoToolStripMenuItem.Visible = false;
                            principal.nivel = dataTable2.Rows[0]["nivel"].ToString();
                            atv = true;
                            connection.Close();
                            this.Close();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Usuário Inválido", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        atv = false;
                    }
                }
            }
        }
        private void Senha_Enter(object sender, EventArgs e)
        {
           
        }

        private void Senha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar ==13)
            {
                logar();   
            }
        }
    }
}