using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;

namespace E_Vote
{
    public partial class telaUser : Form
    {
        private int votos = 0;
        public List<Candidato> candidatos;
        public telaUser()
        {
            InitializeComponent();

            candidatos = new List<Candidato>();

            button1.Click += Botao_Click;
            button2.Click += Botao_Click;
            button3.Click += Botao_Click;
            button4.Click += Botao_Click;
            button5.Click += Botao_Click;
            button6.Click += Botao_Click;
            button7.Click += Botao_Click;
            button8.Click += Botao_Click;
            button9.Click += Botao_Click;
            button10.Click += Botao_Click;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "1";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "6";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "8";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void Botao_Click(object sender, EventArgs e)
        {
            Button botao = sender as Button;
            if (botao != null)
            {
                textBox1.Text += botao.Text;
            }
        }



        private void telaUser_Load(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)

           
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Precisa votar em um candidato!");
            } else
            {
                string codCandidato = textBox1.Text;

                
                Candidato candidato = candidatos.Find(c => c.Codigo.Equals(codCandidato));

                if (candidato != null)
                {
                    
                    candidato.Votos++;

                    
                    textBox1.Text = "";

                   
                    MessageBox.Show($"Voto registrado para {candidato.Nome}!");
                }
                else
                {
                  
                    MessageBox.Show($"Candidato {codCandidato} não encontrado!");
                }


            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            if (textBox1.Text == "")
            {
                votos++;
            } else
            {
                MessageBox.Show("Precisa votar em um candidato!");

            }
           

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }
    }
}
