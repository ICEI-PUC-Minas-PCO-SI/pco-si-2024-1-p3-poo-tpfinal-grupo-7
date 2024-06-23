using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace E_Vote
{
    public static class conferirDados
    {
        public static bool conferirSeNumerico(string entrada)
        {
            bool resposta = true;

            foreach (char c in entrada)
            {
                if (!char.IsDigit(c))
                {
                    return false; // Retorna true se encontrar um não dígito
                }
            }

            return resposta;
        }
    }

}
