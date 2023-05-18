using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Room_Management_DavidT
{
    public partial class Form1 : Form
    {
        public List<User>users=new List<User>();
        public Form1()
        {
            InitializeComponent();
            textBoxUN.Text = "admin";
            textBoxPW.Text = "admin";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Spajanje s = new Spajanje();
            SqlCommand naredba;
            SqlDataReader dataReader;
            string sql;
            sql = "select * from Users";
            s.cnn.Open();
            naredba = new SqlCommand(sql, s.cnn);
            dataReader = naredba.ExecuteReader();
            while (dataReader.Read())
            {
                users.Add(new User(int.Parse(dataReader.GetValue(0).ToString()), dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString(), dataReader.GetValue(3).ToString(), bool.Parse(dataReader.GetValue(4).ToString())));
                // output = output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + "\n";
            }
            naredba.Dispose();
            s.cnn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            //Spajanje login = Spajanje.GetInstance();
            string un = textBoxUN.Text;
            string pw = textBoxPW.Text;
            string hash = Moje.CreateMD5(pw);
            foreach (User u in users)
            {
                //label4.Text += $"{u.getid()} {u.getun()} {u.getfn()} {u.getact()} \n";
                if ((u.getun() == un) && (u.getpw() == hash))
                {
                    Pregled p = new Pregled(u.getid(),users);
                    p.ShowDialog();
                    textBoxUN.Text = "";
                    textBoxPW.Text = "";
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }
    }
}
