using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Management_DavidT
{
    public class Rezervacije
    {
        private int id, userID, pocetakID, krajID, prostorijaID, ponavljanjeID;
        private DateTime datum;
        private bool aktivno;
        public Rezervacije() { }
        public Rezervacije(int id, DateTime datum, int userID, int pocetakID, int krajID, int prostorijaID, int ponavljanjeID, bool aktivno)
        {
            this.id = id;
            this.userID = userID;
            this.pocetakID = pocetakID;
            this.krajID = krajID;
            this.prostorijaID = prostorijaID;
            this.ponavljanjeID = ponavljanjeID;
            this.datum = datum;
            this.aktivno = aktivno;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public int PocetakID
        {
            get { return pocetakID; }
            set
            {
                pocetakID = value;
            }
        }
        public int KrajID
        {
            get { return krajID; }
            set
            {
                krajID = value;
            }
        }
        public int ProstorijaID
        {
            get { return prostorijaID; }
            set
            {
                prostorijaID = value;
            }
        }
        public int PonavljanjeID
        {
            get { return ponavljanjeID; }
            set
            {
                ponavljanjeID = value;
            }
        }
        public DateTime Datum
        {
            get { return datum; }
            set
            {
                datum = value;
            }
        }
        public bool Aktivno
        {
            get { return aktivno; }
            set
            {
                aktivno = value;
            }
        }
    }
}
