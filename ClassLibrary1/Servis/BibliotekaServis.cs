using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Modeli;
using ClassLibrary1.Podaci;

namespace ClassLibrary1.Servis
{
    public class BibliotekaServis
    {
        private BibliotekaPodaci bibliotekaPodaci;
        public BibliotekaServis()
        {
            bibliotekaPodaci = new BibliotekaPodaci();
        }
        public List<Knjiga> SveKnjige()
        {
            return bibliotekaPodaci.SveKnjige();
        }
        public Knjiga KnjigaZaId(int id)
        {
            return bibliotekaPodaci.KnjigaZaId(id);
        }

        public List<Knjiga> KnjigeZaZanrId(int id)
        {
            return bibliotekaPodaci.KnjigeZaZanrId(id);
        }
        public List<Zanr> SviZanrovi()
        {
            return bibliotekaPodaci.SviZanrovi();
        }

        public List<Knjiga> DostupneKnjige()
        {
            return bibliotekaPodaci.DostupneKnjige();
        }
    }
}
