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
    public partial class Novo : Form
    {
        public string Codigo
        {
            get { return cod.Text; }
        }
        public string Nome
        {
            get { return nome.Text; }
        }
        public string Cep
        {
            get { return cep.Text; }
        }
        public string Estado
        {
            get { return uf.Text; }
        }
        public string Cidade
        {
            get { return cidade.Text; }
        }
        public string Endereco
        {
            get { return endereco.Text; }
        }
        public string Numero
        {
            get { return numero.Text; }
        }
        public string Bairro
        {
            get { return bairro.Text; }
        }
        public string Tipo
        {
            get { return tipo.Text; }
        }
        public string Servico
        {
            get { return servico.Text; }
        }
        public string Valor
        {
            get { return valor.Text; }
        }
        public string ValorExt
        {
            get { return valorExt.Text; }
        }
        public string Dia
        {
            get { return dia.Text; }
        }
        public int Controle
        {
            get { return control; }
        }
        string cn = "Server=localhost;Database=recibo;Uid=root;Pwd=";
        public Novo(Pesquisa pesquisa)
        {
            InitializeComponent();

        }
        public delegate void UpdateDelegate(object sender, UpdateEventsArgs args);
        public event UpdateDelegate UpdateEvetsHandler;

        public class UpdateEventsArgs : EventArgs
        {
            public string Data { get; set; }
        }

        protected void insert()
        {
            UpdateEventsArgs args = new UpdateEventsArgs();
            UpdateEvetsHandler.Invoke(this, args);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        int control = 1;
        private void Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja ncluir este registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var connect = new SQLiteConnection("Data Source=recibo"))
                {
                    SQLiteCommand cmd;
                    connect.Open();
                    try
                    {
                        if (Convert.ToInt32(Dia) > 31)
                        {
                            MessageBox.Show("Dia de pagamento inválido");
                        }
                        else
                        {

                            cmd = connect.CreateCommand();
                            cmd.CommandText = $"insert into cliente values " +
                $"({Codigo}," +
                $"'{Nome}'," +
                $"'{Cep}'," +
                $"'{Estado}'," +
                $"'{Cidade}'," +
                $"'{Endereco}'," +
                $"{Numero}," +
                $"'{Bairro}'," +
                $"'{Tipo}'," +
                $"'{Servico}'," +
                $"{Valor}," +
                $"'{ValorExt}'," +
                $"'{Dia}'," +
                $"' '," +
                $"' ')";
                            cmd.ExecuteNonQuery();
                            this.Close();
                        }
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Preencha todos os campos!");
                    }

                    insert();

                }
            }
        }
        private void LocalizarCEP()
        {
            try
            {

                var valor = cep.Text;
                var ws = new WSCorreios.AtendeClienteClient();
                var resposta = ws.consultaCEP(valor);
                uf.Text = resposta.uf;
                cidade.Text = resposta.cidade;
                bairro.Text = resposta.bairro;
                endereco.Text = resposta.end;
            }
            catch
            {
                MessageBox.Show("Erro ao efetuar busca do CEP: " + cep.Text);
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
                            valor_por_extenso += " Trilhão" + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? " E " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(0, 3)) > 1)
                            valor_por_extenso += " Trilhões" + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? " E " : string.Empty);
                    }
                    else if (i == 3 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(3, 3)) == 1)
                            valor_por_extenso += " Bilhão" + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? " E " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(3, 3)) > 1)
                            valor_por_extenso += " Bilhões" + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? " E " : string.Empty);
                    }
                    else if (i == 6 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(6, 3)) == 1)
                            valor_por_extenso += " Milhão" + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? " E " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(6, 3)) > 1)
                            valor_por_extenso += " Milhões" + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? " E " : string.Empty);
                    }
                    else if (i == 9 & valor_por_extenso != string.Empty)
                        if (Convert.ToInt32(strValor.Substring(9, 3)) > 0)
                            valor_por_extenso += " Mil" + ((Convert.ToDecimal(strValor.Substring(12, 3)) > 0) ? " E " : string.Empty);
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
                            valor_por_extenso += " E ";
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
                if (strValor.Substring(1, 1) != "1" & c != 0 & montagem != string.Empty) montagem += " E ";
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

        private void Valor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal valorEscrever = Convert.ToDecimal(valor.Text);
                valorExt.Text = EscreverExtenso(valorEscrever);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Extenso_Click(object sender, EventArgs e)
        {
            try
            {
                decimal valorEscrever = Convert.ToDecimal(valor.Text);
                valorExt.Text = EscreverExtenso(valorEscrever);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BuscarCEP_Click(object sender, EventArgs e)
        {
            LocalizarCEP();
        }

        private void Cep_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Cep_Leave(object sender, EventArgs e)
        {
            LocalizarCEP();
        }

        private void Limpar_Click(object sender, EventArgs e)
        {
            cod.Clear();
            nome.Clear();
            cep.Clear();
            endereco.Clear();
            uf.Clear();
            bairro.Clear();
            cidade.Clear();
            numero.Clear();
            valor.Clear();
            valorExt.Clear();
            tipo.Clear();
            servico.Clear();
            dia.Clear();
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
