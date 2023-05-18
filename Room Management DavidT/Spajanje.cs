using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Room_Management_DavidT
{
    public class Spajanje
    {   public SqlConnection cnn;
        string putanja = @"..\konfiguracijska\config.txt";
        public Spajanje()
        {
            kreacijaConfig();
            string[] lines = File.ReadAllLines(putanja);
            string cs;
            //cs = $@"Data Source={lines[0].Substring(3)},{lines[1].Substring(5)}\SQLEXPRESS;Initial Catalog=room_management;User ID={lines[2].Substring(8)};Password={lines[3].Substring(9)}";
            cs = @"Data Source=localhost\sqldado;Initial Catalog=rmg;User ID=adminRM;Password=123";
            cnn = new SqlConnection(cs);
        }
        public static Spajanje instance = null;
        public static Spajanje GetInstance()
        {
            if(instance == null)
            {
                instance = new Spajanje();
            }
            return instance;
        }
        public void kreacijaConfig()
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
                        //string pw = Moje.CreateMD5("12345");
                        sw.Write($"IP:192.168.43.180\nPORT:51302\nUSER ID:room_mng\nPASSWORD:12345");
                        sw.Flush();
                        sw.Close();
                        fs.Close();
                        //FileStream op = File.Open(putanja + "config.txt", FileMode.Open, FileAccess.Write);
                        //Konfig k = new Konfig();
                        //k.ShowDialog();
                    }
                    else
                    {
                        //FileStream op = File.Open(putanja + "config.txt", FileMode.Open,FileAccess.Write);

                    }
                }
                //Konfig k = new Konfig();
                //k.ShowDialog();
                //File.Open(putanja + "config.txt", FileMode.Open);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
        }
        
    }
}
