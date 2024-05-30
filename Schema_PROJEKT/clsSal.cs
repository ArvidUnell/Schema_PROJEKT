using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema_PROJEKT
{
    public class clsSal
    {
        public clsSal(string namn, int platser, string övrigt) 
        {
            this.namn = namn;
            this.platser = platser;
            this.övrigt = övrigt;
        }

        string namn;
        int platser;
        string övrigt;
        public string Namn
        {
            get { return namn; }
            set { namn = value; }
        }
        public int Platser
        {
            get { return platser; }
            set
            {
                if(value < 0)
                {
                    platser = 0;
                }
                else
                {
                    platser = value;
                }
            }
        }
        public string Övrigt
        {
            get { return övrigt; }
            set { övrigt = value; }
        }

        Dictionary<DateOnly, List<clsPass>> dagLista = new Dictionary<DateOnly, List<clsPass>>();
        public Dictionary<DateOnly, List <clsPass>> DagLista
        {
            get { return dagLista; }
            set { dagLista = value; }
        }
    }
}
