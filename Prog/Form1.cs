
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finisar.SQLite;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.IO;
namespace Prog
{

    public partial class Form1 : Form
    {
        private string BagherHash(string text, int m)
        {
            string hashed = "";
            byte[] asciiBytes = Encoding.ASCII.GetBytes(text);
            foreach (char asciicode in asciiBytes)
            {
                char chare = Convert.ToChar(asciicode+m);
                hashed += chare;
            }
            return hashed;
            //BitConverter.ToString("");
        }
        public Form1()
        {
            InitializeComponent();
        }
        private string DLSP(string V, bool NS)
        {
            int tmp = -1;
            if (V != "")
            {
                string Name_temp = "";
                
                bool Name_temp_spaces = false;
                foreach (char chr in V)
                {
                    tmp += 1;
                    if (Name_temp == "")
                    {
                        if (chr != ' ')
                        {
                            Name_temp += chr;
                        }
                    }
                    else
                    {
                        if (chr == ' ' && !Name_temp_spaces)
                        {
                            Name_temp_spaces = true;
                            if (NS)
                            {
                                Name_temp += chr;
                            }
                            
                        }
                        if (chr != ' ')
                        {
                            Name_temp_spaces = false;
                            if (chr == 'ا')
                            {
                                Name_temp_spaces = true;
                            }
                            Name_temp += chr;
                        }
                    }
                }
                Name_temp = Name_temp.TrimEnd();
                return Name_temp;
            }

            return "";
        }
        
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (NameTB.Text != "")
            {
                NameTB.Text = DLSP(NameTB.Text, true);
                if (LastName.Text != "")
                {
                    LastName.Text = DLSP(LastName.Text, true);
                    int value;
                    if (int.TryParse(Age.Text, out value))
                    {
                        if (Convert.ToInt16(Age.Text) <= 110)
                        {
                            if (LastName.Text != "")
                            {
                                long valsue1;
                                //MessageBox.Show(PhoneNumber.Text);
                                if (long.TryParse(PhoneNumber.Text, out valsue1))
                                {
                                    long valsue2;
                                    if (long.TryParse(TPhoneNumber.Text, out valsue2))
                                    {
                                        int valsue3;
                                        if (int.TryParse(CreationYear.Text, out valsue3))
                                        {
                                            int valsue4;
                                            int CYear;
                                            CYear = Convert.ToInt32(CreationYear.Text);
                                            if (int.TryParse(CreationMonth.Text, out valsue4))
                                            {
                                                int valsue5;
                                                int CMonth;
                                                CMonth = Convert.ToInt16(CreationMonth.Text);
                                                if (int.TryParse(CreationDay.Text, out valsue5))
                                                {
                                                    long valsue6;
                                                    int CDay;
                                                    CDay = Convert.ToInt16(CreationDay.Text);
                                                    if (long.TryParse(ID.Text, out valsue6))
                                                    {
                                                        if (ProfileCode.Text != "")
                                                        {
                                                            if (ProfileNO.Text != "")
                                                            {
                                                                if (ID.Text != "")
                                                                {
                                                                    long valsue7;
                                                                    if (long.TryParse(ID.Text, out valsue7))
                                                                    {
                                                                        string ProfileID;
                                                                        ProfileID = "" + ProfileCode.Text + "|" + ProfileNO.Text;
                                                                        string DateOfCreation;
                                                                        DateOfCreation = CYear + "/" + CMonth + "/" + CDay;
                                                                        SQLiteConnection sqlite_conn;
                                                                        SQLiteCommand sqlite_cmd;
                                                                        sqlite_conn = new SQLiteConnection("Data Source=data.db;Version=3;New=False;Compress=True;");
                                                                        sqlite_conn.Open();
                                                                        sqlite_cmd = sqlite_conn.CreateCommand();
                                                                        if (isPregnant.Checked)
                                                                        {

                                                                            sqlite_cmd.CommandText = "SELECT ProfileID FROM Pregnant WHERE ProfileID='" + ProfileID + "'";
                                                                            int count = Convert.ToInt32(sqlite_cmd.ExecuteScalar());
                                                                            if (count == 0)
                                                                            {
                                                                                
                                                                                sqlite_cmd.CommandText = "insert into Pregnant values('" + NameTB.Text + "','" + LastName.Text + "','" + Convert.ToInt32(Age.Text) + "','" + ProfileID + "','" + Convert.ToInt64(ID.Text) + "','" + Convert.ToInt64(PhoneNumber.Text) + "','" + Convert.ToInt64(TPhoneNumber.Text) + "','" + DateOfCreation + "','" + DateOfCreation + "');";
                                                                            }
                                                                            else
                                                                            {
                                                                                MessageBox.Show("شخصی با این شماره پرونده وجود دارد");
                                                                            }
                                                                            
                                                                        }
                                                                        else
                                                                        {
                                                                            sqlite_cmd.CommandText = "SELECT ProfileID FROM NonPregnant WHERE ProfileID='" + ProfileID + "'";
                                                                            int count = Convert.ToInt32(sqlite_cmd.ExecuteScalar());
                                                                            if (count == 0)
                                                                            {

                                                                                sqlite_cmd.CommandText = "insert into NonPregnant values('" + NameTB.Text + "','" + LastName.Text + "','" + Convert.ToInt32(Age.Text) + "','" + ProfileID + "','" + Convert.ToInt64(ID.Text) + "','" + Convert.ToInt64(PhoneNumber.Text) + "','" + Convert.ToInt64(TPhoneNumber.Text) + "','" + DateOfCreation + "','" + DateOfCreation + "');";
                                                                            }
                                                                            else
                                                                            {
                                                                                MessageBox.Show("شخصی با این شماره پرونده وجود دارد");
                                                                            }
                                                                            
                                                                        }
                                                                        sqlite_cmd.ExecuteNonQuery();
                                                                        sqlite_conn.Close();
                                                                        MessageBox.Show("با موفقیت اضافه شد");
                                                                    }
                                                                    else
                                                                    {
                                                                        MessageBox.Show("کد ملی نادرست است");
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("کد ملی وارد نشده");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("شماره پرونده نادرست است");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("حرف شماره پرونده وارد نشده");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("کد ملی وارد شده نادرست است");
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("روز تشکیل پرونده نادرست وارد شده است");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("ماه تشکیل پرونده نادرست وارد شده است");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("سال تشکیل پرونده نادرست وارد شده است");
                                        }
                                        //int CYear = Convert.ToInt64(CreationYear.Text);
                                    }
                                    else
                                    {
                                        MessageBox.Show("شماره تلفن ثابت نادرست وارد شده است");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("شماره تلفن همراه نادرست وارد شده است");
                                }
                            }
                            else
                            {
                                MessageBox.Show("نام خانوادگی نادرست وارد شده است");
                            }
                        }
                        else
                        {
                            MessageBox.Show("سن زیاد تر از حالت عادی وارد شده است");
                        }
                    }
                    else
                    {
                        MessageBox.Show("سن نادرست وارد شده است");
                    }
                }
                else
                {
                    MessageBox.Show("نام خانوادگی نادرست وارد شده است");
                }
            }
            else
            {
                MessageBox.Show("اسم نادرست وارد شده است");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            sqlite_conn = new SQLiteConnection("Data Source=data.db;Version=3;New=False;Compress=True;");
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();
            string NCommand = "SELECT * FROM NonPregnant WHERE ";
            string Command = "SELECT * FROM Pregnant WHERE ";
            bool correct = true;
            switch (SearchBy.Text){
                case ("سن"):
                    NCommand += "Age";
                    Command += "Age";
                    break;
                case ("نام"):
                    NCommand += "Name";
                    Command += "Name";
                    break;
                case ("نام خانوادگی"):
                    Command += "LastName";
                    NCommand += "LastName";
                    break;
                case ("کد ملی"):
                    Command += "ID";
                    NCommand += "ID";
                    break;
                case ("شماره تلفن همراه"):
                    Command += "PhoneNumber";
                    NCommand += "PhoneNumber";
                    break;
                case ("شماره تلفن ثابت"):
                    Command += "TelephoneNumber";
                    NCommand += "TelephoneNumber";
                    break;
                default:
                    MessageBox.Show("جستجو بر اساس نادرست است");
                    correct = false;
                    break;
            }
            if (correct)
            {
                Command += "='" + textBox1.Text + "';";
                NCommand += "='" + textBox1.Text + "';";

                sqlite_cmd.CommandText = Command;
                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // The SQLiteDataReader allows us to run through the result lines:
                int num = 0;
                while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {

                    string[] row = { "" + num, "" + sqlite_datareader["Name"], "" + sqlite_datareader["LastName"], "" + sqlite_datareader["ProfileID"], "بله" };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                    // Print out the content of the text field:
                    //MessageBox.Show(""+);
                    num += 1;
                }
                sqlite_conn.Close();
                SQLiteConnection Nsqlite_conn;
                SQLiteCommand Nsqlite_cmd;
                SQLiteDataReader Nsqlite_datareader;
                Nsqlite_conn = new SQLiteConnection("Data Source=data.db;Version=3;New=False;Compress=True;");
                Nsqlite_conn.Open();
                Nsqlite_cmd = Nsqlite_conn.CreateCommand();

                Nsqlite_cmd.CommandText = "" + NCommand;
                Nsqlite_datareader = Nsqlite_cmd.ExecuteReader();
               
                while (Nsqlite_datareader.Read())
                {
                    string[] row = { "" + num, "" + Nsqlite_datareader["Name"], "" + Nsqlite_datareader["LastName"], "" + Nsqlite_datareader["ProfileID"], "خیر" };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                    // Print out the content of the text field:
                    //MessageBox.Show(""+);
                    num += 1;
                }
                // We are ready, now lets cleanup and close our connection:
                Nsqlite_conn.Close();

            }
        }
        private bool CheckLicense(string Name, string LastName, string Email, string License, bool writer)
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
                if (writer)
                {
                    string path = @"c:\TigenTech\License.lice";
                    System.IO.FileInfo file = new System.IO.FileInfo(path);
                    file.Directory.Create();

                    string Licer = BagherHash("TigenTechLicense", 1) + Environment.NewLine + "Name = " + Environment.NewLine + BagherHash(Name, 1) + Environment.NewLine + "LastName = " + Environment.NewLine + BagherHash(LastName, 1) + Environment.NewLine + "Email:" + Environment.NewLine + BagherHash(Email, 1) + Environment.NewLine + "License:" + Environment.NewLine + License;
                    System.IO.File.WriteAllText(file.FullName, Licer);
                }
                MessageBox.Show("The License Activated Successfully");
                //Close();
                return true;
            }
            else
            {
                MessageBox.Show("Invalid License");
                return false;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string Name="", LastName="", Email="", License="";
            string finder = "";
            if (File.Exists(@"c:\TigenTech\License.lice"))
            {
                int counter = 0;
                string line;
                
                // Read the file and display it line by line.
                System.IO.StreamReader file =
                   new System.IO.StreamReader(@"c:\TigenTech\License.lice");
                while ((line = file.ReadLine()) != null)
                {
                    if (line == "Name = ")
                    {
                        finder = "Name";
                    }
                    else
                    {
                        if (line == "LastName = ")
                        {
                            finder = "LastName";
                        }
                        else
                        {
                            if (line == "Email:")
                            {
                                finder = "Email";
                            }
                            else
                            {
                                if (line == "License:")
                                {
                                    finder = "License";
                                }
                                else
                                {
                                    line = BagherHash(line, -1);
                                    if (finder == "Name")
                                    {
                                        Name = line;
                                        finder = "";
                                    }
                                    else
                                    {
                                        if (finder == "LastName")
                                        {
                                            LastName = line;
                                            finder = "";
                                        }
                                        else
                                        {
                                            if (finder == "Email")
                                            {
                                                Email = line;
                                                finder = "";
                                            }
                                            else
                                            {
                                                if (finder == "License")
                                                {
                                                    License = BagherHash(line,1);
                                                    finder = "";
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    counter++;
                }

                file.Close();
                if (CheckLicense(Name, LastName, Email, License, false))
                {
                     
                }
                else
                {
                    //Close();
                }
            }
            else
            {
                //Close();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 465);
            this.Controls.Add(this.button1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            PrName.Text = "";
            PrLastName.Text = "";
            PrProfileId.Text = "";
            PrID.Text = "";
            PrPhoneNumber.Text = "";
            PrTPhoneNumber.Text = "";
            PrDate.Text = "";
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            sqlite_conn = new SQLiteConnection("Data Source=data.db;Version=3;New=False;Compress=True;");
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();
            if (checkBox1.Checked)
            {
                sqlite_cmd.CommandText = "SELECT * FROM Pregnant WHERE ProfileID='" + textBox2.Text + "'";
            }
            else
            {
                sqlite_cmd.CommandText = "SELECT * FROM NonPregnant WHERE ProfileID='" + textBox2.Text + "'";
            }
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                PrName.Text = ""+sqlite_datareader["Name"];
                PrLastName.Text = "" + sqlite_datareader["LastName"];
                PrProfileId.Text = "" + sqlite_datareader["ProfileID"];
                PrID.Text = "" + sqlite_datareader["ID"];
                PrPhoneNumber.Text = "" + sqlite_datareader["PhoneNumber"];
                PrTPhoneNumber.Text = "" + sqlite_datareader["TelephoneNumber"];
                PrDate.Text = "" + sqlite_datareader["DateOfCreation"];
                break;
            }
            sqlite_conn.Close();
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //Form3 frm = new Form3();
            //frm.Show();
        }

        private void PrLastName_Click(object sender, EventArgs e)
        {
            SetClipboard(PrLastName);
            MessageBox.Show("نام خانوادگی کپی شد");
        }

        private void SetClipboard(Label x)
        {
            if (x.Text != "")
            {
                Clipboard.SetText(x.Text);
            }
            
        }

        private void PrProfileId_Click(object sender, EventArgs e)
        {
            MessageBox.Show("شماره پرونده کپی شد");
            SetClipboard(PrProfileId);
        }

        private void PrName_Click(object sender, EventArgs e)
        {
            MessageBox.Show("نام کپی شد");
            SetClipboard(PrName);
        }

        private void PrDate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("تاریخ تشکیل پرونده کپی شد");
            SetClipboard(PrDate);
        }

        private void PrID_Click(object sender, EventArgs e)
        {
            MessageBox.Show("کد ملی کپی شد");
            SetClipboard(PrID);
        }

        private void PrTPhoneNumber_Click(object sender, EventArgs e)
        {
            MessageBox.Show("شماره تلفن کپی شد");
            SetClipboard(PrTPhoneNumber);
        }

        private void PrPhoneNumber_Click(object sender, EventArgs e)
        {
            MessageBox.Show("شماره تلفن ثابت کپی شد");
            SetClipboard(PrPhoneNumber);
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }
    }
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            sqlite_conn = new SQLiteConnection("Data Source=MD.db;Version=3;New=False;Compress=True;");
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT Count(*) FROM Morajee.Columns where TABLE_NAME = 'MD'";
            Int32 count = (Int32)sqlite_cmd.ExecuteScalar();
            MessageBox.Show(""+count);
            //sqlite_cmd.CommandText = "ALTER TABLE MORAJEE; ALTER COLUMN Morajee Text; ";
            MessageBox.Show("به پزشک از ورود مریض اطلاع داده شد");
            sqlite_conn.Close();
            Close();
        }  
    }
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string Name = "", LastName = "", Email = "", License = "";
            string finder = "";
            if (File.Exists(@"c:\TigenTech\License.lice"))
            {
                int counter = 0;
                string line;

                // Read the file and display it line by line.
                System.IO.StreamReader file =
                   new System.IO.StreamReader(@"c:\TigenTech\License.lice");
                while ((line = file.ReadLine()) != null)
                {
                    if (line == "Name = ")
                    {
                        finder = "Name";
                    }
                    else
                    {
                        if (line == "LastName = ")
                        {
                            finder = "LastName";
                        }
                        else
                        {
                            if (line == "Email:")
                            {
                                finder = "Email";
                            }
                            else
                            {
                                if (line == "License:")
                                {
                                    finder = "License";
                                }
                                else
                                {
                                    line = BagherHash(line, -1);
                                    if (finder == "Name")
                                    {
                                        Name = line;
                                        finder = "";
                                    }
                                    else
                                    {
                                        if (finder == "LastName")
                                        {
                                            LastName = line;
                                            finder = "";
                                        }
                                        else
                                        {
                                            if (finder == "Email")
                                            {
                                                Email = line;
                                                finder = "";
                                            }
                                            else
                                            {
                                                if (finder == "License")
                                                {
                                                    License = BagherHash(line, 1);
                                                    finder = "";
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    counter++;
                }

                file.Close();
                if (CheckLicense(Name, LastName, Email, License, false))
                {
                    Close();

                }
                else
                {
                    MessageBox.Show("Invalid License File");
                }
            }
            else
            {
                
            }
        }
    
        private bool CheckLicense(string Name, string LastName, string Email, string License,bool writer)
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
                if (writer)
                {
                    string path = @"c:\TigenTech\License.lice";
                    System.IO.FileInfo file = new System.IO.FileInfo(path);
                    file.Directory.Create();
                    
                    string Licer = BagherHash("TigenTechLicense", 1) + Environment.NewLine + "Name = " + Environment.NewLine + BagherHash(Name, 1) + Environment.NewLine + "LastName = " + Environment.NewLine + BagherHash(LastName, 1) + Environment.NewLine + "Email:" + Environment.NewLine + BagherHash(Email, 1) + Environment.NewLine + "License:" + Environment.NewLine + License;
                    System.IO.File.WriteAllText(file.FullName, Licer);
                }
                MessageBox.Show("The License Activated Successfully");
                Close();
                return true;
            }
            else
            {
                MessageBox.Show("Invalid License");
                return false;
            }
        }
        private string BagherHash(string text, int m)
        {
            string hashed = "";
            byte[] asciiBytes = Encoding.ASCII.GetBytes(text);
            foreach (char asciicode in asciiBytes)
            {
                char chare = Convert.ToChar(asciicode+m);
                hashed += chare;
            }
            return hashed;
            //BitConverter.ToString("");
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
                            CheckLicense(textBox1.Text, textBox2.Text, textBox4.Text, textBox3.Text,true);
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
