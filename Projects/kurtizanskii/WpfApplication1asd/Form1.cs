using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WpfApplication1asd
{
    public partial class Form1 : Form
    {
        TextBox[] kurtka = new TextBox[100];
        int z1 = 40;
        int z2 = 40;
        public Form1()
        {
            InitializeComponent();
             
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            for (int i = 1; i <= (int.Parse(textBox2.Text)) * 5-5; i++)
            {
                kurtka[i] = new TextBox();
                kurtka[i].Location = new System.Drawing.Point(z1, z2);
                kurtka[i].Name = "kurtka" + i.ToString();
                kurtka[i].Size = new System.Drawing.Size(100, 20);
                
                z1 += 110;
                if (i % 5 == 0) { z2 += 30; z1 = 40; }
            }
            this.Controls.AddRange(kurtka);
            this.PerformLayout();
            kurtka[1].Text = "asdasd";
            button1.Hide();
            textBox2.Hide();
        }


    }
}
