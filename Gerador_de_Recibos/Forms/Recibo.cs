using Gerador_de_Recibos.Classes;
using Microsoft.Reporting.WinForms;
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
    public partial class Recibo : Form
    {
        public string listaClientes;
        public string comando;
        public Recibo(string teste)
        {
            InitializeComponent();
            
  
            Cliente cliente = new Cliente();
            using (var connection = new SQLiteConnection("Data Source=recibo"))
            {

                try
                {
                    Comandos comandos = new Comandos();

                    connection.Open();
                    SQLiteCommand  cmd;
                    SQLiteDataAdapter da;
                    string inserir = "SELECT * FROM cliente where ";

                    cmd = new SQLiteCommand(inserir + teste, connection);
                    da = new SQLiteDataAdapter(cmd);
                    da.Fill(cliente, cliente.Tables[0].TableName);


                    DataTable dt = new DataTable();

                    ReportDataSource rds = new ReportDataSource("Clientes", cliente.Tables[0]);

                    this.reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.LocalReport.DataSources.Add(rds);
                    this.reportViewer1.LocalReport.Refresh();
                    this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                    var setup = reportViewer1.GetPageSettings();
                    setup.Margins = new System.Drawing.Printing.Margins(2, 2, 2, 2);
                    reportViewer1.SetPageSettings(setup);


                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
                finally
                {
                    connection.Close();
                }
                this.reportViewer1.RefreshReport();
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}