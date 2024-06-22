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
            this.name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(352, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 41);
            this.label1.TabIndex = 9;
            this.label1.Text = "E-VOTE";
            // 
            // e_vote
            // 
            this.e_vote.AutoSize = true;
            this.e_vote.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.e_vote.ForeColor = System.Drawing.SystemColors.Control;
            this.e_vote.Location = new System.Drawing.Point(371, 120);
            this.e_vote.Name = "e_vote";
            this.e_vote.Size = new System.Drawing.Size(103, 21);
            this.e_vote.TabIndex = 8;
            this.e_vote.Text = "Bem-vindo ao";
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.LightGreen;
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.Location = new System.Drawing.Point(375, 332);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 30);
            this.buttonLogin.TabIndex = 7;
            this.buttonLogin.Text = "Entrar";
            this.buttonLogin.UseMnemonic = false;
            this.buttonLogin.UseVisualStyleBackColor = false;
            // 
            // name
            // 
            this.name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(341, 257);
            this.name.MaxLength = 11;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(140, 26);
            this.name.TabIndex = 6;
            this.name.Text = "Digite seu CPF:";
            this.name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(853, 612);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.e_vote);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.name);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label e_vote;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox name;
    }
}