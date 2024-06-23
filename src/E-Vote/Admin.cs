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
using static System.Windows.Forms.LinkLabel;

namespace E_Vote
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            leitorCandidatos leitor = new leitorCandidatos();
            atualizarLista(listBox1, leitor.lerCandidatos());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            leitorCandidatos leitor = new leitorCandidatos();
            List<Candidato> candidatos = leitor.lerCandidatos();

            int count = 0;

            Candidato novoCandidato = new Candidato(textBox18.Text, int.Parse(textBox1.Text), textBox17.Text, int.Parse(textBox16.Text), 0);

            foreach (Candidato c in candidatos)
            {
             
                if (novoCandidato.Nome == c.Nome)
                {
                    count++;
                    break;
                }
                
            }

            if (count == 0)
            {
                candidatos.Add(novoCandidato);
            }
            else
            {
                MessageBox.Show("Candidato já cadastrado");
            }

            gravadorCandidatos gravador = new gravadorCandidatos();
            gravador.salvarCandidatos(candidatos);
            atualizarLista(listBox1, candidatos);

        }

        public void atualizarLista(ListBox listBox, List<Candidato> candidatos)
        {
            listBox.Items.Clear(); // Limpa os itens existentes na ListBox
            foreach (var candidato in candidatos)
            {
                listBox.Items.Add($"Codigo: {candidato.Codigo}, Nome: {candidato.Nome}, Idade: {candidato.Idade}, Partido: {candidato.Partido}");
            }
        }
    }
}
