using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Eleicoes
{
    public class Partido
    {
        private string nome;
        private int votosRecebidos;

        public Partido(string _nome)
        {
            setNome(_nome);
            setVotosRecebidos(0);
        }

        public string getNome()
        {
            return this.nome;
        }

        public void setNome(string _nome)
        {
            this.nome = _nome;
        }

        public int getVotosRecebidos()
        {
            return this.votosRecebidos;
        }

        public void setVotosRecebidos(int _votosRecebidos)
        {
            this.votosRecebidos = _votosRecebidos;
        }
    }

    public class PartidoLegislativo : Partido
    {
        private int quocienteEleitoral;
        private int cadeiras;

        public PartidoLegislativo(string _nome) : base(_nome)
        {

        }

        public void calcularCadeiras(int votosRecebidos, double quocienteEleitoral)
        {
            this.cadeiras = (int)(votosRecebidos / quocienteEleitoral);
        }

        public int getCadeiras()
        {
            return this.cadeiras;
        }

        public void calcularQuociente(int totalDeVotos, int cadeirasDisponiveis)
        {
            this.quocienteEleitoral = totalDeVotos / cadeirasDisponiveis;
        }

        public int getQuocienteEleitoral()
        {
            return this.quocienteEleitoral;
        }
    }

    public abstract class Conta
    {
        public int cpf;

        public Conta(int cpf_)
        {
            cpf = cpf_;
        }

        public abstract int getCpf();

        public abstract void setCpf(int _cpf);

    }

    public class Usuario : Conta
    {

        public int cpf;

        public override int getCpf()
        {
            return this.cpf;
        }

        public override void setCpf(int _cpf)
        {
            this.cpf = _cpf;
        }

        public Usuario(int cpf_) : base(cpf_)
        {

        }

    }

    public class Administrador : Conta
    {

        public int cpf;

        public override int getCpf()
        {
            return this.cpf;
        }

        public override void setCpf(int _cpf)
        {
            this.cpf = _cpf;
        }

        public Administrador(int cpf_) : base(cpf_)
        {

        }

    }

    public abstract class Eleicao
    {
        protected int totalDeVotos = 0;

        public int getTotalDeVotos()
        {
            return totalDeVotos;
        }

        public void adicionarVotos(int votos)
        {
            totalDeVotos += votos;
        }

    }

    public class Candidato
    {
        public string Partido { get; set; }
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public int Votos { get; set; }
        public int Idade { get; set; }
        public Candidato(string nome, int codigo, string partido, int idade, int votos)
        {
            Nome = nome;
            Codigo = codigo;
            Votos = votos;
            Partido = partido;
            Idade = idade;
        }
    }

    public class Executivo : Eleicao
    {
        private Candidato[] candidatos;
        private int turno;

        public Executivo(int numeroCandidatos)
        {
            candidatos = new Candidato[numeroCandidatos];
            turno = 1;
        }

        public void PrimeiroTurno()
        {
            int totalVotos = 0;
            int maior = 0;
            Candidato vencedor = null;

            for (int i = 0; i < candidatos.Length; i++)
            {
                totalVotos += candidatos[i].Votos;
            }

            int maioriaAbsoluta = totalVotos / 2 + 1;


            for (int i = 0; i < candidatos.Length; i++)
            {
                if (candidatos[i].Votos >= maioriaAbsoluta)
                {
                    maior++;
                    vencedor = candidatos[i];
                    
                }
            }


            if (maior >= 2)
            {
                SegundoTurno();
            }
            else if (maior == 1)
            {
                Console.WriteLine($"Vencedor do primeiro turno: {vencedor.Nome}");
            }
        }

        public void RegistrarCandidato(Candidato candidato, int index)
        {
            candidatos[index] = candidato;
        }

        public void SegundoTurno()
        {
            turno = 2;

            var topTwo = candidatos.Where(c => c != null).OrderByDescending(c => c.Votos).Take(2).ToArray();

            Candidato candidato1 = topTwo[0];
            Candidato candidato2 = topTwo[1];

            turno = 2;


            Console.WriteLine($"Coloque os votos referentes ao {candidato1.Nome}!");
            int votosCandidato1 = int.Parse(Console.ReadLine());

            Console.WriteLine($"Coloque os votos referentes ao {candidato2.Nome}!");
            int votosCandidato2 = int.Parse(Console.ReadLine());

            candidato1.Votos = votosCandidato1;
            candidato2.Votos = votosCandidato2;

            if (candidato1.Votos > candidato2.Votos)
            {
                Console.WriteLine($"{candidato1.Nome} ganhou a eleição!");
            }
            else if (candidato2.Votos > candidato1.Votos)
            {
                Console.WriteLine($"{candidato2.Nome} ganhou a eleição!");
            }
            else
            {
                Console.WriteLine("Vamos para o desempate!");
                Desempate(candidato1, candidato2);
            }
        }

        public void Desempate(Candidato candidato1, Candidato candidato2)
        {
            if (candidato1.Idade > candidato2.Idade)
            {
                Console.WriteLine($"{candidato1.Nome} ganhou a eleição!");
            }
            else
            {
                Console.WriteLine($"{candidato2.Nome} ganhou a eleição!");
            }
        }
    }

    public class Legislativo : Eleicao
    {
        private List<PartidoLegislativo> partidos;
        private int cadeirasDisponiveis;

        public Legislativo()
        {
            partidos = new List<PartidoLegislativo>();
        }

        public void setCadeirasDisponiveis(int _cadeirasDisponiveis)
        {
            this.cadeirasDisponiveis = _cadeirasDisponiveis;
        }

        public int getCadeirasDisponiveis()
        {
            return this.cadeirasDisponiveis;
        }

        public void RegistrarPartido(PartidoLegislativo partido)
        {
            partidos.Add(partido);
        }

        public float calcularMedia(PartidoLegislativo partido)
        {
            return partido.getQuocienteEleitoral() / (partido.getCadeiras() + 1);
        }

        public void atribuirCadeirasSobrando()
        {
            for (int j = 0; j < cadeirasDisponiveis; j++)
            {
                float sobra = 0;
                int posPartido = -1;
                for (int i = 0; i < partidos.Count; i++)
                {
                    float atual = calcularMedia(partidos[i]);
                    if (atual > sobra)
                    {
                        sobra = atual;
                        posPartido = i;
                    }
                }
                if (posPartido != -1)
                {
                    partidos[posPartido].setVotosRecebidos(partidos[posPartido].getVotosRecebidos() + 1);
                }
            }
        }

        public void calcularQuocientesLegislativo()
        {
            for (int i = 0; i < partidos.Count; i++)
            {
                partidos[i].calcularQuociente(getTotalDeVotos(), cadeirasDisponiveis);
            }
        }

        public void calcularCadeirasLegislativo()
        {
            for (int i = 0; i < partidos.Count; i++)
            {
                partidos[i].calcularCadeiras(partidos[i].getVotosRecebidos(), partidos[i].getQuocienteEleitoral());
            }
        }
    }

    public class RelatorioExecutivo
    {
        private Executivo executivo;

        public RelatorioExecutivo(Executivo _executivo)
        {
            executivo = _executivo;
        }

        public void GerarRelatorio()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "RelatorioExecutivo.txt");

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine($"Relatório Executivo - Turno {executivo.GetType().GetField("turno", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(executivo)}");
                foreach (var candidato in executivo.GetType().GetField("candidatos", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(executivo) as Candidato[])
                {
                    if (candidato != null)
                    {
                        writer.WriteLine($"Nome: {candidato.Nome}, Partido: {candidato.Partido}, Votos: {candidato.Votos}");
                    }
                }
            }
        }
    }
    public class RelatorioLegislativo
    {
        private Legislativo legislativo;

        public RelatorioLegislativo(Legislativo _legislativo)
        {
            legislativo = _legislativo;
        }

        public void GerarRelatorio()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "RelatorioLegislativo.txt");

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Relatório Legislativo");
                foreach (var partido in legislativo.GetType().GetField("partidos", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(legislativo) as List<PartidoLegislativo>)
                {
                    writer.WriteLine($"Partido: {partido.getNome()}, Votos Recebidos: {partido.getVotosRecebidos()}, Cadeiras: {partido.getCadeiras()}");
                }
            }
        }
    }
}
