using Eleicoes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace E_Vote
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();

            configurarListViews(listView3,listView2);

            leitorCandidatos leitorC = new leitorCandidatos();
            leitorPartidos leitorP = new leitorPartidos();

           atualizarListaCandidato(listView2, leitorC.lerCandidatos());
            atualizarListaPartido(listView3, leitorP.lerPartido());
        }

        //adicionar candidato
   
        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "" && textBox17.Text != "" && textBox18.Text != "" && textBox16.Text != "")
            {
                if (conferirDados.conferirSeNumerico(textBox6.Text) && conferirDados.conferirSeNumerico(textBox16.Text))
                {
                    leitorCandidatos leitor = new leitorCandidatos();
                    List<Candidato> candidatos = leitor.lerCandidatos();

                    int count = 0;

                    Candidato novoCandidato = new Candidato(textBox18.Text, int.Parse(textBox6.Text), textBox17.Text, int.Parse(textBox16.Text), 0);

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
                    atualizarListaCandidato(listView2, candidatos);
                }
                else
                {
                    MessageBox.Show("Dado em formato incorreto inserido, confira as informações");
                }
            }
            else
            {
                MessageBox.Show("Preencha os dados");
            }

        }
       
        public void atualizarListaCandidato(ListView listView, List<Candidato> candidatos)
        {
            listView.Items.Clear();
            foreach (var candidato in candidatos)
            {
                var candidatoNaLista = new ListViewItem(candidato.Codigo.ToString());
                candidatoNaLista.SubItems.Add(candidato.Nome);
                candidatoNaLista.SubItems.Add(candidato.Partido);
                candidatoNaLista.SubItems.Add(candidato.Idade.ToString());

                listView.Items.Add(candidatoNaLista);
            }
        }

      
        //adicionar partido
       
        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox8.Text != "" && textBox7.Text != "")
            {
                if (conferirDados.conferirSeNumerico(textBox8.Text))
                {
                    leitorPartidos leitor = new leitorPartidos();
                    List<Partido> partidos = leitor.lerPartido();

                    int count = 0;

                    Partido novoPartido = new Partido(textBox7.Text, int.Parse(textBox8.Text));

                    foreach (Partido c in partidos)
                    {

                        if (novoPartido.getNome() == c.getNome() || novoPartido.getCodigo() == c.getCodigo())
                        {
                            count++;
                            break;
                        }

                    }

                    if (count == 0)
                    {
                        partidos.Add(novoPartido);
                    }
                    else
                    {
                        MessageBox.Show("Dado já cadastrado inserido");
                    }

                    gravadorPartidos gravador = new gravadorPartidos();
                    gravador.salvarPartido(partidos);
                    atualizarListaPartido(listView3, partidos);
                }
                else
                {
                    MessageBox.Show("Dado em formato incorreto inserido, confira as informações");
                }
            }
            else
            {
                MessageBox.Show("Preencha os dados");
            }
            
        }
        public void atualizarListaPartido(ListView listViewPartidos, List<Partido> partidos)
        {
            listViewPartidos.Items.Clear();
            foreach (var Partido in partidos)
            {
                var partidoNaLista = new ListViewItem(Partido.getCodigo().ToString());
                partidoNaLista.SubItems.Add(Partido.getNome());

                listViewPartidos.Items.Add(partidoNaLista);
            }
        }

        public void configurarListViews(ListView listViewPartidos, ListView listViewCandidatos)
        {
            listViewPartidos.Clear();
            listViewPartidos.View = View.Details;
            listViewPartidos.FullRowSelect = true;
            listViewPartidos.Columns.Add("Codigo", 100);
            listViewPartidos.Columns.Add("Nome", 100);
            

            listViewCandidatos.Clear();
            listViewCandidatos.View = View.Details;
            listViewCandidatos.FullRowSelect = true;
            listViewCandidatos.Columns.Add("Codigo", 62);
            listViewCandidatos.Columns.Add("Nome", 62);
            listViewCandidatos.Columns.Add("Partido", 62);
            listViewCandidatos.Columns.Add("Idade", 62);
        }

    }
}
