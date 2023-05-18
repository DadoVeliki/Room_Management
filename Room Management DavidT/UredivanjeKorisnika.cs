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
using System.Reflection.Emit;

namespace Room_Management_DavidT
{
    public partial class UredivanjeKorisnika : Form
    {
        int usId = 0;
        public List<User> users = new List<User>();
        public UredivanjeKorisnika(List<User>popisUsera)
        {
            InitializeComponent();
            checkBox3.Enabled = false;
            this.users = popisUsera;
        }
        SqlCommand naredba;
        SqlDataReader dataReader;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string sql, us = "";
        Spajanje s = Spajanje.GetInstance();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text != "")
            {
            string username = textBox1.Text;
            //string password = Moje.CreateMD5(textBox2.Text);
            string fullname = textBox3.Text;
            int akt;
                if (checkBox7.Checked) akt = 1;
                else akt = 0;
            s.cnn.Open();
            sql = $"update Users set Username='{username}', FullName='{fullname}', Active={akt} where Username='{us}';";
            adapter.UpdateCommand = new SqlCommand(sql, s.cnn);
            adapter.UpdateCommand.ExecuteNonQuery();
            s.cnn.Close();

            if (checkBox1.Checked) Moje.izmjenaPrava(1,usId,1);
            else Moje.izmjenaPrava(0, usId,1);

            if (checkBox2.Checked) Moje.izmjenaPrava(1, usId, 2);
            else Moje.izmjenaPrava(0, usId, 2);
            
            if (checkBox3.Checked) Moje.izmjenaPrava(1, usId, 3);
            else Moje.izmjenaPrava(0, usId, 3);

            if (checkBox4.Checked) Moje.izmjenaPrava(1, usId, 4);
            else Moje.izmjenaPrava(0, usId,4);

            if (checkBox5.Checked) Moje.izmjenaPrava(1, usId, 5);
            else Moje.izmjenaPrava(0, usId, 5);

            if (checkBox6.Checked) Moje.izmjenaPrava(1, usId, 6);
            else Moje.izmjenaPrava(0, usId, 6);
                label7.Text = "Spremljeno u bazu!";
            }
            else
            {
                label7.Text = "Treba popuniti sva polja!";
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            
            us = listBox1.SelectedItem.ToString();
            sql = $"select * from Users where Username='{us}'";
            s.cnn.Open();
            naredba = new SqlCommand(sql, s.cnn);
            dataReader = naredba.ExecuteReader();
            while (dataReader.Read())
            {
                usId = int.Parse(dataReader.GetValue(0).ToString());
                textBox1.Text = dataReader.GetValue(1).ToString();
                //textBox2.Text = dataReader.GetValue(2).ToString();
                textBox3.Text = dataReader.GetValue(3).ToString();
            }
            naredba.Dispose();
            s.cnn.Close();

            sql = $"select PravoID from UserPrava where UserID={usId} and Aktivno=1";
            s.cnn.Open();
            naredba = new SqlCommand(sql, s.cnn);
            dataReader = naredba.ExecuteReader();
            while (dataReader.Read())
            {
                bool akt = users[usId-1].getact();
                if (akt) checkBox7.Checked = true;
                else checkBox7.Checked = false;
                int p = int.Parse(dataReader.GetValue(0).ToString());
                if (p == 1)checkBox1.Checked = true;
                if (p == 2) checkBox2.Checked = true;
                if (p == 4) checkBox4.Checked = true;
                if (p == 5) checkBox5.Checked = true;
                if (p == 6) checkBox6.Checked = true;
            }
            naredba.Dispose();
            s.cnn.Close();
        }

        private void UredivanjeKorisnika_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UredivanjeKorisnika_Load(object sender, EventArgs e)
        {
            label7.Text = "";
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 1000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.button1, "Spremi promjene");
            Moje.gumbSlika(button1, "save.png");
            sql = $"select Username from Users";
            s.cnn.Open();
            naredba = new SqlCommand(sql, s.cnn);
            dataReader = naredba.ExecuteReader();
            while (dataReader.Read())
            {
                listBox1.Items.Add(dataReader.GetValue(0).ToString());
            }
            naredba.Dispose();
            s.cnn.Close();
            checkBox3.Checked = true;
        }
    }
}
