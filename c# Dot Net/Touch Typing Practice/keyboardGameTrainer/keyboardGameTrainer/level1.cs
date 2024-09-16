using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace keyboardGameTrainer
{
    public partial class level1 : UserControl
    {
        public level1()
        {
            InitializeComponent();
        }
        Random random = new Random();
        string mode = "Mode : Easy";
        int level = 1;
        int point = 0;
        int inlevel = 1;
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        //stopwatch.Start();
        //stopwatch.Stop();
        private void level1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void level1_Load(object sender, EventArgs e)
        {

            label5.Text = $"Mode : Easy-{inlevel}";
            rdnext();
            label3.Text = "";
        }
        private void rdstr(string str)
        {
            Random res = new Random();
            int size = res.Next(1,str.Length+1);
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
            if (point > (45*inlevel))
            {
                inlevel+= inlevel;
                label5.Text = $"Mode : Easy-{inlevel}";
                point = 0;
            }
            if(point == 0*inlevel)
            {
                MessageBox.Show("please use only Right hand pinky finger");

            }
            else if(point == (1*inlevel)) {
                
                MessageBox.Show("please use only Right hand ring finger");
            }else if (point == (5*inlevel))
            {
                MessageBox.Show("please use only Right hand middle finger");
            }else if(point == (9*inlevel))
            {
                MessageBox.Show("please use only Left hand pinky finger");
            }else if (point == (15 * inlevel))
            {
                MessageBox.Show("please use only Left hand ring finger");
            }else if(point ==( 20 * inlevel))
            {
                MessageBox.Show("please use only Left hand middle finger");
            }else if(point == (25 * inlevel))
            {
                MessageBox.Show("please use only Left hand index finger");
            }else if(point == (35 * inlevel))
            {
                MessageBox.Show("please use only right hand index finger");
            }
            if (point < (1*inlevel))
            {
                label4.Text = "1";
                level = 1;
            }else if (point < (5 * inlevel))
            {
                label4.Text = "2";
                level = 2;
            }
            else if (point < (9 * inlevel))
            {
                label4.Text = "3";
                level = 3;
            }
            else if (point < (15 * inlevel))
            {
                label4.Text = "4";
                level = 4;
            }
            else if (point < (20 * inlevel))
            {
                label4.Text = "5";
                level = 5;
            }
            else if (point < (25 * inlevel))
            {
                label4.Text = "6";
                level = 6;
            }
            else if (point < (35 * inlevel))
            {
                label4.Text = "7";
                level = 7;
            }
            else if (point < (45 * inlevel))
            {
                label4.Text = "8";
                level = 8;
            }
            switch (level)
            {
                case 1:
                    rdstr("p");
                    break;
                case 2:
                    rdstr("ol");
                    break;
                case 3:
                    rdstr("ik");
                    break;
                case 4:
                    rdstr("qaz");
                    break;
                case 5:
                    rdstr("wsx");
                    break;
                case 6:
                    rdstr("edc");
                    break;
                case 7:
                    rdstr("rfvtgb");
                    break;
                case 8:
                    rdstr("yhnujm");
                    break;
            }
            label3.Text = "";
        }

        private void level1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
