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
    public partial class NovoUsuario : Form
    {
        public NovoUsuario()
        {
            InitializeComponent();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (var connection = new SQLiteConnection("Data Source=recibo"))
            {
                var command = connection.CreateCommand();

                try
                {
                    connection.Open();
                    string nivel = "1";
                    if (tipo.Text == "Administrador")
                    {
                        nivel = "0";
                    }
                    if (tipo.Text == "Operador")
                    {
                        nivel = "1";
                    }
                    if (usuario.Text != UsuarioLogado.NomeUsuario)
                    {
                        System.Data.DataTable dt = new System.Data.DataTable();
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter($"INSERT INTO usuario values ('{usuario.Text}', '{senha.Text}', {nivel})", connection);
                        dt = new System.Data.DataTable("recibo");
                        //Preenche a DataTable com os dados do adaptar     
                        try
                        {
                            adapter.Fill(dt);
                            MessageBox.Show("Usuário criado com sucesso!");
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Falha ao criar o usuário!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Este usuário já existe!");
                    }
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        private void NovoUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
