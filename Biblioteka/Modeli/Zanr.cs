using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Modeli
{
    public class Zanr
    {
        public static int id = 1;
        public int Id { get; private set; }
        public string Naziv { get; set; }
        public List<Knjiga> knjige { get; set; }

        public Zanr()
        {
            Id = id++;
            knjige = new List<Knjiga>();
        }
    }
}
