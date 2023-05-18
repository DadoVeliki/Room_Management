using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Management_DavidT
{
    public class UserPrava
    {
        private int id, userID, pravoID;
        private bool active;

        public UserPrava(int id,int u,int p,bool a)
        {
            this.id = id;
            this.userID = u;
            this.pravoID = p;
            this.active = a;
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
        public int PravoID
        {
            get { return pravoID; }
            set
            {
                pravoID = value;
            }
        }
        public bool Active
        {
            get { return active; }
            set
            {
                active = value;
            }
        }
    }
}
