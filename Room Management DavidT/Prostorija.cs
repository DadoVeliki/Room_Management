using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Management_DavidT
{
    public class Prostorija
    {
        private int id;
        private string prostorija;
        public Prostorija() { }
        public Prostorija(int id, string prostorija)
        {
            this.id = id;
            this.prostorija = prostorija;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Prostorij
        {
            get { return prostorija; }
            set { prostorija = value; }
        }
    }
}
