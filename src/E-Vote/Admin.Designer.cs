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
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "E-VOTE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Administrador";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabEleicoes);
            this.tabControl.Controls.Add(this.tabPartidos);
            this.tabControl.Controls.Add(this.tabCandidatos);
            this.tabControl.Location = new System.Drawing.Point(46, 81);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(707, 322);
            this.tabControl.TabIndex = 2;
            // 
            // tabEleicoes
            // 
            this.tabEleicoes.Location = new System.Drawing.Point(4, 22);
            this.tabEleicoes.Name = "tabEleicoes";
            this.tabEleicoes.Padding = new System.Windows.Forms.Padding(3);
            this.tabEleicoes.Size = new System.Drawing.Size(699, 296);
            this.tabEleicoes.TabIndex = 0;
            this.tabEleicoes.Text = "Eleições";
            this.tabEleicoes.UseVisualStyleBackColor = true;
            // 
            // tabPartidos
            // 
            this.tabPartidos.Location = new System.Drawing.Point(4, 22);
            this.tabPartidos.Name = "tabPartidos";
            this.tabPartidos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPartidos.Size = new System.Drawing.Size(699, 296);
            this.tabPartidos.TabIndex = 1;
            this.tabPartidos.Text = "Partidos";
            this.tabPartidos.UseVisualStyleBackColor = true;
            // 
            // tabCandidatos
            // 
            this.tabCandidatos.Location = new System.Drawing.Point(4, 22);
            this.tabCandidatos.Name = "tabCandidatos";
            this.tabCandidatos.Padding = new System.Windows.Forms.Padding(3);
            this.tabCandidatos.Size = new System.Drawing.Size(699, 296);
            this.tabCandidatos.TabIndex = 2;
            this.tabCandidatos.Text = "Candidatos";
            this.tabCandidatos.UseVisualStyleBackColor = true;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Admin";
            this.Text = "Admin";
            this.tabControl.ResumeLayout(false);
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
    }
}