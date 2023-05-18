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
    public partial class BrisanjeKorisnika : Form
    {
        string us="";
        int usid=0;
        public BrisanjeKorisnika()
        {
            InitializeComponent();
        }
        Spajanje s = Spajanje.GetInstance();
        SqlCommand naredba;
        SqlDataReader dataReader;
        string sql;
        SqlDataAdapter adapter = new SqlDataAdapter();
        private void BrisanjeKorisnika_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 1000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.button1, "Izbriši odabranog korisnika");
            Moje.gumbSlika(button1, "delete.png");
            label2.Text = "";
            sql = "select Username from Users where Active=1";
            s.cnn.Open();
            naredba = new SqlCommand(sql, s.cnn);
            dataReader = naredba.ExecuteReader();
            while (dataReader.Read())
            {
                listBox1.Items.Add(dataReader.GetValue(0).ToString());
            }
            naredba.Dispose();
            s.cnn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string us=listBox1.SelectedItem.ToString();
            s.cnn.Open();
            sql = $"update Users set Active=0 where Username='{us}';";
            adapter.UpdateCommand = new SqlCommand(sql, s.cnn);
            adapter.UpdateCommand.ExecuteNonQuery();
            s.cnn.Close();
            //listBox1.Items.RemoveAt(usid);
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void BrisanjeKorisnika_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            us = listBox1.SelectedItem.ToString();
            usid = listBox1.SelectedIndex;
            label2.Text = us;
        }
    }
}
