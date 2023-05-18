using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Room_Management_DavidT
{
    public partial class Prijava : Form
    {
        public Prijava()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            /*Spajanje login = Spajanje.GetInstance();
            string un = textBoxUN.Text;
            string pw = textBoxPW.Text;

            string hash = CreateMD5(pw);
            foreach (User u in users)
            {
                //label4.Text += $"{u.getid()} {u.getun()} {u.getfn()} {u.getact()} \n";
                if ((u.getun() == un) && (u.getpw() == hash))
                {
                    Admin a = new Admin();
                    a.ShowDialog();
                    textBoxUN.Text = "";
                    textBoxPW.Text = "";
                }
            }*/

        }
        public string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToBase64String(hashBytes);
            }
        }

        private void Prijava_Load(object sender, EventArgs e)
        {
            
        }
    }
}
