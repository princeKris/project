using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace scretecalculator
{
    public partial class Calculator : Form
    {
      
        string calin;
        public Calculator()
        {
            InitializeComponent();
   
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            calin += "1";
            textBox1.Text +=calin;
   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            calin += "2";
            textBox1.Text += calin;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            calin += "3";
            textBox1.Text += calin;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            calin += "4";
            textBox1.Text += calin;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            calin += "5";
            textBox1.Text += calin;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            calin += "6";
            textBox1.Text += calin;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            calin += "7";
            textBox1.Text += calin;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            calin += "8";
            textBox1.Text += calin;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            calin += "9";
            textBox1.Text += calin;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            calin += "0";
            textBox1.Text += calin;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            calin = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            calin += "+";
            textBox1.Text += calin;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            calin += "-";
            textBox1.Text += calin;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            calin += "*";
            textBox1.Text += calin;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = calin;
            textBox1.Text = "";
            calin += "/";
            textBox1.Text += calin;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            calin += "(";
            textBox1.Text += calin;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            calin += ")";
            textBox1.Text += calin;
        }

     

  
        private void button27_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            if (calin.Length > 0)
            {
                calin = calin.Remove(calin.Length - 1);
                textBox1.Text += calin;
            }
            

        }

        public static int evaluate(string expression)
            {
                char[] tokens = expression.ToCharArray();
                Stack<int> values = new Stack<int>();
                Stack<char> ops = new Stack<char>();

                for (int i = 0; i < tokens.Length; i++)
                {
                    if (tokens[i] == ' ')
                    {
                        continue;
                    }
                    if (tokens[i] >= '0' && tokens[i] <= '9')
                    {
                        StringBuilder sbuf = new StringBuilder();
                        while (i < tokens.Length &&
                                tokens[i] >= '0' &&
                                    tokens[i] <= '9')
                        {
                            sbuf.Append(tokens[i++]);
                        }
                        values.Push(int.Parse(sbuf.ToString()));
                        i--;
                    }
                    else if (tokens[i] == '(')
                    {
                        ops.Push(tokens[i]);
                    }
                    else if (tokens[i] == ')')
                    {
                        while (ops.Peek() != '(')
                        {
                            values.Push(applyOp(ops.Pop(),
                                             values.Pop(),
                                            values.Pop()));
                        }
                        ops.Pop();
                    }

                    else if (tokens[i] == '+' ||
                             tokens[i] == '-' ||
                             tokens[i] == '*' ||
                             tokens[i] == '/')
                    {

                        while (ops.Count > 0 &&
                                 hasPrecedence(tokens[i],
                                             ops.Peek()))
                        {
                            values.Push(applyOp(ops.Pop(),
                                             values.Pop(),
                                           values.Pop()));
                        }
                        ops.Push(tokens[i]);
                    }
                }
                while (ops.Count > 0)
                {
                    values.Push(applyOp(ops.Pop(),
                                     values.Pop(),
                                    values.Pop()));
                }
                return values.Pop();
            }
            public static bool hasPrecedence(char op1,
                                             char op2)
            {
                if (op2 == '(' || op2 == ')')
                {
                    return false;
                }
                if ((op1 == '*' || op1 == '/') &&
                       (op2 == '+' || op2 == '-'))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            public static int applyOp(char op,
                                    int b, int a)
            {
                switch (op)
                {
                    case '+':
                        return a + b;
                    case '-':
                        return a - b;
                    case '*':
                        return a * b;
                    case '/':
                            if (b == 0)
                            {
                                throw new
                                System.NotSupportedException(
                                       "Cannot divide by zero");
                            }
                        return a / b;
                }
                return 0;
            }
          

        private void button17_Click(object sender, EventArgs e)
        {
            if(calin == "1+2+3")
            {
                string Path = "C:\\imagelocker\\";
                bool exists = Directory.Exists(Path);
                bool exists1 = Directory.Exists("C:\\imagelocker\\decry");
                bool exists2 = Directory.Exists("C:\\imagelocker\\encry");
                if (!exists)
                {
                    Directory.CreateDirectory(Path);
                    Directory.CreateDirectory("C:\\imagelocker\\decry");
                    Directory.CreateDirectory("C:\\imagelocker\\encry");
                }
                else
                {
                    if(!exists1)
                        Directory.CreateDirectory("C:\\imagelocker\\decry");
                    if (!exists2)
                        Directory.CreateDirectory("C:\\imagelocker\\encry");
                }
                    
                this.Hide();
                var form2 = new imagelocker();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
            else
            {
                try
                {
                    calin = evaluate(calin).ToString();
                    textBox1.Text = calin;
                }catch(Exception ex)
                {
                    textBox1.Text = ex.Message.ToString();
                }

            }
            
        }
    }
}
