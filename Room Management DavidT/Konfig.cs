using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Room_Management_DavidT
{
    public partial class Konfig : Form
    {
        public Konfig()
        {
            InitializeComponent();
        }
        string putanja = @"..\konfiguracijska\config.txt";
        private void button1_Click(object sender, EventArgs e)
        {
            string tekst="";
            string putanja = @"..\konfiguracijska\config.txt";
            FileStream fs = new FileStream(putanja, FileMode.Append);
            //StreamReader sr = new StreamReader(fs);
            StreamWriter sw = new StreamWriter(fs);
            fs.Close();
            promjena();
            
            }

        private void Konfig_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 1000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.button1, "Spremi promjene");
            Moje.gumbSlika(button1, "save.png");
            string[] lines = File.ReadAllLines(putanja);
            try
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            textBox1.Text = lines[i].Substring(3);
                            break;
                        case 1:
                            string port = lines[i].Substring(5).ToString();
                            if (port != "")
                            {
                                numericUpDown1.Value = int.Parse(port);
                            }
                            break;
                        case 2:
                            textBox3.Text = lines[i].Substring(8);
                            break;
                        case 3:
                            textBox4.Text = "";
                            //textBox4.Text = lines[i].Substring(9);
                            break;
                    }
                }
            }
            catch { }
    }
    public void promjena()
        {
            string[] lines = File.ReadAllLines(putanja);
            for(int i = 0; i < lines.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        lines[i] = "IP:"+textBox1.Text;
                        break;
                    case 1:
                        lines[i] = "PORT:"+numericUpDown1.Value.ToString();
                        break;
                    case 2:
                        lines[i] = "USER ID:"+textBox3.Text;
                        break;
                    case 3:
                        lines[i] = "PASSWORD:"+Moje.CreateMD5(textBox4.Text);
                        break;
                }
            }
            File.WriteAllLines(putanja, lines);
        }

        private void Konfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
