namespace Gerador_de_Recibos.Forms
{
    partial class Pesquisa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pesquisa));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.textCod = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.entre = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.valorFinal = new System.Windows.Forms.TextBox();
            this.valorInicial = new System.Windows.Forms.TextBox();
            this.todos = new System.Windows.Forms.CheckBox();
            this.pesquisaCliente = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lista = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.painelReajuste = new System.Windows.Forms.Panel();
            this.reajustar = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.itens = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.valorReajuste = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.carregando = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.entre.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lista)).BeginInit();
            this.panel3.SuspendLayout();
            this.painelReajuste.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carregando)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textCod
            // 
            resources.ApplyResources(this.textCod, "textCod");
            this.textCod.Name = "textCod";
            this.textCod.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.entre);
            this.panel1.Controls.Add(this.todos);
            this.panel1.Controls.Add(this.pesquisaCliente);
            this.panel1.Controls.Add(this.textCod);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // entre
            // 
            this.entre.Controls.Add(this.label1);
            this.entre.Controls.Add(this.valorFinal);
            this.entre.Controls.Add(this.valorInicial);
            resources.ApplyResources(this.entre, "entre");
            this.entre.Name = "entre";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // valorFinal
            // 
            resources.ApplyResources(this.valorFinal, "valorFinal");
            this.valorFinal.Name = "valorFinal";
            this.valorFinal.TextChanged += new System.EventHandler(this.ValorFinal_TextChanged);
            // 
            // valorInicial
            // 
            resources.ApplyResources(this.valorInicial, "valorInicial");
            this.valorInicial.Name = "valorInicial";
            this.valorInicial.TextChanged += new System.EventHandler(this.ValorInicial_TextChanged);
            // 
            // todos
            // 
            resources.ApplyResources(this.todos, "todos");
            this.todos.Name = "todos";
            this.todos.UseVisualStyleBackColor = true;
            this.todos.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            // 
            // pesquisaCliente
            // 
            resources.ApplyResources(this.pesquisaCliente, "pesquisaCliente");
            this.pesquisaCliente.FormattingEnabled = true;
            this.pesquisaCliente.Items.AddRange(new object[] {
            resources.GetString("pesquisaCliente.Items"),
            resources.GetString("pesquisaCliente.Items1"),
            resources.GetString("pesquisaCliente.Items2"),
            resources.GetString("pesquisaCliente.Items3"),
            resources.GetString("pesquisaCliente.Items4"),
            resources.GetString("pesquisaCliente.Items5"),
            resources.GetString("pesquisaCliente.Items6"),
            resources.GetString("pesquisaCliente.Items7"),
            resources.GetString("pesquisaCliente.Items8"),
            resources.GetString("pesquisaCliente.Items9")});
            this.pesquisaCliente.Name = "pesquisaCliente";
            this.pesquisaCliente.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lista);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // lista
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.lista, "lista");
            this.lista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.lista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lista.Name = "lista";
            this.lista.RowHeadersVisible = false;
            this.lista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Lista_CellContentClick);
            this.lista.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Lista_DataBindingComplete);
            this.lista.SelectionChanged += new System.EventHandler(this.Lista_SelectionChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.painelReajuste);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button2);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel3_Paint);
            // 
            // painelReajuste
            // 
            resources.ApplyResources(this.painelReajuste, "painelReajuste");
            this.painelReajuste.Controls.Add(this.carregando);
            this.painelReajuste.Controls.Add(this.reajustar);
            this.painelReajuste.Controls.Add(this.button6);
            this.painelReajuste.Controls.Add(this.itens);
            this.painelReajuste.Controls.Add(this.button5);
            this.painelReajuste.Controls.Add(this.valorReajuste);
            this.painelReajuste.Controls.Add(this.button4);
            this.painelReajuste.Controls.Add(this.checkBox1);
            this.painelReajuste.Name = "painelReajuste";
            this.painelReajuste.Paint += new System.Windows.Forms.PaintEventHandler(this.PainelReajuste_Paint);
            // 
            // reajustar
            // 
            resources.ApplyResources(this.reajustar, "reajustar");
            this.reajustar.Name = "reajustar";
            this.reajustar.UseVisualStyleBackColor = true;
            this.reajustar.Click += new System.EventHandler(this.Reajustar_Click);
            // 
            // button6
            // 
            resources.ApplyResources(this.button6, "button6");
            this.button6.Name = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // itens
            // 
            resources.ApplyResources(this.itens, "itens");
            this.itens.FormattingEnabled = true;
            this.itens.Items.AddRange(new object[] {
            resources.GetString("itens.Items"),
            resources.GetString("itens.Items1")});
            this.itens.Name = "itens";
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // valorReajuste
            // 
            resources.ApplyResources(this.valorReajuste, "valorReajuste");
            this.valorReajuste.Name = "valorReajuste";
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            this.checkBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CheckBox1_MouseClick);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // carregando
            // 
            resources.ApplyResources(this.carregando, "carregando");
            this.carregando.Name = "carregando";
            this.carregando.TabStop = false;
            // 
            // Pesquisa
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Name = "Pesquisa";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Pesquisa_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.entre.ResumeLayout(false);
            this.entre.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lista)).EndInit();
            this.panel3.ResumeLayout(false);
            this.painelReajuste.ResumeLayout(false);
            this.painelReajuste.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carregando)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox textCod;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView lista;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox pesquisaCliente;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox valorReajuste;
        private System.Windows.Forms.Button reajustar;
        private System.Windows.Forms.ComboBox itens;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox todos;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel entre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox valorFinal;
        private System.Windows.Forms.TextBox valorInicial;
        public System.Windows.Forms.Panel painelReajuste;
        private System.Windows.Forms.PictureBox carregando;
    }
}