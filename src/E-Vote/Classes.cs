using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

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

    public class Usuario:Conta{ // ver com o pedro depois

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

    public class Administrador:Conta{

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
    

       public Administrador(int cpf_)
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
        abstract private int totalDeVotos;

        
    }

        public class Executivo : Eleicao{

        //Candidato []candidato = new Candidato[0]; //fazer a função ainda

        private int turno {get; set;} 

          
    public int TotalVotos(int votos){

return votos;
    }

    public  int primeiroturno(int votos){

return votos;
    }

     public  int segundoturno(int votos){

return votos;
    }

    public  int desempate(int votos){

return votos;
    }
}

    
}
