using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string origMessage = normalText.Text;
            int shiftNum = Int32.Parse(textBox3.Text);

            cypherText.Text = doEncryption(origMessage.ToLower(), shiftNum);
        }

        private static string doEncryption(string words, int shiftNo)
        {
            shiftNo %= 26;
            char[] buffer = words.ToCharArray();

            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];

                letter = (char)(letter + shiftNo);

                if (letter > 'z')
                {
                    letter = (char)(letter - 26);
                }
                else if (letter < 'a')
                {
                    letter = (char)(letter + 26);
                }
                buffer[i] = letter;
            }
            return new string(buffer);
            }
        static string Decrypt(string words, int shiftNo)
        {
            return doEncryption(words, 26 - shiftNo);
        }
    }
}
