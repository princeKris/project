using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace scretecalculator
{
    public partial class locker : Form
    {

        public locker()
        {
            InitializeComponent();

        }

        private void Encrypt(string inputFilePath, string outputfilePath, string EncryptionKey)
        {
            try
            {
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (FileStream fsOutput = new FileStream(outputfilePath, FileMode.Create))
                    {
                        using (CryptoStream cs = new CryptoStream(fsOutput, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
                            {
                                int data;
                                while ((data = fsInput.ReadByte()) != -1)
                                {
                                    cs.WriteByte((byte)data);
                                }
                            }
                        }
                    }
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message); }  
            
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "C:\\imagelocker\\encry";
                OpenFileDialog openFD = new OpenFileDialog();
                openFD.Multiselect = true;
                openFD.Title = "Select The Files";
                var result = MessageBox.Show("Do You Want To Delete Original Files", "Info Box", MessageBoxButtons.YesNo);
                
                if (openFD.ShowDialog() == DialogResult.OK)
                {
                    foreach (String file in openFD.FileNames)
                    {
                        string inpf = file.ToString();
                        string[] fi = inpf.Split('\\');
                        string oupf = $"{textBox2.Text}\\{fi[fi.Length - 1]}";
                        string password = textBox1.Text.ToString();
                        if (File.Exists(oupf))
                        {
                            MessageBox.Show($"{fi[fi.Length - 1]} this file is already exists in locker if you want to lock this file please rename the file and try to locker in the file");
                            continue;
                        }
                        else
                        {
                            Encrypt(inpf, oupf, password);
                            if ((result == DialogResult.Yes))
                            {
                                File.Delete(inpf);
                            }

                        }
                       
                    }
                }
                MessageBox.Show("Files Sucessfully Encrypted");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            var form2 = new imagelocker();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox2.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }
    }
}
