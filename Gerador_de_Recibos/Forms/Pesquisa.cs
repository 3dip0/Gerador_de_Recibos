using Gerador_de_Recibos.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;
using System.Globalization;
using System.Threading;
using Gerador_de_Recibos.Forms;
using System.Timers;
using System.Diagnostics;
using System.Data.SQLite;

namespace Gerador_de_Recibos.Forms
{
    public partial class Pesquisa : Form
    {
        public Pesquisa(Principal principal)
        {
            InitializeComponent();
           }

    

        public class UpdateEventsArgs : EventArgs
        {
            public string Data { get; set; }
        }



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
                    cmd.CommandText = "SELECT * FROM cliente";
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
            }
            return dt;
        }

        private void F2_UpdateEventHandler1(object sender, Novo.UpdateEventsArgs args)
        {
            lista.DataSource = Source();
        }
        private void F3_UpdateEventHandler1(object sender, Alterar.UpdateEventsArgs args)
        {
            lista.DataSource = Source();
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
                    lista.DataSource = dt;
                    lista.Columns["valor_atual"].DefaultCellStyle.Format = "c2";
                    lista.Columns["Mes_referencia"].DefaultCellStyle.Format = "00/0000";
                    lista.Columns["Data_Vencimento"].DefaultCellStyle.Format = "00/0000";

                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public void update()

        {
                int ano = DateTime.Now.Year; // Ano
                int mes = DateTime.Now.Month; // Mês
            string a = ano.ToString();
            string m = mes.ToString();
            
            int mesAnt = mes - 1;
            if (mesAnt == 0)
            {
                mesAnt = 12;
            }
            string ma = mesAnt.ToString();
            string data = m +"/"+ a;
            string dataAnt = mesAnt + "/" + a;
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
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter($"UPDATE cliente SET Mes_referencia = '{dataAnt}', Data_Vencimento = '{data}'", connection);
                    dt = new System.Data.DataTable("recibo");
                    //Preenche a DataTable com os dados do adaptar     
                    adapter.Fill(dt);
                    adapter.Fill(dt);
                    lista.DataSource = dt;

                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }


        public void selectCod(string sql) 
        {
            using (var connection = new SQLiteConnection("Data Source=recibo"))
            {

                try
                {
                    connection.Open();

                    SQLiteCommand cmd = new SQLiteCommand(sql, connection);
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    lista.DataSource = dt;

                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (pesquisaCliente.Text == "Codigo")
            {
                (lista.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT("+ "codigo" +", System.String) LIKE '{0}%'", textCod.Text);
            }
            if (pesquisaCliente.Text == "Dia do Pagamento")
            {
                (lista.DataSource as DataTable).DefaultView.RowFilter = string.Format("dia_pagamento" + " LIKE '{0}%'", textCod.Text);
            }
            if (pesquisaCliente.Text == "Nome")
            {
                (lista.DataSource as DataTable).DefaultView.RowFilter = string.Format("cliente" + " LIKE '{0}%'", textCod.Text);
            }
            if (pesquisaCliente.Text == "Endereco")
            {
                (lista.DataSource as DataTable).DefaultView.RowFilter = string.Format("endereco" + " LIKE '{0}%'", textCod.Text);
            }
            if (pesquisaCliente.Text == "Bairro")
            {
                (lista.DataSource as DataTable).DefaultView.RowFilter = string.Format("bairro" + " LIKE '{0}%'", textCod.Text);
            }
            if (pesquisaCliente.Text == "Valor Atual")
            {
                if (!string.IsNullOrEmpty(textCod.Text))
                {
                    (lista.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(" + "valor_atual" + ", System.String) LIKE '{0}%'", textCod.Text);
                }
            }
           
            if (pesquisaCliente.Text == "Valor Maior que")
            {
                if (!string.IsNullOrEmpty(textCod.Text))
                {

                    (lista.DataSource as DataTable).DefaultView.RowFilter = string.Format("valor_atual >= {0}", textCod.Text);
                    lista.Sort(lista.Columns["valor_atual"], ListSortDirection.Ascending);

                }
                else
                {
                    selectCod("select * from cliente");
                }
            }
            if (pesquisaCliente.Text == "Valor Maior que")
            {
                if (!string.IsNullOrEmpty(textCod.Text))
                {

                    (lista.DataSource as DataTable).DefaultView.RowFilter = string.Format("valor_atual >= {0}", textCod.Text);
                    lista.Sort(lista.Columns["valor_atual"], ListSortDirection.Ascending);

                }
                else
                {
                    selectCod("select * from cliente");
                }
            }
            if (pesquisaCliente.Text == "Valor Menor que")
            {
                if (!string.IsNullOrEmpty(textCod.Text))
                {

                    (lista.DataSource as DataTable).DefaultView.RowFilter = string.Format("valor_atual <= {0}", textCod.Text);
                    lista.Sort(lista.Columns["valor_atual"], ListSortDirection.Descending);

                }
                else
                {
                    selectCod("select * from cliente");
                }
            }
            if (pesquisaCliente.Text == "Tipo de pagamento")
            {
                (lista.DataSource as DataTable).DefaultView.RowFilter = string.Format("tipo_pgto" + " LIKE '{0}%'", textCod.Text);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string pesquisaCod = "SELECT codigo FROM cliente where codigo = " + textCod.Text;
            MessageBox.Show(pesquisaCod);
    }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pesquisaCliente.Text == "Valores entre")
            {
                entre.Visible = true;

              
            }
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ReciboPersonalizado reciboPersonalizado = new ReciboPersonalizado();
            reciboPersonalizado.Show();
        }
       
       
        public string comando = "";
        public string comando2 = "";
        public List<client> listaClientes = new List<client>();
        public List<client> listaClientes2 = new List<client>();
        private void Button2_Click(object sender, EventArgs e)
        {

           
            dados();
            
            Recibo novo = new Recibo(comando);

            novo.Show();
        }

        public void dados()
        {

            string cod;
            string cod2;
            bool atv = true;
            
            foreach (DataGridViewRow row in lista.Rows)
            {

                if (row.IsNewRow) continue;
                if (Convert.ToBoolean(row.Cells["Coluna"].FormattedValue))
                {
                    cod = Convert.ToString(row.Cells[1].Value);
                    cod2 = Convert.ToString(row.Cells[11].Value);
                    client client = new client(cod2);
                    listaClientes.Add(client);
    
                    if (atv == true)
                    {
                        comando = $" codigo = '{cod}'";
                       


                        atv = false;
                    }
                    else
                    {
                        comando += $" || codigo = '{cod}'";
                        
                    }
                }
            }
           
        }
        public void contar()
        {
            foreach (DataGridViewRow row in lista.Rows)
            {

                if (row.IsNewRow) continue;
                if (Convert.ToBoolean(row.Cells["Coluna"].FormattedValue))

                {
                    UsuarioLogado.contar++;
                }
            }
        }


        public int qtd=0;
        public void dados2()
        {
            UsuarioLogado.controle = true;

            string cod;
            decimal cod2;
            using (var connection = new SQLiteConnection("Data Source=recibo"))
            {
                try
                {
                    connection.Open();
                    foreach (DataGridViewRow row in lista.Rows)
                    {

                        if (row.IsNewRow) continue;
                        if (Convert.ToBoolean(row.Cells["Coluna"].FormattedValue))

                        {
                            DataTable dt = new DataTable();
                            cod = Convert.ToString(row.Cells[1].Value);
                            cod2 = Convert.ToDecimal(row.Cells[11].Value);
                            Debug.WriteLine(cod);
                            SQLiteDataAdapter adapter;
                            string update = "";
                            string select;
                            decimal valor = Convert.ToDecimal(valorReaj);

                            if (item == "%")
                            {
                                cod2 = cod2 + (cod2 * (valor / 100));
                                update = $"UPDATE cliente SET valor_atual = valor_atual+(valor_atual*({valorReaj}/100)), valor_extenso = '{EscreverExtenso(cod2)}'";

                                select = $"select * from cliente";
                            }
                            if (item == "+")
                            {

                                cod2 = cod2 + valor;
                                update = $"UPDATE cliente SET valor_atual = valor_atual+{valorReaj}, valor_extenso = '{EscreverExtenso(cod2)}'";

                                select = $"select * from cliente";
                            }


                            try
                            {
                                adapter = new SQLiteDataAdapter($"{update} where codigo = {cod}", connection);
                                dt = new System.Data.DataTable("recibo");
                                adapter.Fill(dt);

                            }
                            catch (Exception erro)
                            {
                                MessageBox.Show(erro.Message);
                            }

                        }

                    }

                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                    UsuarioLogado.controle = false;
                }
            }

        }

        string item;
        string valorReaj;
        public void textos()
        {
         item = itens.Text;
            valorReaj = valorReajuste.Text;

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


        public static string EscreverExtenso(decimal valor)
        {
            if (valor <= 0 | valor >= 1000000000000000)
                return "Valor não suportado pelo sistema.";
            else
            {
                string strValor = valor.ToString("000000000000000.00");
                string valor_por_extenso = string.Empty;
                for (int i = 0; i <= 15; i += 3)
                {
                    valor_por_extenso += Escrever_Valor_Extenso(Convert.ToDecimal(strValor.Substring(i, 3)));
                    if (i == 0 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(0, 3)) == 1)
                            valor_por_extenso += " Trilhão" + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? " e " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(0, 3)) > 1)
                            valor_por_extenso += " Trilhões" + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? " e " : string.Empty);
                    }
                    else if (i == 3 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(3, 3)) == 1)
                            valor_por_extenso += " Bilhão" + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? " e " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(3, 3)) > 1)
                            valor_por_extenso += " Bilhões" + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? " e " : string.Empty);
                    }
                    else if (i == 6 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(6, 3)) == 1)
                            valor_por_extenso += " Milhão" + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? " e " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(6, 3)) > 1)
                            valor_por_extenso += " Milhões" + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? " e " : string.Empty);
                    }
                    else if (i == 9 & valor_por_extenso != string.Empty)
                        if (Convert.ToInt32(strValor.Substring(9, 3)) > 0)
                            valor_por_extenso += " Mil" + ((Convert.ToDecimal(strValor.Substring(12, 3)) > 0) ? " e " : string.Empty);
                    if (i == 12)
                    {
                        if (valor_por_extenso.Length > 8)
                            if (valor_por_extenso.Substring(valor_por_extenso.Length - 6, 6) == "Bilhão" | valor_por_extenso.Substring(valor_por_extenso.Length - 6, 6) == "MILHÃO")
                                valor_por_extenso += " de";
                            else
                                if (valor_por_extenso.Substring(valor_por_extenso.Length - 7, 7) == "Bilhões" | valor_por_extenso.Substring(valor_por_extenso.Length - 7, 7) == "MILHÕES"
| valor_por_extenso.Substring(valor_por_extenso.Length - 8, 7) == "Trihlões")
                                valor_por_extenso += " de";
                            else
                                    if (valor_por_extenso.Substring(valor_por_extenso.Length - 8, 8) == "Trilhões")
                                valor_por_extenso += "de";
                        if (Convert.ToInt64(strValor.Substring(0, 15)) == 1)
                            valor_por_extenso += " Real";
                        else if (Convert.ToInt64(strValor.Substring(0, 15)) > 1)
                            valor_por_extenso += " Reais";
                        if (Convert.ToInt32(strValor.Substring(16, 2)) > 0 && valor_por_extenso != string.Empty)
                            valor_por_extenso += " e ";
                    }
                    if (i == 15)
                        if (Convert.ToInt32(strValor.Substring(16, 2)) == 1)
                            valor_por_extenso += " Centavo";
                        else if (Convert.ToInt32(strValor.Substring(16, 2)) > 1)
                            valor_por_extenso += " Centavo";
                }
                return valor_por_extenso;
            }
        }
        static string Escrever_Valor_Extenso(decimal valor)
        {
            if (valor <= 0)
                return string.Empty;
            else
            {
                string montagem = string.Empty;
                if (valor > 0 & valor < 1)
                {
                    valor *= 100;
                }
                string strValor = valor.ToString("000");
                int a = Convert.ToInt32(strValor.Substring(0, 1));
                int b = Convert.ToInt32(strValor.Substring(1, 1));
                int c = Convert.ToInt32(strValor.Substring(2, 1));
                if (a == 1) montagem += (b + c == 0) ? "Cem" : "Cento";
                else if (a == 2) montagem += "Duzentos";
                else if (a == 3) montagem += "Trezentos";
                else if (a == 4) montagem += "Quatrocentos";
                else if (a == 5) montagem += "Quinhentos";
                else if (a == 6) montagem += "Seiscentos";
                else if (a == 7) montagem += "Setecentos";
                else if (a == 8) montagem += "Oitocentos";
                else if (a == 9) montagem += "Novecentos";
                if (b == 1)
                {
                    if (c == 0) montagem += ((a > 0) ? " E " : string.Empty) + "Dez";
                    else if (c == 1) montagem += ((a > 0) ? " E " : string.Empty) + "Onze";
                    else if (c == 2) montagem += ((a > 0) ? " E " : string.Empty) + "Doze";
                    else if (c == 3) montagem += ((a > 0) ? " E " : string.Empty) + "Treze";
                    else if (c == 4) montagem += ((a > 0) ? " E " : string.Empty) + "Quatorze";
                    else if (c == 5) montagem += ((a > 0) ? " E " : string.Empty) + "Quinze";
                    else if (c == 6) montagem += ((a > 0) ? " E " : string.Empty) + "Dezesseis";
                    else if (c == 7) montagem += ((a > 0) ? " E " : string.Empty) + "Dezessete";
                    else if (c == 8) montagem += ((a > 0) ? " E " : string.Empty) + "Dezoito";
                    else if (c == 9) montagem += ((a > 0) ? " E " : string.Empty) + "Dezenove";
                }
                else if (b == 2) montagem += ((a > 0) ? " E " : string.Empty) + "Vinte";
                else if (b == 3) montagem += ((a > 0) ? " E " : string.Empty) + "Trinta";
                else if (b == 4) montagem += ((a > 0) ? " E " : string.Empty) + "Quarenta";
                else if (b == 5) montagem += ((a > 0) ? " E " : string.Empty) + "Cinquenta";
                else if (b == 6) montagem += ((a > 0) ? " E " : string.Empty) + "Sessenta";
                else if (b == 7) montagem += ((a > 0) ? " E " : string.Empty) + "Setenta";
                else if (b == 8) montagem += ((a > 0) ? " E " : string.Empty) + "Oitenta";
                else if (b == 9) montagem += ((a > 0) ? " E " : string.Empty) + "Noventa";
                if (strValor.Substring(1, 1) != "1" & c != 0 & montagem != string.Empty) montagem += " e ";
                if (strValor.Substring(1, 1) != "1")
                    if (c == 1) montagem += "Um";
                    else if (c == 2) montagem += "Dois";
                    else if (c == 3) montagem += "Três";
                    else if (c == 4) montagem += "Quatro";
                    else if (c == 5) montagem += "Cinco";
                    else if (c == 6) montagem += "Seis";
                    else if (c == 7) montagem += "Sete";
                    else if (c == 8) montagem += "Oito";
                    else if (c == 9) montagem += "Nove";
                return montagem;
            }
        }

        private void Pesquisa_Load(object sender, EventArgs e)
        {
            lista.DataSource = Source();
            var col = new DataGridViewCheckBoxColumn();
            col.Name = "Coluna";
            col.HeaderText = "";
            col.FalseValue = false;
            col.TrueValue = true;

            //Make the default checked
            lista.Columns.Insert(0, col);


            }

        private void chkItems_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in lista.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[1];
                if (chk.Value == chk.TrueValue)
                {
                    chk.Value = chk.FalseValue;
                }
                else
                {
                    chk.Value = chk.TrueValue;
                }
            }
        }
        string nome;
        string codigo;
        string cep;
        string uf;
        string cidade;
        string endereco;
        string numero;
        string bairro;
        string servico;
        string tipo;
        string valor;
        string valorExt;
        string dia;

        public void setItens(string cod, string nomeCliente, string cepCiente, string ufCliente, string cidadeCliente, string enderecoCliente, string numeroCliente, string bairroCliente, string servicoCliente, string tipo_pgto, string valorCliente, string valorExtCliente, string diaCliente, int Controle)
        {
            nome = nomeCliente;
            codigo = cod;
            cep = cepCiente;
            uf = ufCliente;
            cidade = cidadeCliente;
            endereco = enderecoCliente;
            numero = numeroCliente;
            bairro = bairroCliente;
            servico = servicoCliente;
            tipo = tipo_pgto;
            valor = valorCliente;
            valorExt = valorExtCliente;
            dia = diaCliente;
            control = Controle;
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            control = 1;
            Novo novo = new Novo(this);
            novo.UpdateEvetsHandler += F2_UpdateEventHandler1;
            novo.ShowDialog();
         


        }

       
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void CheckBox1_MouseClick(object sender, MouseEventArgs e)
        {
          
           
            if (checkBox1.Checked)
            {
               
                reajustar.Enabled = true;
                valorReajuste.Enabled = true;
                itens.Enabled = true;
            }
            else
            {
             
                reajustar.Enabled = false;
                valorReajuste.Enabled = false;
                itens.Enabled = false;
            }
           
        }
        public void atualizar()
        {

            using (var connection = new SQLiteConnection("Data Source=recibo"))
            {
                var command = connection.CreateCommand();

                try
                {
                    connection.Open();
                    Comandos comando2 = new Comandos();

                    command.CommandText = comando2.selectSimples;
                    command.ExecuteNonQuery();
                    System.Data.DataTable dt = new System.Data.DataTable();
                    string selectCommand = string.Format(comando2.selectSimples);

                    SQLiteDataAdapter adapter2 = new SQLiteDataAdapter($"select * from cliente", connection);
                    dt = new System.Data.DataTable("recibo");
                    //Preenche a DataTable com os dados do adaptar     
                    try
                    {

                        adapter2.Fill(dt);
                        lista.DataSource = dt;
                        comando = "";
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message);
                    }
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }
        
        public void atualizarPesq()
        {
            if (pesquisaCliente.Text == "Codigo")
            {
                (lista.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(" + "codigo" + ", System.String) LIKE '{0}%'", textCod.Text);
            }
            if (pesquisaCliente.Text == "Nome")
            {
                (lista.DataSource as DataTable).DefaultView.RowFilter = string.Format("cliente" + " LIKE '{0}%'", textCod.Text);
            }
            if (pesquisaCliente.Text == "Endereco")
            {
                (lista.DataSource as DataTable).DefaultView.RowFilter = string.Format("endereco" + " LIKE '{0}%'", textCod.Text);
            }
            if (pesquisaCliente.Text == "Valor Atual")
            {
                if (!string.IsNullOrEmpty(textCod.Text))
                {
                    (lista.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(" + "valor_atual" + ", System.String) LIKE '{0}%'", textCod.Text);
                }
            }
            if (pesquisaCliente.Text == "Valor entre")
            {
                if (!string.IsNullOrEmpty(textCod.Text))
                {
                    (lista.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(" + "valor_atual" + ", System.String) LIKE '{0}%'", valorInicial.Text);
                }
            }
            if (pesquisaCliente.Text == "Valor Maior que")
            {
                if (!string.IsNullOrEmpty(textCod.Text))
                {

                    (lista.DataSource as DataTable).DefaultView.RowFilter = string.Format("valor_atual >= {0}", textCod.Text);
                    lista.Sort(lista.Columns["valor_atual"], ListSortDirection.Ascending);

                }
                else
                {
                    selectCod("select * from cliente");
                }
            }
            if (pesquisaCliente.Text == "Valor Maior que")
            {
                if (!string.IsNullOrEmpty(textCod.Text))
                {

                    (lista.DataSource as DataTable).DefaultView.RowFilter = string.Format("valor_atual >= {0}", textCod.Text);
                    lista.Sort(lista.Columns["valor_atual"], ListSortDirection.Ascending);

                }
                else
                {
                    selectCod("select * from cliente");
                }
            }
            if (pesquisaCliente.Text == "Valor Menor que")
            {
                if (!string.IsNullOrEmpty(textCod.Text))
                {

                    (lista.DataSource as DataTable).DefaultView.RowFilter = string.Format("valor_atual >= {0}", textCod.Text);
                    lista.Sort(lista.Columns["valor_atual"], ListSortDirection.Ascending);

                }
                else
                {
                    selectCod("select * from cliente");
                }
            }
            if (pesquisaCliente.Text == "Tipo de pagamento")
            {
                (lista.DataSource as DataTable).DefaultView.RowFilter = string.Format("tipo_pgto" + " LIKE '{0}%'", textCod.Text);
            }
        }


      
        private void Reajustar_Click(object sender, EventArgs e)
        {
            UsuarioLogado.controle = true;
            contar();
            textos();
            Thread nova = new Thread(dados2);
            
            nova.Start();
            backgroundWorker1.RunWorkerAsync();
            

            //  reajustar.Text = "Reajustar valor";
        }




        private void Lista_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridview;
            gridview = (DataGridView)sender;
            gridview.ClearSelection();
            
            
        }

        private void Lista_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView gridview;
            gridview = (DataGridView)sender;
            gridview.ClearSelection();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
           
        }
        int control;
       

        private void Timer1_Tick(object sender, EventArgs e)
        {
            
            if(control == 0)
            {
                atualizar();
                timer1.Stop();
            }
            
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dtr in lista.Rows)
            {

                if(todos.Checked)
                {
                    ((DataGridViewCheckBoxCell)dtr.Cells[0]).Value = true;
                }
                else
                {
                    ((DataGridViewCheckBoxCell)dtr.Cells[0]).Value = false;

                }
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            string cod;

            foreach (DataGridViewRow row in lista.Rows)
            {

                if (row.IsNewRow) continue;
                if (Convert.ToBoolean(row.Cells["Coluna"].FormattedValue))
                {
                    cod = Convert.ToString(row.Cells[1].Value);
                    nome = Convert.ToString(row.Cells[2].Value);
                    cep = Convert.ToString(row.Cells[3].Value);
                    uf = Convert.ToString(row.Cells[4].Value);
                    cidade = Convert.ToString(row.Cells[5].Value);
                    endereco = Convert.ToString(row.Cells[6].Value);
                    numero = Convert.ToString(row.Cells[7].Value);
                    bairro = Convert.ToString(row.Cells[8].Value);
                    tipo = Convert.ToString(row.Cells[9].Value);
                    servico = Convert.ToString(row.Cells[10].Value);
                    valor = Convert.ToString(row.Cells[11].Value);
                    valorExt = Convert.ToString(row.Cells[12].Value);
                    dia = Convert.ToString(row.Cells[13].Value);

                    Alterar alterar = new Alterar(this,nome,cod,cep,uf,cidade,endereco, numero, bairro, tipo,servico, valor, valorExt,dia);
                    alterar.UpdateEvetsHandler += F3_UpdateEventHandler1;
                    alterar.ShowDialog();
                   

                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja apagar este registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string cod;
                using (var connection = new SQLiteConnection("Data Source=recibo"))
                {
                    foreach (DataGridViewRow row in lista.Rows)
                    {


                        try
                        {

                            connection.Open();

                            if (row.IsNewRow) continue;
                            if (Convert.ToBoolean(row.Cells["Coluna"].FormattedValue))

                            {
                                DataTable dt = new DataTable();
                                cod = Convert.ToString(row.Cells[1].Value);


                                SQLiteDataAdapter adapter;
                                SQLiteDataAdapter adapter2;

                                string delete = "";
                                string select;


                                delete = $"DELETE FROM cliente ";

                                select = $"select * from cliente";


                                try
                                {
                                    adapter = new SQLiteDataAdapter($"{delete} where codigo = {cod}", connection);
                                    adapter2 = new SQLiteDataAdapter(select, connection);

                                    dt = new System.Data.DataTable("recibo");

                                    adapter.Fill(dt);
                                    adapter2.Fill(dt);
                                    lista.DataSource = dt;

                                }
                                catch
                                {

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


        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < UsuarioLogado.contar; i++)
            {
                Thread.Sleep(70);
                backgroundWorker1.ReportProgress(i);
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            reajustar.Text = "Aguarde...";
                reajustar.Enabled = false;
                carregando.Visible = true;
      
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            atualizar();
            atualizarPesq();
            reajustar.Text = "Reajustar valor";
            reajustar.Enabled = true;
            carregando.Visible = false;
            
        }

        private void ValorInicial_TextChanged(object sender, EventArgs e)
        {
            if (pesquisaCliente.Text == "Valores entre")
            {
                if (!string.IsNullOrEmpty(valorInicial.Text))
                {

                    (lista.DataSource as DataTable).DefaultView.RowFilter = string.Format("valor_atual >= {0}", valorInicial.Text);
                    lista.Sort(lista.Columns["valor_atual"], ListSortDirection.Ascending);

                }
                else
                {
                    selectCod("select * from cliente");
                }
            }
        }

        private void ValorFinal_TextChanged(object sender, EventArgs e)
        {
            if (pesquisaCliente.Text == "Valores entre")
            {
                if (!string.IsNullOrEmpty(valorFinal.Text))
                {

                    (lista.DataSource as DataTable).DefaultView.RowFilter = string.Format("valor_atual <= {0} and valor_atual >= {1}", valorFinal.Text, valorInicial.Text);
                    lista.Sort(lista.Columns["valor_atual"], ListSortDirection.Ascending);

                }
                else
                {
                    selectCod("select * from cliente");
                }
            }
        }

        private void PainelReajuste_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Lista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button7_Click_1(object sender, EventArgs e)
        {
            atualizar();
        }
    }
}
