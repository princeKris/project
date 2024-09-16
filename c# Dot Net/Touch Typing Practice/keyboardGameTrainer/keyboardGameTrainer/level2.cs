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
    public partial class level2 : UserControl
    {
        public level2()
        {
            InitializeComponent();
        }
        Random random = new Random();
        string mode = "Mode : Intermediate";
        int level = 1;
        int point = 0;
        int inlevel = 1;
        private void level2_Load(object sender, EventArgs e)
        {
            label5.Text = $"Mode:Intermediate-{inlevel}";
            rdnext();
            label3.Text = "";
        }
        private void rdstr(string str)
        {
            Random res = new Random();
            int size = res.Next(1, str.Length + 1);
            String ran = "";
            for (int i = 0; i < size; i++)
            {
                int x = res.Next(0, str.Length);
                ran = ran + str[x];
            }
            label2.Text = ran;
        }
        private void rdnext()
        {
            if (point > (52 * inlevel))
            {
                inlevel += inlevel;
                label5.Text = $"Mode:Easy-{inlevel}";
                point = 0;
            }
            if (point == (0 * inlevel))
            {
                MessageBox.Show("please use only Right & Left  hand pinky finger");

            }
            else if (point == (8 * inlevel))
            {
                MessageBox.Show("please use only Right & Left hand ring finger");
            }
            else if (point == (18 * inlevel))
            {
                MessageBox.Show("please use only Right & Left  hand middle finger");
            }
            else if (point == (28 * inlevel))
            {
                MessageBox.Show("please use only Right & Left  hand Index finger");
            }
            if (point < (8 * inlevel))
            {
                label4.Text = "1";
                level = 1;
            }
            else if (point < (18 * inlevel))
            {
                label4.Text = "2";
                level = 2;
            }
            else if (point < (28* inlevel))
            {
                label4.Text = "3";
                level = 3;
            }
            else if (point < (52 * inlevel))
            {
                label4.Text = "4";
                level = 4;
            }
            switch (level)
            {
                case 1:
                    rdstr("qazp");
                    break;
                case 2:
                    rdstr("wsxol");
                    break;
                case 3:
                    rdstr("edcik");
                    break;
                case 4:
                    rdstr("yhnujmrfvtgb");
                    break;
                
            }
            label3.Text = "";
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void level2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (label2.Text == label3.Text)
                {
                    point += 1;
                    label6.Text = $"Points : {point}";
                    rdnext();
                }
                else
                {
                    MessageBox.Show($"You Have fail the {level} in {mode} pleas try again");
                    rdnext();
                }
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                if (label3.Text.ToString().Length > 0)
                {
                    label3.Text = label3.Text.Substring(0, (label3.Text.ToString().Length - 1));
                }
            }
            else
            {
                char g = e.KeyChar;
                if (!(g < 'a' || g > 'z'))
                {
                    label3.Text += g;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
