using Eleicoes;
using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Vote
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            verificarArquivos.verificar();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            gravadorUsuario gravador = new gravadorUsuario();
            gravador.salvarUsuario(cpf.Text);

            redirecionar();
        }

        public void redirecionar()
        {
            if(cpf.Text != "")
            {
                if (conferirDados.conferirSeNumerico(cpf.Text) && cpf.Text.Length == 11)
                {
                    if (cpf.Text == "00000000000")
                    {
                        Admin novoFormulario = new Admin();

                        // Exibe o novo formulário de forma assíncrona usando uma nova thread
                        Thread thread = new Thread(() =>
                        {
                            Application.Run(novoFormulario);
                        });
                        thread.Start();

                        // Fecha o formulário atual de forma assíncrona
                        this.BeginInvoke(new Action(() =>
                        {
                            this.Close();
                        }));

                    }
                    else
                    {
                       Eleicao novoFormulario = new Eleicao(cpf.Text);

                        // Exibe o novo formulário de forma assíncrona usando uma nova thread
                        Thread thread = new Thread(() =>
                        {
                            Application.Run(novoFormulario);
                        });
                        thread.Start();

                        // Fecha o formulário atual de forma assíncrona
                        this.BeginInvoke(new Action(() =>
                        {
                            this.Close();
                        }));
                    }
                }
                else
                {
                    MessageBox.Show("CPF invalido");
                }
            }
            else 
            {
                MessageBox.Show("Preencha o CPF");
            }


        }


    }
}
