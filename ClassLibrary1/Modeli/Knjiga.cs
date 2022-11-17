using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Modeli
{
    public class Knjiga
    {
        private static int id = 1;
        private int idd;
        public int Id
        {
            get
            {
                return idd;
            }
            set
            {
                if (id > value)
                    throw new Exception("****** Nedozvoljen id!");
                idd = value;
            }
        }
        public string Naslov { get; set; }
        public string Autor { get; set; }
        public int GodinaIzdanja { get; set; }
        public int UkupanBrojPrimeraka { get; set; }
        public int IzdatiBrojPrimeraka { get; set; }
        public Knjiga()
        {
            Id = id++;
        }
    }
}
