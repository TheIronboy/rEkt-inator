﻿using System;
using System.Windows.Forms;

namespace rEkt_inator
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string input = "", output = "";
        int times = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                input = textBox1.Text;

                if (checkBox1.Checked == true && checkBox2.Checked == true)
                {
                    output = toMaiuscolo(toNumeri(input));
                    listBox1.Items.Clear();
                }
                else if (checkBox1.Checked == true && checkBox2.Checked == false)
                {
                    output = toMaiuscolo(input);
                    listBox1.Items.Clear();
                }
                else if (checkBox1.Checked == false && checkBox2.Checked == true)
                {
                    output = toNumeri(input);
                    listBox1.Items.Clear();
                }
                else
                {
                    output = input;
                    listBox1.Items.Clear();
                }
                
                listBox1.Items.Add("Frase generata: " + output);
            }
            else
                MessageBox.Show("Inserisci la frase.");
        }

        private string toMaiuscolo(string input)
        {
            string fraseMaiuscolo = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 0)
                    fraseMaiuscolo += input[i].ToString().ToUpper();
                else
                    fraseMaiuscolo += input[i].ToString().ToLower();
            }

            return fraseMaiuscolo;
        }
        private string toNumeri(string input)
        {
            string fraseNumero = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].ToString().ToLower() == "a")
                    fraseNumero += '4';
                else if (input[i].ToString().ToLower() == "e")
                    fraseNumero += '3';
                else if (input[i].ToString().ToLower() == "i")
                    fraseNumero += '1';
                else if (input[i].ToString().ToLower() == "o")
                    fraseNumero += '0';
                else
                    fraseNumero += input[i];
            }

            return fraseNumero;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (output != "")
            {
                if (textBox2.Text != "")
                {
                    times = Convert.ToInt32(textBox2.Text);

                    MessageBox.Show("5 secondi dopo il tuo OK spammerò (" + output + ") per (" + times + ") volte.");
                    System.Threading.Thread.Sleep(5000);

                    listBox1.Items.Add("START.");

                    for (int i = 1; i <= times; i++)
                    {
                        SendKeys.Send(output);
                        SendKeys.Send("{Enter}");
                        listBox1.Items.Add(i);
                    }

                    listBox1.Items.Add("END.");
                    listBox1.Items.Add("by TheIronboy_YT ;)");

                    output = "";
                }
                else
                    MessageBox.Show("Inserisci un numero di volte.");
            }
            else
                MessageBox.Show("Frase non generata.");
        }
    }
}
