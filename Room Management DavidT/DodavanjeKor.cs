using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Room_Management_DavidT
{
    public partial class DodavanjeKor : Form
    {
        public DodavanjeKor()
        {
            InitializeComponent();
        }
        SqlCommand naredba;
        SqlDataAdapter adapter = new SqlDataAdapter();
        Spajanje s = Spajanje.GetInstance();
        int id;
        string sql = "";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

            
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {

            
            string username = textBox1.Text;
            string password = Moje.CreateMD5(textBox2.Text);
            string fullname = textBox3.Text;
            s.cnn.Open();
            sql = $"Insert into Users (Username,Password,FullName,Active) VALUES ('{username}','{password}','{fullname}',1);";
            naredba = new SqlCommand(sql, s.cnn);
            adapter.InsertCommand = new SqlCommand(sql, s.cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            s.cnn.Close();
            SqlDataReader dataReader;
            sql = $"select ID from Users where Username='{username}'";
            s.cnn.Open();
            naredba = new SqlCommand(sql, s.cnn);

            dataReader = naredba.ExecuteReader();
            int brojac = 0;
            while (dataReader.Read())
            {
                while (brojac == 0)
                {
                    id = int.Parse(dataReader.GetValue(0).ToString());
                    brojac++;
                }
            }
            naredba.Dispose();
            s.cnn.Close();
            if (checkBox1.Checked)
            {
                Moje.unosPrava(id, 1,1);
            }
            else
            {
                Moje.unosPrava(id, 1,0);
            }
            if (checkBox2.Checked)
            {
                Moje.unosPrava(id, 2, 1);
            }
            else
            {
                Moje.unosPrava(id, 2, 0);
            }
            if (checkBox3.Checked)
            {
                Moje.unosPrava(id, 3, 1);
            }
            else
            {
                Moje.unosPrava(id, 3, 0);
            }
            if (checkBox4.Checked)
            {
                Moje.unosPrava(id, 4, 1);
            }
            else
            {
                Moje.unosPrava(id, 4, 0);
            }
            if (checkBox5.Checked)
            {
                Moje.unosPrava(id, 5, 1);
            }
            else
            {
                Moje.unosPrava(id, 5, 0);
            }
            if (checkBox6.Checked)
            {
                Moje.unosPrava(id, 6, 1);
            }
            else
            {
                Moje.unosPrava(id, 6, 0);
            }
                label7.Text = "Spremljeno u bazu!";
            }
            else
            {
                label7.Text = "Treba popuniti sva polja!";
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            }
            catch { }
        }

        private void DodavanjeKor_Load(object sender, EventArgs e)
        {
            label7.Text = "";
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 1000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.button1, "Spremi promjene");
            Moje.gumbSlika(button1, "save.png");
        }

        private void DodavanjeKor_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
