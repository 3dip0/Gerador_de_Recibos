namespace Gerador_de_Recibos.Forms
{
    partial class ReciboPersonalizado
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.extenso = new System.Windows.Forms.Button();
            this.buscarCEP = new System.Windows.Forms.Button();
            this.mesRef = new System.Windows.Forms.MaskedTextBox();
            this.dataPgto = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cidade = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.uf = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.servico = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.valorExt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.valor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cep = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bairro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.endereco = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nome = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.extenso);
            this.panel1.Controls.Add(this.buscarCEP);
            this.panel1.Controls.Add(this.mesRef);
            this.panel1.Controls.Add(this.dataPgto);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.cidade);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.uf);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.servico);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.valorExt);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.valor);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cep);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.bairro);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.numero);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.endereco);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cod);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.nome);
            this.panel1.Location = new System.Drawing.Point(12, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 388);
            this.panel1.TabIndex = 20;
            // 
            // extenso
            // 
            this.extenso.Location = new System.Drawing.Point(223, 193);
            this.extenso.Name = "extenso";
            this.extenso.Size = new System.Drawing.Size(75, 23);
            this.extenso.TabIndex = 49;
            this.extenso.Text = "Escrever";
            this.extenso.UseVisualStyleBackColor = true;
            this.extenso.Click += new System.EventHandler(this.Extenso_Click);
            // 
            // buscarCEP
            // 
            this.buscarCEP.Location = new System.Drawing.Point(223, 64);
            this.buscarCEP.Name = "buscarCEP";
            this.buscarCEP.Size = new System.Drawing.Size(75, 20);
            this.buscarCEP.TabIndex = 4;
            this.buscarCEP.Text = "Preencher";
            this.buscarCEP.UseVisualStyleBackColor = true;
            this.buscarCEP.Click += new System.EventHandler(this.BuscarCEP_Click);
            // 
            // mesRef
            // 
            this.mesRef.Location = new System.Drawing.Point(120, 246);
            this.mesRef.Mask = "00/0000";
            this.mesRef.Name = "mesRef";
            this.mesRef.Size = new System.Drawing.Size(100, 20);
            this.mesRef.TabIndex = 13;
            this.mesRef.ValidatingType = typeof(System.DateTime);
            this.mesRef.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.MesRef_MaskInputRejected);
            // 
            // dataPgto
            // 
            this.dataPgto.Location = new System.Drawing.Point(120, 272);
            this.dataPgto.Mask = "00/00/0000";
            this.dataPgto.Name = "dataPgto";
            this.dataPgto.Size = new System.Drawing.Size(100, 20);
            this.dataPgto.TabIndex = 14;
            this.dataPgto.ValidatingType = typeof(System.DateTime);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(182, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 48;
            this.label13.Text = "Cidade";
            // 
            // cidade
            // 
            this.cidade.Location = new System.Drawing.Point(225, 89);
            this.cidade.Name = "cidade";
            this.cidade.Size = new System.Drawing.Size(193, 20);
            this.cidade.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "UF";
            // 
            // uf
            // 
            this.uf.Location = new System.Drawing.Point(120, 89);
            this.uf.Name = "uf";
            this.uf.Size = new System.Drawing.Size(56, 20);
            this.uf.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(223, 311);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "Cancelar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(141, 311);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Limpar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Gerar Recibo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 170);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Serviço";
            // 
            // servico
            // 
            this.servico.Location = new System.Drawing.Point(120, 167);
            this.servico.Name = "servico";
            this.servico.Size = new System.Drawing.Size(298, 20);
            this.servico.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 275);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "Data de pagamento";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Mês de Referência";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Valor por extenso";
            // 
            // valorExt
            // 
            this.valorExt.Location = new System.Drawing.Point(120, 220);
            this.valorExt.Name = "valorExt";
            this.valorExt.Size = new System.Drawing.Size(298, 20);
            this.valorExt.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Valor";
            // 
            // valor
            // 
            this.valor.Location = new System.Drawing.Point(120, 194);
            this.valor.Name = "valor";
            this.valor.Size = new System.Drawing.Size(102, 20);
            this.valor.TabIndex = 11;
            this.valor.TextChanged += new System.EventHandler(this.Valor_TextChanged);
            this.valor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Valor_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "CEP";
            this.label6.Click += new System.EventHandler(this.Label6_Click);
            // 
            // cep
            // 
            this.cep.Location = new System.Drawing.Point(120, 64);
            this.cep.Name = "cep";
            this.cep.Size = new System.Drawing.Size(102, 20);
            this.cep.TabIndex = 3;
            this.cep.TextChanged += new System.EventHandler(this.Cep_TextChanged);
            this.cep.Leave += new System.EventHandler(this.Cep_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Bairro";
            // 
            // bairro
            // 
            this.bairro.Location = new System.Drawing.Point(120, 141);
            this.bairro.Name = "bairro";
            this.bairro.Size = new System.Drawing.Size(298, 20);
            this.bairro.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(325, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "nº";
            // 
            // numero
            // 
            this.numero.Location = new System.Drawing.Point(348, 115);
            this.numero.Name = "numero";
            this.numero.Size = new System.Drawing.Size(70, 20);
            this.numero.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Endereço";
            // 
            // endereco
            // 
            this.endereco.Location = new System.Drawing.Point(120, 115);
            this.endereco.Name = "endereco";
            this.endereco.Size = new System.Drawing.Size(198, 20);
            this.endereco.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Codigo";
            // 
            // cod
            // 
            this.cod.Location = new System.Drawing.Point(120, 38);
            this.cod.Name = "cod";
            this.cod.Size = new System.Drawing.Size(102, 20);
            this.cod.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Nome";
            // 
            // nome
            // 
            this.nome.Location = new System.Drawing.Point(120, 12);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(298, 20);
            this.nome.TabIndex = 1;
            // 
            // ReciboPersonalizado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 450);
            this.Controls.Add(this.panel1);
            this.Name = "ReciboPersonalizado";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ReciboPersonalizado_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox servico;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox valorExt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox valor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox cep;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox bairro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox numero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox endereco;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nome;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox cidade;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox uf;
        private System.Windows.Forms.MaskedTextBox mesRef;
        private System.Windows.Forms.MaskedTextBox dataPgto;
        private System.Windows.Forms.Button buscarCEP;
        private System.Windows.Forms.Button extenso;
    }
}