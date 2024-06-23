namespace E_Vote
{
    partial class Login
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
            this.e_vote = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.cpf = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(469, 174);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 51);
            this.label1.TabIndex = 9;
            this.label1.Text = "E-VOTE";
            // 
            // e_vote
            // 
            this.e_vote.AutoSize = true;
            this.e_vote.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.e_vote.ForeColor = System.Drawing.SystemColors.Control;
            this.e_vote.Location = new System.Drawing.Point(495, 148);
            this.e_vote.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.e_vote.Name = "e_vote";
            this.e_vote.Size = new System.Drawing.Size(130, 25);
            this.e_vote.TabIndex = 8;
            this.e_vote.Text = "Bem-vindo ao";
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.LightGreen;
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.Location = new System.Drawing.Point(500, 409);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(100, 37);
            this.buttonLogin.TabIndex = 7;
            this.buttonLogin.Text = "Entrar";
            this.buttonLogin.UseMnemonic = false;
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // cpf
            // 
            this.cpf.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpf.Location = new System.Drawing.Point(455, 316);
            this.cpf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cpf.MaxLength = 11;
            this.cpf.Name = "cpf";
            this.cpf.Size = new System.Drawing.Size(185, 30);
            this.cpf.TabIndex = 6;
            this.cpf.Text = "Digite seu CPF:";
            this.cpf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1137, 753);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.e_vote);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.cpf);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Login";
            this.Text = "E-Vote: Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label e_vote;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox cpf;
    }
}