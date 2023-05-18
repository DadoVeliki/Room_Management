using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Room_Management_DavidT
{
    public partial class Rezerviranje : Form
    {
        public List<Rezervacije>popisRezervacija=new List<Rezervacije>();
        public List<User> users = new List<User>();
        public List<Vremena>vremena=new List<Vremena>();
        public List<Ponavljanja>ponavljanja=new List<Ponavljanja>();
        public List<Prostorija> prostorije = new List<Prostorija>();
        int idUsera;
        Spajanje s = Spajanje.GetInstance();
        public List<int>zauzeti=new List<int>();
        int cb1 = 0;
        public Rezerviranje(List<Rezervacije> popisR, List<User> u,int id,List<Vremena> v,List<Ponavljanja>p,List<Prostorija>pr)
        {
            InitializeComponent();
            this.popisRezervacija=popisR;
            this.users=u;
            this.idUsera=id;
            this.vremena=v;
            this.ponavljanja = p;
            this.prostorije = pr;
        }

        private void Rezerviranje_Load(object sender, EventArgs e)
        {
            label5.Text = "";
            foreach(Prostorija p in prostorije)
            {
                comboBox2.Items.Add(p.Prostorij);
            }
            foreach(Vremena v in vremena)
            {
                comboBox1.Items.Add(v.Pocetak.ToString().Substring(10));
                comboBox3.Items.Add(v.Pocetak.ToString().Substring(10));
            }
            foreach(Ponavljanja p in ponavljanja)
            {
                comboBox4.Items.Add(p.Vrsta);
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            Moje.prazniListbox(listBox1);
            int proID = comboBox2.SelectedIndex + 1;
            foreach (Rezervacije r in popisRezervacija)
            {
                int poc = r.PocetakID - 1;
                int kraj = r.KrajID - 1;
                string user = "";
                //string user = users[r.UserID-1].getun();
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
                    user = dataReader.GetString(0);
                }
                naredba.Dispose();
                s.cnn.Close();
                for (int i = 1; i <= 14; i++)
                {
                    if (r.ProstorijaID == proID && r.Datum == monthCalendar1.SelectionStart && r.Aktivno == true)
                    {
                        for (int j = poc; j <= kraj; j++)
                        {
                            listBox1.Items[j] = $"{j + 1}. REZERVIRAO {user}";
                        }

                    }
                }
            }
            zauzeti.Clear();
            for(int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.Items[i].ToString().Contains("REZERVIRAO"))
                {
                    zauzeti.Add(i);
                }
            }
            /*for(int i = 0; i < vremena.Count; i++)
            {
                for (int j = 0; j < zauzeti.Count; j++)
                {
                    if (i != zauzeti[j])
                    {
                        comboBox1.Items.Add(vremena[i].Pocetak.ToString().Substring(10));
                    }
                }
            }*/
            /*for(int i = 0; i < comboBox1.Items.Count; i++)
            {
                for (int j = 0; j < zauzeti.Count; j++)
                {
                    if (i == zauzeti[j])
                    {
                        comboBox1.Items.RemoveAt(i);
                    }
                }
            }*/
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*comboBox3.Items.Clear();
            int index=comboBox1.SelectedIndex;
            for(int i = index; i < vremena.Count; i++)
            {
                comboBox3.Items.Add(vremena[i].Pocetak.ToString().Substring(10));
            }*/
            cb1 = comboBox1.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int brojac = 0;
            try
            {
                if (comboBox1.SelectedIndex < comboBox3.SelectedIndex)
                {
                    for(int i = comboBox1.SelectedIndex; i < comboBox3.SelectedIndex; i++)
                    {
                        if (listBox1.Items[i].ToString().Length > 3)
                        {
                            brojac++;
                        }
                    }
                    if (brojac==0)
                    {
                        label5.Text = "";
                        s.cnn.Open();
                        SqlCommand naredba;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        string sql = $"insert into Rezervacije (Datum,UserID,PocetakID,KrajID,ProstorijaID,PonavljanjeID,Aktivno) VALUES ('{monthCalendar1.SelectionStart.ToString("yyyy-MM-dd")}',{idUsera},{comboBox1.SelectedIndex + 1},{comboBox3.SelectedIndex + 1},{comboBox2.SelectedIndex + 1},{comboBox4.SelectedIndex + 1},1); ";
                        naredba = new SqlCommand(sql, s.cnn);
                        adapter.InsertCommand = new SqlCommand(sql, s.cnn);
                        adapter.InsertCommand.ExecuteNonQuery();
                        s.cnn.Close();
                        Moje.unselectComboBox(comboBox1);
                        Moje.unselectComboBox(comboBox3);
                        Moje.unselectComboBox(comboBox4);
                        popisRezervacija.Clear();
                        SqlDataReader dataReader;
                        sql = $"select * from Rezervacije where Aktivno=1";
                        s.cnn.Close();
                        s.cnn.Open();
                        naredba = new SqlCommand(sql, s.cnn);
                        dataReader = naredba.ExecuteReader();
                        while (dataReader.Read())
                        {
                            popisRezervacija.Add(new Rezervacije(int.Parse(dataReader.GetValue(0).ToString()), DateTime.Parse(dataReader.GetValue(1).ToString()), int.Parse(dataReader.GetValue(2).ToString()), int.Parse(dataReader.GetValue(3).ToString()), int.Parse(dataReader.GetValue(4).ToString()), int.Parse(dataReader.GetValue(5).ToString()), int.Parse(dataReader.GetValue(6).ToString()), bool.Parse(dataReader.GetValue(7).ToString())));
                        }
                        s.cnn.Close();
                    }
                    else
                    {
                        label5.Text = "Termin je zauzet!";
                    }

                }
                else
                {
                    label5.Text = "Ne može završiti prije nego počne!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Potrebno odabrati sve podatke!");
            }
        }

        private void Rezerviranje_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
