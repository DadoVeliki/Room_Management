using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Management_DavidT
{
    public class User
    {
        private int id;
        private string username, password, fullname;
        private bool active;

        public User(int i,string u,string p,string f,bool a)
        {
            this.id = i;
            this.username = u;
            this.password = p;
            this.fullname = f;
            this.active = a;
        }

        public int getid()
        {
            return this.id;
        }
        public string getun()
        {
            return this.username;
        }
        public string getpw()
        {
            return this.password;
        }
        public string getfn()
        {
            return this.fullname;
        }
        public bool getact()
        {
            return this.active;
        }
    }
}
