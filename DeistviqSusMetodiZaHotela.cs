using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisiTediPraktika10g
{
    class DeistviqSusMetodiZaHotela
    {
        public static void Rezervation(int num,string type, int capacity,double price,bool occ,string nameG)
        {
            if (occ==false)
            {
                occ = true;
            }
            else
            {
                throw new ArgumentException("Тази стая е вече резервирана, изберете друга!");
            }
        }
    }
}
