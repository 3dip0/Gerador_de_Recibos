using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace Gerador_de_Recibos.Forms
{
    public partial class ReciboPerso : Form
    {
        public ReciboPerso(string nomeCliente, string codCliente, string cepCliente, string ufcliente, string cidadeCliente, string enderecoCliente, string numeroCliente,
            string bairroCliente, string servicoCliente, string valorCliente, string valorExtCliente, string mes_referencia, string data_pgto)
        {
            InitializeComponent();
            reportViewer1.LocalReport.ReportEmbeddedResource = "Gerador_de_Recibos.Reports.ReciboPersonalizado.rdlc";

            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[13];

            p[0] = new Microsoft.Reporting.WinForms.ReportParameter("cliente", nomeCliente);
            p[1] = new Microsoft.Reporting.WinForms.ReportParameter("codigo", codCliente);
            p[2] = new Microsoft.Reporting.WinForms.ReportParameter("cep", cepCliente);
            p[3] = new Microsoft.Reporting.WinForms.ReportParameter("uf", ufcliente);
            p[4] = new Microsoft.Reporting.WinForms.ReportParameter("cidade", cidadeCliente);
            p[5] = new Microsoft.Reporting.WinForms.ReportParameter("numero", numeroCliente);
            p[6] = new Microsoft.Reporting.WinForms.ReportParameter("endereco", enderecoCliente);
            p[7] = new Microsoft.Reporting.WinForms.ReportParameter("bairro", bairroCliente);
            p[8] = new Microsoft.Reporting.WinForms.ReportParameter("servico", servicoCliente);
            p[9] = new Microsoft.Reporting.WinForms.ReportParameter("valor", valorCliente);
            p[10] = new Microsoft.Reporting.WinForms.ReportParameter("valor_extenso", valorExtCliente);
            p[11] = new Microsoft.Reporting.WinForms.ReportParameter("mes_referencia", mes_referencia);
            p[12] = new Microsoft.Reporting.WinForms.ReportParameter("data_pgto", data_pgto);

            reportViewer1.LocalReport.SetParameters(p);
          
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            var setup = reportViewer1.GetPageSettings();
            setup.Margins = new System.Drawing.Printing.Margins(2, 2, 2, 2);
            reportViewer1.SetPageSettings(setup);
        }

        private void ReciboPerso_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void ReciboPerso_FormClosing(object sender, FormClosingEventArgs e)
        {
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}
