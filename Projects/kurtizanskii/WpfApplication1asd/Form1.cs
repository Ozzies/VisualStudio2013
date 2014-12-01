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
        TextBox[] mass = new TextBox[100];
        int z1 = 140;
        int z2 = 40;
        public Form1()
        {
            InitializeComponent();
            label1.Hide();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            for (int i = 1; i <= (int.Parse(textBox0.Text)) * 5; i++)
            {
                mass[i] = new TextBox
                {
                    Location = new Point(z1, z2),
                    Name = "tt" + i,
                    Size = new Size(30, 20)
                };
                z1 += 40;
                if (i % int.Parse(textBox0.Text)== 0) { z2 += 30; z1 = 140; }
            }
            this.Controls.AddRange(mass);
            this.PerformLayout();
            button1.Hide();
            textBox0.Hide();
            
            label1.Text = "222";
            label1.Show();
        }


    }
}
