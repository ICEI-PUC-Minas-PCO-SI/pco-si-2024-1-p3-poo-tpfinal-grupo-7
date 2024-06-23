using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Classes
{
    public class Partido
    {
        private string nome;
        private int votosRecebidos;

        public int Codigo;

          public int getCodigo()
        {
            return this.cpf;
        }

        public void setCodigo(int _codigo)
        {
            this.Codigo = _codigo;
        }

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
        public abstract int cpf; { get; set; }
   

         public Conta(int cpf_) 
        {
            cpf = cpf_;
        }
    }



    public class Usuario: Conta
    { 


        public int cpf;


        bool adm = false;

        public int getCpf()
        {
            return this.cpf;
        }

        public void setCpf(int _cpf)
        {
            this.cpf = _cpf;
        }




        public Usuario(int cpf_)
        {
            cpf = cpf_;
           
            nome = nome_;
            nome = nome_;
        }



    }

    public class Administrador:Conta
    { 

        public int cpf;



        bool adm = true;


        public int getCpf()
        {
            return this.cpf;
        }

        public void setCpf(int _cpf)
        {
            this.cpf = _cpf;
        }



        public Administrador(int cpf_)
        {
            cpf = cpf_;
          

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
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public int Votos { get; set; }
        public int Idade { get; set; }
        public Candidato(string nome, int codigo, string partido, int idade, int votos)
        public Candidato(string nome, int codigo, Partido partido, int idade, int votos)
        public Candidato(string nome, int codigo, Partido partido, int idade, int votos)
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
            bool empate = false;
            int maxVotos = -1;
            Candidato vencedor = null;

            turno = 1;

            for (int i = 0; i < candidatos.Length; i++)
            {
                if (candidatos[i].Votos > maxVotos)
                {
                    maxVotos = candidatos[i].Votos;
                    vencedor = candidatos[i];
                }
                else if (candidatos[i].Votos == maxVotos)
                {
                    empate = true;
                }
            }
            //Define os votos do candidato como maxVotos, se tiver outro candidato com a mesma quantidade de votos(maxVotos) define empate como true, vai pro empate e chama o segundo turno

            if (empate)
            {

                segundoturno();
            }
            else if (vencedor != null)
            {
                Console.WriteLine($"Vencedor do primeiro turno: {vencedor.Nome}");
            }


        }

        public void RegistrarCandidato(Candidato candidato, int index) //mudar isso aq
        {
            candidatos[index] = candidato;
        }


        public void segundoturno()
        {

            turno = 2;

            var topTwo = candidatos.Where(c => c != null).OrderByDescending(c => c.Votos).Take(2).ToArray();


            Candidato candidato1 = topTwo[0];
            Candidato candidato2 = topTwo[1];

            turno = 2;

            Console.WriteLine("A votação deu empate, iremos para o segundo turno!");

            Console.WriteLine($"Coloque os votos referentes ao {candidato1.Nome}!");
            int votosCandidato1 = int.Parse(Console.ReadLine());


            Console.WriteLine($"Coloque os votos referentes ao {candidato2.Nome}!");
            int votosCandidato2 = int.Parse(Console.ReadLine());
            //Define os candidatos com mais votos pelo "OrderByDescending" e declara eles em variáveis, depois define a quantidade de votos pros 2 e verifica se alguém ganhou a eleição ou se vai pro desempate

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
                desempate(candidato1, candidato2);
            }

        }
        public void desempate(Candidato candidato1, Candidato candidato2)
        {

            //No desempate verifica qual é mais velho e define como vencedor
            if (candidato1.Idade > candidato2.Idade)
            {
                Console.WriteLine($"{candidato1.Nome} ganhou a eleição!");

            }
            else
            {

                Console.WriteLine($"{candidato2.Nome} ganhou a eleição!");

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
            public void calcularMedia(PartidoLegislativo partido)

                return partido.getQuocienteEleitoral / (partido.getCadeiras + 1);
            {
                return 1; //partido.getQuocienteEleitoral / (partido.getCadeiras + 1);
            }

            public void atribuirCadeirasSobrando()
            {
                for (int j = 0; j < cadeirasDisponiveis; j++)
                {
                    int sobra = 0;
                    int posPartido = -1;
                    for (int i = 0; i < partidos.Count; i++)
                    {
                        int atual = calcularMedia(partidos[i]);
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

            public void calcularQuocientes()
            {
                for (int i = 0; i < partidos.Count; i++)
                {
                    partidos[i].calcularQuociente(getTotalDeVotos(), cadeirasDisponiveis);
                }
            }

            public void calcularCadeiras()
            {
                for (int i = 0; i < partidos.Count; i++)
                {
                    partidos[i].calcularCadeiras(partidos[i].getVotosRecebidos(), partidos[i].getQuocienteEleitoral());
                }
            }
        }
    }

}
