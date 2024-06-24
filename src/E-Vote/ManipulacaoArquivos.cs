using Eleicoes;
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
                // string senhaCadastrada = usuariosCadastrados[i].getSenha();
                if (cpfCadastrado == cpfInformado)
                {
                    permitirLogin = true;
                    break;
                }
            }
            return permitirLogin;
        }
    }

    public class gravadorEleicoes
    {
        public string caminhoDoArquivo;

        public gravadorEleicoes()
        {
            this.caminhoDoArquivo = Directory.GetCurrentDirectory() + "/eleicoes.txt";
        }

        public void criarEleicaoExecutivo(int codigoEleicao)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(this.caminhoDoArquivo, true))
                {
                    sw.WriteLine($";0;{codigoEleicao}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar eleição: {ex.Message}");
            }
        }

        public void salvarEleicaoExecutivo(int codigoCandidato, int codigoEleicao)
        {
            bool eleicaoEncontrada = false;

            try
            {
                if (File.Exists(this.caminhoDoArquivo))
                {
                    string[] lines = File.ReadAllLines(this.caminhoDoArquivo);

                    for (int index = 0; index < lines.Length; index++)
                    {
                        string line = lines[index];

                        string[] partes = line.Split(';');
                        if (partes.Length > 2 && int.TryParse(partes[2], out int codEleicaoLinha) && codEleicaoLinha == codigoEleicao)
                        {
                            eleicaoEncontrada = true;

                            string[] candidatosPartes = partes[0].Split(',');
                            Dictionary<int, int> candidatos = new Dictionary<int, int>();
                            for (int i = 0; i < candidatosPartes.Length; i++)
                            {
                                string[] candidatoInfo = candidatosPartes[i].Split(':');
                                if (candidatoInfo.Length == 2)
                                {
                                    int codigo = int.Parse(candidatoInfo[0]);
                                    int votos = int.Parse(candidatoInfo[1]);
                                    candidatos[codigo] = votos;
                                }
                            }

                            if (candidatos.ContainsKey(codigoCandidato))
                            {
                                candidatos[codigoCandidato]++;
                            }
                            else
                            {
                                candidatos[codigoCandidato] = 1;
                            }

                            int totalVotos = int.Parse(partes[1]) + 1;

                            string candidatosStr = string.Join(",", candidatos.Select(c => $"{c.Key}:{c.Value}"));
                            string novaLinha = $"{candidatosStr};{totalVotos};{codigoEleicao}";

                            lines[index] = novaLinha;
                            break;
                        }
                    }

                    using (StreamWriter sw = new StreamWriter(this.caminhoDoArquivo, false))
                    {
                        foreach (var linha in lines)
                        {
                            sw.WriteLine(linha);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Arquivo eleicoes.txt não encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar eleição: {ex.Message}");
            }
        }

        public void salvarEleicaoLegislativo(int codigoPartido, int codigoEleicao)
        {
            bool eleicaoEncontrada = false;

            try
            {
                if (File.Exists(this.caminhoDoArquivo))
                {
                    string[] lines = File.ReadAllLines(this.caminhoDoArquivo);

                    for (int index = 0; index < lines.Length; index++)
                    {
                        string line = lines[index];

                        string[] partes = line.Split(';');
                        if (partes.Length > 2 && int.TryParse(partes[2], out int codEleicaoLinha) && codEleicaoLinha == codigoEleicao)
                        {
                            eleicaoEncontrada = true;

                            string[] partidosPartes = partes[0].Split(',');
                            Dictionary<int, int> partidos = new Dictionary<int, int>();
                            for (int i = 0; i < partidosPartes.Length; i++)
                            {
                                string[] partidoInfo = partidosPartes[i].Split(':');
                                if (partidoInfo.Length == 2)
                                {
                                    int codigoPart = int.Parse(partidoInfo[0]);
                                    int votos = int.Parse(partidoInfo[1]);
                                    partidos[codigoPart] = votos;
                                }
                            }

                            if (partidos.ContainsKey(codigoPartido))
                            {
                                partidos[codigoPartido]++;
                            }
                            else
                            {
                                partidos[codigoPartido] = 1;
                            }

                            int totalVotos = int.Parse(partes[1]) + 1;

                            string partidosStr = string.Join(",", partidos.Select(p => $"{p.Key}:{p.Value}"));
                            string novaLinha = $"{partidosStr};{totalVotos};{codigoEleicao}";

                            lines[index] = novaLinha;
                            break;
                        }
                    }

                    using (StreamWriter sw = new StreamWriter(this.caminhoDoArquivo, false))
                    {
                        foreach (var linha in lines)
                        {
                            sw.WriteLine(linha);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Arquivo eleicoes.txt não encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar eleição legislativa: {ex.Message}");
            }
        }
    }

    public class leitorEleicao
    {
        public string caminhoDoArquivo;

        public leitorEleicao()
        {
            this.caminhoDoArquivo = Directory.GetCurrentDirectory() + "/eleicoes.txt";
        }

        public string LerConteudoDoArquivo()
        {
            try
            {
                if (File.Exists(this.caminhoDoArquivo))
                {
                    string conteudo = File.ReadAllText(this.caminhoDoArquivo);
                    return conteudo;
                }
                else
                {
                    Console.WriteLine("Arquivo eleicoes.txt não encontrado.");
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler arquivo: {ex.Message}");
                return string.Empty;
            }
        }

    }

}
