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
using static Gerador_de_Recibos.Forms.Pesquisa;

namespace Gerador_de_Recibos.Forms
{
    public partial class Alterar : Form
    {

        public Alterar(Pesquisa pesquisa, string nomeCliente, string codCliente, string cepCliente, string ufcliente, string cidadeCliente, string enderecoCliente, string numeroCliente,
            string bairroCliente, string tipoCliente, string servicoCliente, string valorCliente, string valorExtCliente, string diaCliente)
        {
            InitializeComponent();
            nome.Text = nomeCliente;
            cod.Text = codCliente;
            cep.Text = cepCliente;
            uf.Text = ufcliente;
            cidade.Text = cidadeCliente;
            endereco.Text = enderecoCliente;
            numero.Text = numeroCliente;
            bairro.Text = bairroCliente;
            tipo.Text = tipoCliente;
            servico.Text = tipoCliente;
            servico.Text = servicoCliente;
            valor.Text = valorCliente;
            valorExt.Text = valorExtCliente;
            dia.Text = diaCliente;
                }

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
  
        string cn = "Server=localhost;Database=recibo;Uid=root;Pwd=";
        public delegate void UpdateDelegate(object sender, UpdateEventsArgs args);
        public event UpdateDelegate UpdateEvetsHandler;

        public class UpdateEventsArgs : EventArgs
        {
            public string Data { get; set; }
        }

        protected void update()
        {
            UpdateEventsArgs args = new UpdateEventsArgs();
            UpdateEvetsHandler.Invoke(this, args);
        }


        private void Salvar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja alterar este registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                            cmd.CommandText = $"update cliente set " +
                 $"cliente = '{Nome}'," +
                $"cep = '{Cep}'," +
                $"uf = '{Estado}'," +
                $"cidade = '{Cidade}'," +
                $"endereco = '{Endereco}'," +
                $"numero = {Numero}," +
                $"bairro = '{Bairro}'," +
                $"tipo_pgto = '{Tipo}'," +
                $"servico = '{Servico}'," +
                $"valor_atual = {Valor.Replace(',', '.')}," +
                $"valor_extenso = '{ValorExt}'," +
                $"dia_pagamento = '{Dia}' where codigo = {Codigo}";
                            cmd.ExecuteNonQuery();
                            this.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Preencha todos os campos");
                    }
                    update();

                }
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
