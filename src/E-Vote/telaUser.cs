using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eleicoes;

namespace E_Vote
{
    public partial class telaUser : Form
    {
        private int votos = 0;
        public List<Candidato> candidatos;
        public telaUser(string mensagem)
        {
            InitializeComponent();

            candidatos = new List<Candidato>();

            lerCandidatos(listView1);

            label2.Text = mensagem;
            label3.Text = $"(Código {mensagem})";

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
            if (botao != null && textBox1.Text.Length < 5)
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
            }
            else
            {

                foreach (var c in candidatos)
                {


                    if (c.Codigo == int.Parse(textBox1.ToString()))
                    {
                        c.Votos++;
                        textBox1.Text = "";
                        MessageBox.Show($"Voto registrado para {c.Nome}!");

                        string nomeArquivo = "total_votoscandidato.txt";

                        try
                        {
                            using (StreamWriter sw = new StreamWriter(nomeArquivo))
                            {
                                sw.WriteLine("Detalhe dos votos por candidato:");
                               
                                    sw.WriteLine($"{c.Nome} (ID: {c.Codigo}): {c.Votos} votos");
                                
                            }

                            Console.WriteLine($"Arquivo '{nomeArquivo}' criado com sucesso.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ocorreu um erro ao escrever o arquivo: {ex.Message}");
                        }
                    }
                    
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //ver se precisa mudar isso aq 

            textBox1.Text = "";
            foreach(var c in candidatos)
                {
                if (textBox1.Text == "")
                {
                    votos++;
                    textBox1.Text = "";
                    c.Votos = votos;

                    string nomeArquivo = "total_votoscandidato.txt";

                    try
                    {
                        using (StreamWriter sw = new StreamWriter(nomeArquivo))
                        {
                            sw.WriteLine("Detalhe dos votos por candidato:");

                            sw.WriteLine($"{c.Nome} (ID: {c.Codigo}): {c.Votos} votos");

                        }

                        Console.WriteLine($"Arquivo '{nomeArquivo}' criado com sucesso.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ocorreu um erro ao escrever o arquivo: {ex.Message}");
                    }

                }

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }
    
        public void lerCandidatos(ListView listViewCandidatos)
        {
            listViewCandidatos.Clear();
            listViewCandidatos.View = View.Details;
            listViewCandidatos.FullRowSelect = true;
            listViewCandidatos.Columns.Add("Codigo", 62);
            listViewCandidatos.Columns.Add("Nome", 62);
            listViewCandidatos.Columns.Add("Partido", 62);
            listViewCandidatos.Columns.Add("Idade", 62);

            leitorCandidatos leitor = new leitorCandidatos();
            List<Candidato> candidatos = leitor.lerCandidatos();

            listViewCandidatos.Items.Clear();
            foreach (var candidato in candidatos)
            {
                var candidatoNaLista = new ListViewItem(candidato.Codigo.ToString());
                candidatoNaLista.SubItems.Add(candidato.Nome);
                candidatoNaLista.SubItems.Add(candidato.Partido);
                candidatoNaLista.SubItems.Add(candidato.Idade.ToString());

                listViewCandidatos.Items.Add(candidatoNaLista);
            }
        }
    }
}
