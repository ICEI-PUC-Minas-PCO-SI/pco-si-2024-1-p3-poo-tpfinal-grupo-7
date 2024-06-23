namespace E_Vote
{
    partial class Admin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabEleicoes = new System.Windows.Forms.TabPage();
            this.tabPartidos = new System.Windows.Forms.TabPage();
            this.tabCandidatos = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabCandidatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(37, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "E-VOTE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(39, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Administrador";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabEleicoes);
            this.tabControl.Controls.Add(this.tabPartidos);
            this.tabControl.Controls.Add(this.tabCandidatos);
            this.tabControl.Location = new System.Drawing.Point(61, 100);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(943, 396);
            this.tabControl.TabIndex = 2;
            // 
            // tabEleicoes
            // 
            this.tabEleicoes.Location = new System.Drawing.Point(4, 25);
            this.tabEleicoes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabEleicoes.Name = "tabEleicoes";
            this.tabEleicoes.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabEleicoes.Size = new System.Drawing.Size(935, 367);
            this.tabEleicoes.TabIndex = 0;
            this.tabEleicoes.Text = "Eleições";
            this.tabEleicoes.UseVisualStyleBackColor = true;
            this.tabEleicoes.Click += new System.EventHandler(this.tabEleicoes_Click);
            // 
            // tabPartidos
            // 
            this.tabPartidos.Location = new System.Drawing.Point(4, 25);
            this.tabPartidos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPartidos.Name = "tabPartidos";
            this.tabPartidos.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPartidos.Size = new System.Drawing.Size(935, 367);
            this.tabPartidos.TabIndex = 1;
            this.tabPartidos.Text = "Partidos";
            this.tabPartidos.UseVisualStyleBackColor = true;
            // 
            // tabCandidatos
            // 
            this.tabCandidatos.Controls.Add(this.textBox1);
            this.tabCandidatos.Location = new System.Drawing.Point(4, 25);
            this.tabCandidatos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabCandidatos.Name = "tabCandidatos";
            this.tabCandidatos.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabCandidatos.Size = new System.Drawing.Size(935, 367);
            this.tabCandidatos.TabIndex = 2;
            this.tabCandidatos.Text = "Candidatos";
            this.tabCandidatos.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(345, 125);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Admin";
            this.Text = "Admin";
            this.tabControl.ResumeLayout(false);
            this.tabCandidatos.ResumeLayout(false);
            this.tabCandidatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabEleicoes;
        private System.Windows.Forms.TabPage tabPartidos;
        private System.Windows.Forms.TabPage tabCandidatos;
        private System.Windows.Forms.TextBox textBox1;
    }
}