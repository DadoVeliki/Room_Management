using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using System.Drawing;

namespace Room_Management_DavidT
{
    public class Moje
    {
        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToBase64String(hashBytes);
            }
        }
        
        public static void unosPrava(int id,int brojP,int stanje)
        {
            Spajanje s = Spajanje.GetInstance();
            SqlCommand naredba;
            SqlDataAdapter adapter = new SqlDataAdapter();
            s.cnn.Open();
            string sql = $"Insert into UserPrava (UserID,PravoID,Aktivno) VALUES ({id},{brojP},{stanje});";
            naredba = new SqlCommand(sql, s.cnn);
            adapter.InsertCommand = new SqlCommand(sql, s.cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            s.cnn.Close();
        }
        public static void izmjenaPrava(int stanje,int usId,int p)
        {
            Spajanje s = Spajanje.GetInstance();
            SqlDataAdapter adapter = new SqlDataAdapter();
            s.cnn.Open();
            string sql = $"update UserPrava set Aktivno={stanje} where UserID={usId} and PravoID={p};";
            adapter.UpdateCommand = new SqlCommand(sql, s.cnn);
            adapter.UpdateCommand.ExecuteNonQuery();
            s.cnn.Close();
        }
        public static void prazniListbox(ListBox l)
        {
            l.Items.Clear();
            for (int i = 1; i <= 14; i++)
            {
                l.Items.Add($"{i}.");
            }
        }
        public static void unselectComboBox(ComboBox c)
        {
            c.SelectedIndex = -1;
        }
        public static void gumbSlika(Button b,string s)
        {
            b.BackgroundImage = Image.FromFile($@"..\slike\{s}");
            b.BackgroundImageLayout = ImageLayout.Zoom;
        }
    }
}

