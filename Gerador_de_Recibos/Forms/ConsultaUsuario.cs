using Gerador_de_Recibos.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerador_de_Recibos.Forms
{
    public partial class ConsultaUsuario : Form
    {
        public ConsultaUsuario()
        {
            InitializeComponent();
        }

        public void select()


        {
            using (var connection = new SQLiteConnection("Data Source=recibo"))
            {
                var command = connection.CreateCommand();

                try
                {
                    connection.Open();


                    System.Data.DataTable dt = new System.Data.DataTable();

                    SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT usuario FROM usuario", connection);
                    dt = new System.Data.DataTable("recibo");
                    //Preenche a DataTable com os dados do adaptar     
                    adapter.Fill(dt);
                    usuarios.DataSource = dt;


                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }
        string connect = "Server=localhost;Database=recibo;Uid=root;Pwd=";
        private DataTable dt = new DataTable();
        private DataSet ds = new DataSet();

        public DataTable Source()
        {
            using (var connection = new SQLiteConnection("Data Source=recibo"))
            {
                connection.Open();
                try
                {
                    SQLiteCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT usuario FROM usuario";
                    SQLiteDataAdapter adap = new SQLiteDataAdapter(cmd);
                    ds.Clear();
                    adap.Fill(ds);
                    dt = ds.Tables[0];
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

                return dt;
            }
        }
        private void ConsultaUsuario_Load(object sender, EventArgs e)
        {
            usuarios.DataSource = Source();
            var col = new DataGridViewCheckBoxColumn();
            col.Name = "Coluna";
            col.HeaderText = "Titulo";
            col.FalseValue = false;
            col.TrueValue = true;

            //Make the default checked
            usuarios.Columns.Insert(0, col);
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja apagar este usuário?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string nomeUsuario;
                using (var connection = new SQLiteConnection("Data Source=recibo"))
                {

                    foreach (DataGridViewRow row in usuarios.Rows)
                    {


                        try
                        {

                            connection.Open();

                            if (row.IsNewRow) continue;
                            if (Convert.ToBoolean(row.Cells["Coluna"].FormattedValue))

                            {
                                DataTable dt = new DataTable();
                                nomeUsuario = Convert.ToString(row.Cells[1].Value);


                                SQLiteDataAdapter adapter;
                                SQLiteDataAdapter adapter2;

                                string delete = "";
                                string select;


                                delete = $"DELETE FROM usuario ";

                                select = $"select usuario from usuario";


                                try
                                {


                                    if (nomeUsuario != UsuarioLogado.NomeUsuario)
                                    {
                                        adapter = new SQLiteDataAdapter($"{delete} where usuario = '{nomeUsuario}'", connection);
                                        adapter2 = new SQLiteDataAdapter(select, connection);

                                        dt = new System.Data.DataTable("recibo");

                                        adapter.Fill(dt);
                                        adapter2.Fill(dt);
                                        usuarios.DataSource = dt;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Não é possivel excluir o usuário que está logado atualmente!");
                                    }
                                }
                                catch (Exception erro)
                                {
                                    MessageBox.Show(erro.Message);
                                }

                            }
                        }
                        finally
                        {
                            if (connection.State == ConnectionState.Open)
                                connection.Close();
                        }
                    }

                }
            }
        }
    }
}
