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

            configurarListViews(listView3, listView2);

            leitorCandidatos leitorC = new leitorCandidatos();
            leitorPartidos leitorP = new leitorPartidos();

            atualizarListaCandidato(listView2, leitorC.lerCandidatos());
            atualizarListaPartido(listView3, leitorP.lerPartido());
            
        }

        public void teste()
        {
            leitorEleicaoExecutiva leitor = new leitorEleicaoExecutiva();
            List<Executivo> eleicoes = leitor.ler();

            Executivo exc = new Executivo(int.Parse(textBox4.Text), 1,0);

            List<Candidato> cand = new List<Candidato>();

            string codigosEntrada = codigosAdicionadosCandidatos;
            string[] codigos = codigosEntrada.Split('/');

            leitorCandidatos leitorCands = new leitorCandidatos();
            List<Candidato> listaCandidatos = leitorCands.lerCandidatos();

            for (int i = 0; i < codigos.Length - 1; i++)
            {
                for (int j = 0; j < listaCandidatos.Count; j++)
                {
                    if (listaCandidatos[j].Codigo == int.Parse(codigos[i]))
                    {
                        Candidato ent = new Candidato(listaCandidatos[j].Nome, listaCandidatos[j].Codigo, listaCandidatos[j].Partido, listaCandidatos[j].Idade, 0);
                        cand.Add(ent);
                        break;
                    }
                }
            }


            
            exc.setCandidatos(cand);
            eleicoes.Add(exc);

            gravadorEleicaoExecutiva gv = new gravadorEleicaoExecutiva();
            gv.gravar(eleicoes);

            lerEleicaoExecutiva();
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

        //Remover Candidato
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox13.Text != "")
            {
                leitorCandidatos leitor = new leitorCandidatos();
                List<Candidato> candidatos = leitor.lerCandidatos();

                List<Candidato> candidatosAposExclusao = new List<Candidato>();

                int count = 0;

                foreach (Candidato c in candidatos)
                {

                    if (textBox13.Text != c.Nome)
                    {
                        candidatosAposExclusao.Add(c);
                    }
                    else
                    {
                        count++;
                    }

                }

                if (count > 0)
                {
                    gravadorCandidatos gravador = new gravadorCandidatos();
                    gravador.salvarCandidatos(candidatosAposExclusao);
                    atualizarListaCandidato(listView2 ,candidatosAposExclusao);
                }
                else
                {
                    MessageBox.Show("Candidato não encontrado");
                }

                
            }
            else
            {
                MessageBox.Show("Preencha o campo");
            }
       
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                leitorPartidos leitor = new leitorPartidos();
                List<Partido> partidos = leitor.lerPartido();

                List<Partido> partidosAposExclusao = new List<Partido>();

                int count = 0;

                foreach (Partido c in partidos)
                {

                    if (textBox5.Text != c.getCodigo().ToString())
                    {
                        partidosAposExclusao.Add(c);
                    }
                    else
                    {
                        count++;
                    }

                }

                if (count > 0)
                {
                    gravadorPartidos gravador = new gravadorPartidos();
                    gravador.salvarPartido(partidosAposExclusao);
                    atualizarListaPartido(listView3, partidosAposExclusao);
                }
                else
                {
                    MessageBox.Show("Partido não encontrado");
                }


            }
            else
            {
                MessageBox.Show("Preencha o campo");
            }
        }

        public void salvarEleicaoExecutiva()
        {

            leitorEleicaoExecutiva leitor = new leitorEleicaoExecutiva();
            List<Executivo> eleicoes = leitor.ler();

            foreach (Executivo ele in eleicoes)
            {
                //MessageBox.Show(ele.getId().ToString());
            }

            

            Executivo exc = new Executivo(01, 1,0);
            exc.candidatos[0] = new Candidato("c100", 28, "p1", 0, 46);
            exc.candidatos[1] = new Candidato("c2", 29, "p2", 0, 87);
            eleicoes.Add(exc);
            /*
            Executivo exc2 = new Executivo(01, 2, 1);
            exc2.candidatos[0] = new Candidato("c3", 30, "p3", 0, 24);
            exc2.candidatos[1] = new Candidato("c4", 31, "p4", 0, 19);


            List<Executivo> lista = new List<Executivo>();
            lista.Add(exc);
            lista.Add(exc2);
            */
            gravadorEleicaoExecutiva gravador = new gravadorEleicaoExecutiva();
            gravador.gravar(eleicoes);
        }

        public void lerEleicaoExecutiva()
        {
            leitorEleicaoExecutiva leitor = new leitorEleicaoExecutiva();
            List<Executivo> eleicoes = leitor.ler();

            listView1.Items.Clear();


            listView1.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Id", 30);
            listView1.Columns.Add("Votos", 40);
            listView1.Columns.Add("Candidatos", 135);
            listView1.Columns.Add("Turnos", 45);


            string codigosCandidatos = "";


            foreach (Executivo e in eleicoes)
            {

                codigosCandidatos = "";

                for (int i = 0; i < e.candidatos.Count; i++)
                {
                   // MessageBox.Show(i.ToString());
                    codigosCandidatos += e.candidatos[i].Codigo + "/";
                }

                var partidoNaLista = new ListViewItem(e.getId().ToString());
                partidoNaLista.SubItems.Add(e.getTotalDeVotos().ToString());
                partidoNaLista.SubItems.Add(codigosCandidatos);
                partidoNaLista.SubItems.Add(e.getTurnos().ToString());

                listView1.Items.Add(partidoNaLista);
            }
        }


        public void lerEleicaoLegislativa()
        {
            /*
            leitorEleicaoExecutiva leitor = new leitorEleicaoExecutiva();
            List<Executivo> eleicoes = leitor.ler();
            */
            listView1.Items.Clear();


            listView1.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Id", 30);
            listView1.Columns.Add("Votos", 40);
            listView1.Columns.Add("Partidos", 120);
            listView1.Columns.Add("Cadeiras", 60);

            /*
            string codigosPartidos = "";


            foreach (Executivo e in eleicoes)
            {

                codigosPartidos = "";

                for (int i = 1; i < e.candidatos.Length; i++)
                {
                    codigosPartidos += e.candidatos[i].Codigo + "/";
                }

                var partidoNaLista = new ListViewItem(e.getId().ToString());
                partidoNaLista.SubItems.Add(e.getTotalDeVotos().ToString());
                partidoNaLista.SubItems.Add(codigosPartidos);
                partidoNaLista.SubItems.Add(e.getTurnos().ToString());

                listView1.Items.Add(partidoNaLista);
            }
            */
        }


        public void lerTodasAsEleicoes()
        {
            listView1.Items.Clear();


            listView1.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Id", 60);
            listView1.Columns.Add("Votos", 60);
            listView1.Columns.Add("Tipo", 120);

        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            lerEleicaoLegislativa();
        }

        private void tabNewEleicao_Enter(object sender, EventArgs e)
        {
            lerEleicaoExecutiva();
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            lerTodasAsEleicoes();
        }

        string codigosAdicionadosCandidatos = "";
        string codigosAdicionadosPartidos= "";

        private void button6_Click(object sender, EventArgs e)
        {
            codigosAdicionadosCandidatos += textBox9.Text+"/";
            label23.Text = "Candidatos adicionados: " + codigosAdicionadosCandidatos;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            codigosAdicionadosPartidos += textBox10.Text + "/";
            label24.Text = "Partidos adicionados: " + codigosAdicionadosPartidos;
        }

        //Adicionar eleição executiva
        private void button5_Click(object sender, EventArgs e)
        {
            teste();
            //leitorEleicaoExecutiva leitor = new leitorEleicaoExecutiva();
            //List<Executivo> eleicoes = leitor.ler();

            for(int i = 0; i < 1;i++)
            {
                //MessageBox.Show("eleicão: " + eleicoes[i].getId() +"/" +eleicoes[i].getTotalDeVotos()+"/"+ "executivo " + eleicoes[i].getTurnos() + "/" + eleicoes[i].getCandidatos());
            }


            //leitorCandidatos leitorCandidatos = new leitorCandidatos();
            //List<Candidato> listaCandidatos = leitorCandidatos.lerCandidatos();

            /*
            string[] codigos = codigosAdicionadosCandidatos.Split('/');

            for(int i = 0; i < codigos.Length-1; i++)
            {
                MessageBox.Show(codigos[i]);
            }

            Executivo novaEleicao = new Executivo(int.Parse(textBox4.Text),codigos.Length,1);

            for(int i = 0; i < codigos.Length-1; i++)
            {
                for(int j = 0; j < listaCandidatos.Count;j++)
                {
                    if (listaCandidatos[j].Codigo == int.Parse(codigos[i]))
                    {
                        //novaEleicao.candidatos[i] = 
                        new Candidato(listaCandidatos[j].Nome, listaCandidatos[j].Codigo, listaCandidatos[j].Partido, listaCandidatos[j].Idade, 0);
                        //MessageBox.Show(novaEleicao.candidatos[i].Nome);
                        break;
                    }
                }
            }

            //eleicoes.Add(novaEleicao);
            */
            //gravadorEleicaoExecutiva gravador = new gravadorEleicaoExecutiva();
            //gravador.gravar(eleicoes);

        }

    }
}
