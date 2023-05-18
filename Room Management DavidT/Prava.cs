using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Management_DavidT
{
    public class Prava
    {
        private int id;
        private string naziv;
        public Prava() { }
        public Prava(int id, string naziv)
        {
            this.id = id;
            this.naziv = naziv;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Naziv
        {
             get { return naziv; }
            set { naziv = value; }
        }
    }
}
