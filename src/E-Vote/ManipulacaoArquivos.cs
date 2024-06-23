using Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Vote
{

    public class leitorUsuarios
    {
        private string caminhoDoArquivo;

        public leitorUsuarios()
        {
            this.caminhoDoArquivo = Directory.GetCurrentDirectory() + "/usuarioLogado.txt";
        }

        public int lerUsuarios()
        {

                using (StreamReader sr = new StreamReader(this.caminhoDoArquivo))
                {
                        return int.Parse(sr.ReadLine());

                }

        }

    }

    public class gravadorUsuario
    {
        private string caminhoDoArquivo;

        public gravadorUsuario()
        {
            this.caminhoDoArquivo = Directory.GetCurrentDirectory() + "/usuarioLogado.txt";
        }

        public void salvarUsuario(string cpf)
        {

            using (StreamWriter sw = new StreamWriter(this.caminhoDoArquivo))
            {
                sw.WriteLine(cpf);
            }

        }

    }

    public class conferirDadosLogin
    {
        public bool conferir(List<Usuario> usuariosCadastrados, int cpfInformado)
        {
            bool permitirLogin = false;

            for (int i = 0; i < usuariosCadastrados.Count; i++)
            {
                int cpfCadastrado = usuariosCadastrados[i].getCpf();
                if (cpfCadastrado == cpfInformado)
                {
                    permitirLogin = true;
                    break;
                }
            }
            return permitirLogin;
        }
    }



    public class gravadorCandidatos
    {
        private string caminhoDoArquivo;

        public gravadorCandidatos()
        {
            this.caminhoDoArquivo = Directory.GetCurrentDirectory() + "/candidatos.txt";
        }

        public void salvarCandidatos(List<Candidato> candidatos)
        {

            using (StreamWriter sw = new StreamWriter(this.caminhoDoArquivo))
            {
                foreach(Candidato c in candidatos) 
                { 
                    sw.WriteLine($"{c.Nome};{c.Codigo};{c.Partido};{c.Idade};{c.Votos}");
                }

            }

        }
    }

    public class leitorCandidatos
    {
        private string caminhoDoArquivo;

        public leitorCandidatos()
        {
            this.caminhoDoArquivo = Directory.GetCurrentDirectory() + "/candidatos.txt";
        }

        public List<Candidato> lerCandidatos()
        {
            List<Candidato> candidatos = new List<Candidato>();

            using (StreamReader sr = new StreamReader(this.caminhoDoArquivo))
            {

                string linha = sr.ReadLine();

                while (linha != null)
                {
                    string[] dados = linha.Split(';');

                    Candidato candidatoLido = new Candidato(dados[0], int.Parse(dados[1]), dados[2], int.Parse(dados[3]), int.Parse(dados[4]));
                    candidatos.Add(candidatoLido);

                    linha = sr.ReadLine();
                }

            }

            return candidatos;
        }
    }

}
