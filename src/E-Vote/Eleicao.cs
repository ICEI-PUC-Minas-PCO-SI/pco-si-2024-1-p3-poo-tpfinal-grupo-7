using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Vote
{
    public partial class Eleicao : Form
    {
        public Eleicao(string cpf)
        {
            InitializeComponent();

            label3.Text = formatarCPF(cpf);
            formatarListView(listView1);
        }

        public string formatarCPF(string _cpf)
        {
            string _cpfFormatado = "CPF: ";

            for (int i = 0; i < _cpf.Length; i++)
            {
                if (i == 3 || i == 6)
                {
                    _cpfFormatado += ".";
                }
                else if (i == 9)
                {
                    _cpfFormatado += "-";
                }

                _cpfFormatado += _cpf[i];
            }

            return _cpfFormatado;
        }

        public void formatarListView(ListView listViewEleicoes)
        {
            listViewEleicoes.Clear();
            listViewEleicoes.View = View.Details;
            listViewEleicoes.FullRowSelect = true;
            listViewEleicoes.Columns.Add("Id", 100);
            listViewEleicoes.Columns.Add("Tipo", 100);
        }
    }
}
