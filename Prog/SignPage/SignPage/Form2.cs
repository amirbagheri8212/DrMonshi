using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void CheckLicense(string Name, string LastName, string Email, string License)
        {
            HashAlgorithm algorithm = MD5.Create();  //or use SHA256.Create();
            byte[] HashName = algorithm.ComputeHash(Encoding.UTF8.GetBytes(Name));
            byte[] HashLastName = algorithm.ComputeHash(Encoding.UTF8.GetBytes(LastName));
            byte[] HashEmail = algorithm.ComputeHash(Encoding.UTF8.GetBytes(Email));
            string HashedEmail = BitConverter.ToString(HashEmail);
            string HashedName = BitConverter.ToString(HashName);
            string HashedLastName = BitConverter.ToString(HashLastName);
            string kham = HashedName + "I'm A Hacker" + HashEmail + "if You Want To Crack This App" + HashLastName + "I Will Kill You!!";
            HashAlgorithm asha256 = SHA256.Create();
            byte[] HashLice = algorithm.ComputeHash(Encoding.UTF8.GetBytes(kham));
            if (License == BitConverter.ToString(HashLice))
            {
                MessageBox.Show("The License Activated Successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid License");
            }
        }
        private void LicenseCreate(string Name, string LastName, string Email)
        {
            HashAlgorithm algorithm = MD5.Create();  //or use SHA256.Create();
            byte[] HashName = algorithm.ComputeHash(Encoding.UTF8.GetBytes(Name));
            byte[] HashLastName = algorithm.ComputeHash(Encoding.UTF8.GetBytes(LastName));
            byte[] HashEmail = algorithm.ComputeHash(Encoding.UTF8.GetBytes(Email));
            string HashedEmail = BitConverter.ToString(HashEmail);
            string HashedName = BitConverter.ToString(HashName);
            string HashedLastName = BitConverter.ToString(HashLastName);
            string kham = HashedName + "I'm A Hacker" + HashEmail + "if You Want To Crack This App" + HashLastName + "I Will Kill You!!";
            HashAlgorithm asha256 = SHA256.Create();
            byte[] HashLice = algorithm.ComputeHash(Encoding.UTF8.GetBytes(kham));
            MessageBox.Show(BitConverter.ToString(HashLice));
            textBox3.Text = BitConverter.ToString(HashLice);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox2.Text != "")
                {
                    if (textBox3.Text != "")
                    {
                        if (textBox4.Text != "")
                        {
                            CheckLicense(textBox1.Text, textBox2.Text, textBox4.Text, textBox3.Text);
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Email");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter License Key");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Last Name");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Name");
            }
            //LicenseCreate("Shiva","Hadadianpour","shivahadadian@yahoo.com");

        }
    }
}
