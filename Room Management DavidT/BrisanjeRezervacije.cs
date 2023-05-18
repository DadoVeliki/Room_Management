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
using System.Data.Common;

namespace Room_Management_DavidT
{
    public partial class BrisanjeRezervacije : Form
    {
        public List<User> users = new List<User>();
        public List<Rezervacije> popisRezervacija = new List<Rezervacije>();
        public List<Prostorija> prostorije = new List<Prostorija>();
        public List<Vremena> vremena = new List<Vremena>();
        public List<Ponavljanja> ponavljanja = new List<Ponavljanja>();
        Spajanje s = Spajanje.GetInstance();
        int od = 0;
        public BrisanjeRezervacije(List<User>user, List<Prostorija> pr,List<Vremena>v,List<Ponavljanja>p)
        {
            InitializeComponent();
            this.users = user;
            //this.popisRezervacija = rez;
            this.prostorije = pr;
            this.vremena = v;
            this.ponavljanja = p;
        }

        private void BrisanjeRezervacije_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 1000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.button1, "Izbriši odabranu rezervaciju");
            Moje.gumbSlika(button1, "delete.png");
            try
            {
                Spajanje s = Spajanje.GetInstance();
                SqlCommand naredba;
                SqlDataReader dataReader;
                string sql, output = "";
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

                foreach (Rezervacije r in popisRezervacija)
                {
                     listBox1.Items.Add($"{r.Id} Korisnik {users[r.UserID - 1].getun()} rezervirao je prostoriju {prostorije[r.ProstorijaID - 1].Prostorij} datuma {r.Datum.ToString().Substring(0, 10)} od {vremena[r.PocetakID - 1].Pocetak.ToString().Substring(11)} do {vremena[r.KrajID - 1].Pocetak.ToString().Substring(11)}");
                   
                }
            }
            catch(Exception ex) { }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand naredba;
            SqlDataAdapter adapter = new SqlDataAdapter();
            s.cnn.Open();
            int loc = listBox1.SelectedItem.ToString().IndexOf(" ");
            string sql = $"update Rezervacije set Aktivno=0 where ID={listBox1.SelectedItem.ToString().Substring(0,loc)};";
            adapter.UpdateCommand = new SqlCommand(sql, s.cnn);
            adapter.UpdateCommand.ExecuteNonQuery();
            s.cnn.Close();
            listBox1.Items.Remove(od);
        }
        private void BrisanjeRezervacije_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            od = listBox1.SelectedIndex;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
