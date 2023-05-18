using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Management_DavidT
{
    public class Ponavljanja
    {
        private int id;
        private string vrsta;
        public Ponavljanja() { }
        public Ponavljanja(int id, string vrsta)
        {
            this.id = id;
            this.vrsta = vrsta;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Vrsta
        {
            get { return vrsta; }
            set { vrsta = value; }
        }
    }
}
