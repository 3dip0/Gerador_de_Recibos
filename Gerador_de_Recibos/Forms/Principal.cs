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

namespace Gerador_de_Recibos.Forms
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            
        }

        public string nivel = "0";
        public void iniciarAdmin()
        {
            Pesquisa pesquisa = new Pesquisa(this);
            pesquisa.TopLevel = false;
            pesquisa.Visible = true;
            painelPrincipal.Controls.Add(pesquisa);
            pesquisa.painelReajuste.Visible = true;
            pesquisa.WindowState = FormWindowState.Maximized;
            pesquisa.Show();
            pesquisa.update();
            pesquisa.select();
        }
        public void iniciarOutros()
        {
            Pesquisa pesquisa = new Pesquisa(this);
            pesquisa.TopLevel = false;
            pesquisa.Visible = true;
            painelPrincipal.Controls.Add(pesquisa);
            pesquisa.painelReajuste.Visible = false;
            pesquisa.WindowState = FormWindowState.Maximized;
            pesquisa.Show();
            pesquisa.update();
            pesquisa.select();
        }
        
        private void Principal_Load(object sender, EventArgs e)
        {

            using (Login Form = new Login())
            {
                Form.ShowDialog();
                // Aqui considerei que se o login for efetuado com sucesso, o DialogResult será OK

                if (Form.atv==true)
                {
                    if (UsuarioLogado.nivel == "1")
                    {
                        novoToolStripMenuItem.Visible = false;
                        consultarToolStripMenuItem.Visible = false;

                    }
                    Comandos comandos = new Comandos();
                    
                    this.WindowState = FormWindowState.Maximized;
                    this.Text = "Controle de recibos - Usuário atual: " + UsuarioLogado.NomeUsuario;
                    this.Show();
                    return;
                }
                else
                {
                    Application.Exit();
                    return;
                }

            }

        }

        private void PesquisarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Login login = new Login();
            if (UsuarioLogado.nivel == "0")
            {
                iniciarAdmin();
            }
            else
            {
                iniciarOutros();
            }
        }

        private void SairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void NovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NovoUsuario novoUsuario = new NovoUsuario();
            novoUsuario.Show();
        }

        private void ConsultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaUsuario consultaUsuario = new ConsultaUsuario();
           // consultaUsuario.usuarios.Columns["CustomerID"].Visible = false;
            consultaUsuario.select();
            consultaUsuario.Show();
        }

        private void PainelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
