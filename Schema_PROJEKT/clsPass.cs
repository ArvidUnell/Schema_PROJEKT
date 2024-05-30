using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema_PROJEKT
{
    public class clsPass
    {
        public clsPass(TimeOnly starttid, TimeOnly sluttid, string namn, string övrigt) 
        {
            this.starttid = starttid;
            this.sluttid = sluttid;
            this.namn = namn;
            this.övrigt = övrigt;
        }

        TimeOnly starttid;
        TimeOnly sluttid;
        string namn;
        string övrigt;
        public TimeOnly Starttid
        {
            get { return starttid; }
            set { starttid = value; }
        }
        public TimeOnly Sluttid
        {
            get { return sluttid; }
            set { sluttid = value; }
        }
        public string Namn
        {
            get { return namn; }
            set { namn = value; }
        }
        public string Övrigt
        {
            get { return övrigt; }
            set { övrigt = value; }
        }
    }
}
