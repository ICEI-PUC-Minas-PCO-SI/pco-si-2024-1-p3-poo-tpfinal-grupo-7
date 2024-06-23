using Classes;
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

            abrirTelaAdmin();
        }

        public void abrirTelaAdmin()
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

        public void abrirTelaLista()//alterar com os dados da tela com a lista de votações
        {
            //Admin novoFormulario = new Admin();

            // Exibe o novo formulário de forma assíncrona usando uma nova thread
            Thread thread = new Thread(() =>
            {
                //Application.Run(novoFormulario);
            });
            thread.Start();

            // Fecha o formulário atual de forma assíncrona
            this.BeginInvoke(new Action(() =>
            {
                this.Close();
            }));
        }
    
    }
}
