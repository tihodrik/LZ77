using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LZ77
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string compressed = comp.Text;
            decomp.Clear();
            string[] fragments = compressed.Split('(', ')');
            // После операции split во fragments получим массив строк,
            // где под четными индексами - фрагменты текста,
            // а под нечетными - описание повторов в формате "a,b"
            int a, b;
            string[] ab;
            for (int i = 0; i < fragments.Length; i++)
            {
                if (i % 2 == 0)
                {
                    decomp.AppendText(fragments[i]);
                }
                else
                {
                    ab = fragments[i].Split(',');
                    a = int.Parse(ab[0]);
                    b = int.Parse(ab[1]);
                    decomp.AppendText(GetRepeated(decomp.Text, a, b));
                }
            }
        }
        string GetRepeated(string range, int offset, int count) {
            if (count > offset*(-1)) {
                throw new ArgumentOutOfRangeException("Неверно задан повтор");
            }
            return  range.Substring(range.Length + offset, count);
        }
    }
}
