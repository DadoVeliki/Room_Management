using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Management_DavidT
{
    public class Vremena
    {
        private int id;
        private DateTime pocetak;
        public Vremena() { }
        public Vremena(int id, DateTime pocetak)
        {
            this.id = id;
            this.pocetak = pocetak;
        }
        public int Id { get { return id; } set { id = value; } }
        public DateTime Pocetak
        {
            get { return pocetak; }
            set { pocetak = value; }
        } 
    }
}
