using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegatesGUI
{
    public partial class Form1 : Form
    {
        static string text;
        delegate void Modify();
        Modify op1;
        Modify op2;
        Modify op3;

        public Form1()
        {
            text = "";
            InitializeComponent();
            op1 = MultipleSpaces;
            op2 = RemoveSpacesBeforePuncts;
            op3 = InsertSpacesAfterPuncts;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modify res = new Modify(Start);
            text = textBox1.Text;
            if (checkBox1.Checked)
                res += op1;
            if (checkBox2.Checked)
                res += op2;
            if (checkBox3.Checked)
                res += op3;


            res();
            textBox1.Text = text;

        }

        // Организуем ряд методов
        static void MultipleSpaces()
        {
            text = text.Trim();
            while (text.IndexOf("  ") >= 0)
            {
                 text = text.Replace("  ", " ");
            }
        }

        static void RemoveSpacesBeforePuncts()
        {
            text = text.Trim();
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsPunctuation(text[i]) == true && text[i - 1] == ' ')
                    text = text.Remove(i - 1, 1);
            }
        }

        static void InsertSpacesAfterPuncts()
        {
            text = text.Trim();
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsPunctuation(text[i]) == true && text[i + 1] != ' ')
                    text = text.Insert(i + 1, " ");
               
            }
            int a = 0;
        }
        static void Start()
        {
        }
    }
}
