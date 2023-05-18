using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Room_Management_DavidT
{
    public partial class Pregled : Form
    {
        private int idUsera;
        public List<User> users = new List<User>();
        public List<Rezervacije>popisRezervacija=new List<Rezervacije>();
        public List<Prostorija>prostorije=new List<Prostorija>();
        public List<Vremena> vremena = new List<Vremena>();
        public List<Ponavljanja> ponavljanja = new List<Ponavljanja>();
        public Pregled(int id,List<User>user)
        {
            InitializeComponent();
            this.idUsera = id;
            this.users = user;
            rez.Enabled = false;
            dod.Enabled = false;
            obrrez.Enabled = false;
            uredikor.Enabled = false;
            obkor.Enabled = false;
            
            comboBox2.Items.Add("KORISNICI");
            comboBox2.Items.Add("REZERVACIJE");
        }

        private void Pregled_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1=new ToolTip();
            toolTip1.AutoPopDelay = 1000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.dod, "Dodaj korisnika");
            toolTip1.SetToolTip(this.uredikor, "Uredi korisnika");
            toolTip1.SetToolTip(this.obkor, "Obriši korisnika");
            toolTip1.SetToolTip(this.rez, "Rezerviraj prostoriju");
            toolTip1.SetToolTip(this.obrrez, "Obriši rezervaciju");
            toolTip1.SetToolTip(this.button2, "Izađi iz aplikacije");
            toolTip1.SetToolTip(this.button1, "Konfiguracija");
            label2.Text = "";
            dod.Visible = false;
            uredikor.Visible = false;
            obkor.Visible = false;
            rez.Visible = false;
            obrrez.Visible = false;
            Moje.gumbSlika(dod, "add.png");
            Moje.gumbSlika(obkor, "rem.png");
            Moje.gumbSlika(uredikor, "edit.png");
            Moje.gumbSlika(rez, "plan.png");
            Moje.gumbSlika(obrrez, "rem.png");
            Moje.gumbSlika(button2, "exit.png");
            Moje.gumbSlika(button1, "config.png");

            Moje.prazniListbox(listBox1);
            List<UserPrava> pravaTrenutnog = new List<UserPrava>();
            List<Prava> svaPrava = new List<Prava>();
            Spajanje s = Spajanje.GetInstance();
            SqlCommand naredba;
            SqlDataReader dataReader;
            string sql, output = "";
            sql = $"select * from Prava";
            s.cnn.Open();
            naredba = new SqlCommand(sql, s.cnn);
            dataReader = naredba.ExecuteReader();
            while (dataReader.Read())
            {
                svaPrava.Add(new Prava(int.Parse(dataReader.GetValue(0).ToString()),dataReader.GetValue(1).ToString()));
            }
            sql = $"select * from UserPrava where UserID={this.idUsera}";
            s.cnn.Close();
            s.cnn.Open();
            naredba = new SqlCommand(sql, s.cnn);
            dataReader = naredba.ExecuteReader();
            while (dataReader.Read())
            {
                pravaTrenutnog.Add(new UserPrava(int.Parse(dataReader.GetValue(0).ToString()), int.Parse(dataReader.GetValue(1).ToString()), int.Parse(dataReader.GetValue(2).ToString()), bool.Parse(dataReader.GetValue(3).ToString())));
            }

            naredba.Dispose();
            s.cnn.Close();
            sql = "select * from Vremena";
            s.cnn.Open();
            naredba = new SqlCommand(sql, s.cnn);
            dataReader = naredba.ExecuteReader();
            while (dataReader.Read())
            {
                vremena.Add(new Vremena(int.Parse(dataReader.GetValue(0).ToString()), DateTime.Parse(dataReader.GetValue(1).ToString())));
            }
            naredba.Dispose();
            s.cnn.Close();
            sql = "select * from Ponavljanja";
            s.cnn.Open();
            naredba = new SqlCommand(sql, s.cnn);
            dataReader = naredba.ExecuteReader();
            while (dataReader.Read())
            {
                ponavljanja.Add(new Ponavljanja(int.Parse(dataReader.GetValue(0).ToString()), dataReader.GetValue(1).ToString()));
            }
            naredba.Dispose();
            s.cnn.Close();
            foreach (Prava p in svaPrava)
            {
                foreach(UserPrava u in pravaTrenutnog)
                {
                    if((p.Id==1) && (u.PravoID == 1))
                    {
                        rez.Enabled = true;
                    }
                    if ((p.Id == 2) && (u.PravoID == 2))
                    {
                        obrrez.Enabled = true;
                    }
                    if ((p.Id == 4) && (u.PravoID == 4))
                    {
                        dod.Enabled = true;
                    }
                    if ((p.Id == 5) && (u.PravoID == 5))
                    {
                        obkor.Enabled = true;
                    }
                    if ((p.Id == 6) && (u.PravoID == 6))
                    {
                        uredikor.Enabled = true;
                    }
                }
            }
            sql = $"select * from Rezervacije";
            s.cnn.Close();
            s.cnn.Open();
            naredba = new SqlCommand(sql, s.cnn);
            dataReader = naredba.ExecuteReader();
            while (dataReader.Read())
            {
                //label2.Text=dataReader.GetValue(1).ToString();
                popisRezervacija.Add(new Rezervacije(int.Parse(dataReader.GetValue(0).ToString()), DateTime.Parse(dataReader.GetValue(1).ToString()), int.Parse(dataReader.GetValue(2).ToString()), int.Parse(dataReader.GetValue(3).ToString()), int.Parse(dataReader.GetValue(4).ToString()), int.Parse(dataReader.GetValue(5).ToString()), int.Parse(dataReader.GetValue(6).ToString()), bool.Parse(dataReader.GetValue(7).ToString())));
            }

            naredba.Dispose();
            s.cnn.Close();
            sql = $"select * from Prostorija";
            s.cnn.Close();
            s.cnn.Open();
            naredba = new SqlCommand(sql, s.cnn);
            dataReader = naredba.ExecuteReader();
            while (dataReader.Read())
            {
                prostorije.Add(new Prostorija(int.Parse(dataReader.GetValue(0).ToString()), dataReader.GetValue(1).ToString()));
            }
            naredba.Dispose();
            s.cnn.Close();
            foreach(Prostorija prostorija in prostorije)
            {
                comboBox1.Items.Add(prostorija.Prostorij);
            }
        }

        private void rezerviranjeProstorijeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void odjavaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dod_Click(object sender, EventArgs e)
        {
            DodavanjeKor k = new DodavanjeKor();
            k.ShowDialog();
        }

        private void obkor_Click(object sender, EventArgs e)
        {
            BrisanjeKorisnika b=new BrisanjeKorisnika();
            b.ShowDialog();
        }

        private void uredikor_Click(object sender, EventArgs e)
        {
            UredivanjeKorisnika u = new UredivanjeKorisnika(users);
            u.ShowDialog();
        }

        private void rez_Click(object sender, EventArgs e)
        {
            Rezerviranje r = new Rezerviranje(popisRezervacija,users,idUsera,vremena,ponavljanja,prostorije);
            r.ShowDialog();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            try
            {

            
            Moje.prazniListbox(listBox1);
            int proID = comboBox1.SelectedIndex+1;
            //label2.Text = proID.ToString();
            foreach(Rezervacije r in popisRezervacija)
            {
                int poc = r.PocetakID-1;
                int kraj = r.KrajID-1;
                string user = "";
               // string user = users[r.UserID-1].getun();
                Spajanje s = Spajanje.GetInstance();
                SqlCommand naredba;
                SqlDataReader dataReader;
                    string sql;
                sql = $"select Username from Users where ID={r.UserID}";
                s.cnn.Close();
                s.cnn.Open();
                naredba = new SqlCommand(sql, s.cnn);
                dataReader = naredba.ExecuteReader();
                    while (dataReader.Read())
                    {
                        user= dataReader.GetString(0);
                    }
                    naredba.Dispose();
                    s.cnn.Close();
                    for (int i = 1; i <= 14; i++)
                    {
                        if (r.ProstorijaID == proID && r.Datum == monthCalendar1.SelectionStart && r.Aktivno==true)
                        {
                            //listBox1.Items[i-1] += "zauzeto";
                            for(int j = poc ; j <= kraj; j++)
                            {
                                listBox1.Items[j] = $"{j+1}. REZERVIRAO {user}";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void obrrez_Click(object sender, EventArgs e)
        {
            BrisanjeRezervacije b = new BrisanjeRezervacije(users,prostorije, vremena, ponavljanja);
            b.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string putanja = @"..\konfiguracijska\";
                //DirectoryInfo di = new DirectoryInfo(@"..\konfiguracijska\config.txt");
                //FileStream fs = new FileStream(File.Create(@"..\konfiguracijska\config.txt"));
                if (!Directory.Exists(putanja))
                {
                    Directory.CreateDirectory(putanja);
                    if (!File.Exists(putanja + "config.txt"))
                    {
                        FileStream fs = new FileStream(putanja + "config.txt", FileMode.Create);
                        StreamWriter sw = new StreamWriter(fs);
                        sw.Write("IP:\nPORT:\nUSER ID:\nPASSWORD:");
                        sw.Flush();
                        sw.Close();
                        fs.Close();
                        //FileStream op = File.Open(putanja + "config.txt", FileMode.Open, FileAccess.Write);
                        //Konfig k = new Konfig();
                        // k.ShowDialog();
                    }
                    else
                    {
                        //FileStream op = File.Open(putanja + "config.txt", FileMode.Open,FileAccess.Write);

                    }
                }
                Konfig k = new Konfig();
                k.ShowDialog();
                //File.Open(putanja + "config.txt", FileMode.Open);
            }
           catch(Exception ex)
            {
                MessageBox.Show(ex+"");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = "Prostorija: " + comboBox1.SelectedItem;
        }

        private void Pregled_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex == 0)
            {
                label2.Text = "KORISNICI";
                dod.Visible = true;
                uredikor.Visible = true;
                obkor.Visible = true;
                rez.Visible = false;
                obrrez.Visible = false;
            }
            else if(comboBox2.SelectedIndex == 1)
            {
                label2.Text = "REZERVACIJE";
                dod.Visible = false;
                uredikor.Visible = false;
                obkor.Visible = false;
                rez.Visible = true;
                obrrez.Visible = true;
            }
        }
    }
}