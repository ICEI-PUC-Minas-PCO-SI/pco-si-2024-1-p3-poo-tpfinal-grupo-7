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
                string senhaCadastrada = usuariosCadastrados[i].getSenha();
                if (cpfCadastrado == cpfInformado)
                {
                    permitirLogin = true;
                    break;
                }
            }
            return permitirLogin;
        }
    }

}
