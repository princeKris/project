using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace keyboardGameTrainer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void adducontro(UserControl userControl)
        {
            userControl.Dock= DockStyle.Fill;
            panel4.Controls.Clear();
            panel4.Controls.Add(userControl);
            this.ActiveControl = userControl;
            userControl.BringToFront();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            adducontro(new home());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            adducontro(new level1());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adducontro(new level2());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adducontro(new level3());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            adducontro(new home());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            adducontro(new rules());
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            adducontro(new rules());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            adducontro(new tips());
        }
    }
}
