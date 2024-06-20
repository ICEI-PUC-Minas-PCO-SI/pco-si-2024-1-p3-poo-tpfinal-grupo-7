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

    public class PartidoJudiciario : Partido
    {
        private int quocienteEleitoral;
        private int cadeiras;

        public PartidoJudiciario(string _nome) : base(_nome)
        {

        }

        public void calcularCadeiras(int votosRecebidos, double quocienteEleitoral)
        {
            this.cadeiras = (int) (votosRecebidos / quocienteEleitoral);
        }

        public int getCadeiras()
        {
            return this.cadeiras;
        }

        public void calcularQuociente(int totalDeVotos,int cadeirasDisponiveis)
        {
            this.quocienteEleitoral = totalDeVotos / cadeirasDisponiveis;
        }

        public int getQuocienteEleitoral()
        {
            return this.quocienteEleitoral;
        }
    }

    public class Usuario{ // Mudar pras do pedro depois q ele commitar

       int cpf;

       string nome;

       string senha;

       bool adm = false;

       public int getCpf(){ 
        return this.cpf;
       }

       public void setCpf(int _cpf){
         this.cpf = _cpf;
       }

        public string getNome(){
        return this.nome;
       }

       public void setNome(string _nome){
         this.nome = _nome;
       }

        public string getSenha(){
        return this.senha;
       }

       public void setSenha(string _senha){
         this.senha = _senha;
       }

    

       public Usuario(int cpf_, string senha_, string nome_)
        {
            cpf=cpf_;
            senha=senha_;
            nome=nome_;
        }



    }

    public class Administrador{ //Mudar pras do pedro depois q ele commitar

       int cpf;

       string nome;

       string senha;

       bool adm = true;

       
       public int getCpf(){ 
        return this.cpf;
       }

       public void setCpf(int _cpf){
         this.cpf = _cpf;
       }

        public string getNome(){
        return this.nome;
       }

       public void setNome(string _nome){
         this.nome = _nome;
       }

        public string getSenha(){
        return this.senha;
       }

       public void setSenha(string _senha){
         this.senha = _senha;
       }
    

       public Administrador(int cpf_, string senha_, string nome_)
        {
            cpf=cpf_;
            senha=senha_;
            nome=nome_;
           
        }

        public void criarPartido(){


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

 public class Candidato //Mudar pras do pedro depois q ele commitar
    {
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public int Votos { get; set; }
        public int Idade { get; set; }
        public Partido Partido { get; set; }

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


if (candidato1.Idade > candidato2.Idade)
            {
              Console.WriteLine($"{candidato1.Nome} ganhou a eleição!");
               
            } else {

Console.WriteLine($"{candidato2.Nome} ganhou a eleição!");

    }
    
}
}}