using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // a = 2Rsin(a/2)  l = piR/180*alpha    
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Дані не введено!", "Помилка");
            }
            else
            {
                double alpha = double.Parse(textBox1.Text);
                if(alpha>180 || alpha < 0)
                {
                    MessageBox.Show("Кут повинен бути в межах [0;180]", "Помилка");
                    textBox1.Clear();
                    return;
                }
                double radius = double.Parse(textBox2.Text);
                textBox3.Text = string.Format("{0:F3}", 2*radius*Math.Sin((alpha * (Math.PI)) / 360));
                textBox4.Text = string.Format("{0:F3}", (radius * alpha / 180)) + "π";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            else if (!textBox1.Text.Contains(",")&&(!string.IsNullOrEmpty(textBox1.Text) && e.KeyChar == ','))
            {
                return;
            }
            e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            else if (!textBox2.Text.Contains(",")&&(!string.IsNullOrEmpty(textBox2.Text) && e.KeyChar == ','))
            {
                return;
            }
            e.Handled = true;
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show("Right-click is not allowed", "No Right-click");
                return;
            }
        }
    }
}
