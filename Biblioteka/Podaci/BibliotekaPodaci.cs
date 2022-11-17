using Biblioteka.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Podaci
{
    public class BibliotekaPodaci
    {
        private List<Zanr> zanrovi = new List<Zanr>()
        {
            new Zanr(){Naziv = "Roman",
            knjige = new List<Knjiga>()
            {
                new Knjiga()
                {
                    Naslov = "Prokleta Avlija",
                    Autor = "Ivo Andric",
                    GodinaIzdanja = 2010,
                    UkupanBrojPrimeraka = 40,
                    IzdatiBrojPrimeraka = 35,
                    Slika = "https://www.delfi.rs/_img/artikli/2015/05/prokleta_avlija_vv.jpg"
                },

                new Knjiga()
                {
                    Naslov = "Dervis i smrt",
                    Autor = "Mesa Selimovic",
                    GodinaIzdanja = 2000,
                    UkupanBrojPrimeraka = 20,
                    IzdatiBrojPrimeraka = 5,
                    Slika = "https://www.delfi.rs/_img/artikli/2015/05/prokleta_avlija_vv.jpg"
                },

                new Knjiga()
                {
                    Naslov = "Orlovi rano lete",
                    Autor = "Branko Copic",
                    GodinaIzdanja = 1980,
                    UkupanBrojPrimeraka = 27,
                    IzdatiBrojPrimeraka = 5,
                    Slika = "https://www.delfi.rs/_img/artikli/2015/05/prokleta_avlija_vv.jpg"
                },

                new Knjiga()
                {
                    Naslov = "Vreme smrti",
                    Autor = "Dobrica Cosic",
                    GodinaIzdanja = 2005,
                    UkupanBrojPrimeraka = 20,
                    IzdatiBrojPrimeraka = 5,
                    Slika = "https://www.delfi.rs/_img/artikli/2015/05/prokleta_avlija_vv.jpg"
                },

                new Knjiga()
                {
                    Naslov = "Hajduci",
                    Autor = "Branislav Nusic",
                    GodinaIzdanja = 1989,
                    UkupanBrojPrimeraka = 10,
                    IzdatiBrojPrimeraka = 0,
                    Slika = "https://www.delfi.rs/_img/artikli/2015/05/prokleta_avlija_vv.jpg"
                },

            }
            },
            new Zanr(){Naziv = "Komedija",
            knjige = new List<Knjiga>()
            {
                new Knjiga()
                {
                    Naslov = "Pokondirena tikva",
                    Autor = "Jovan Sterija Popovic",
                    GodinaIzdanja = 2004,
                    UkupanBrojPrimeraka = 40,
                    IzdatiBrojPrimeraka = 17,
                    Slika = "https://www.delfi.rs/_img/artikli/2015/05/prokleta_avlija_vv.jpg"
                },
                new Knjiga()
                {
                    Naslov = "Pop Cira i Pop Spira",
                    Autor = "Stevan Sremac",
                    GodinaIzdanja = 1986,
                    UkupanBrojPrimeraka = 10,
                    IzdatiBrojPrimeraka = 1,
                    Slika = "https://www.delfi.rs/_img/artikli/2015/05/prokleta_avlija_vv.jpg"
                },
                new Knjiga()
                {
                    Naslov = "Mletacki trgovac",
                    Autor = "Vilijam Sekspir",
                    GodinaIzdanja = 1980,
                    UkupanBrojPrimeraka = 15,
                    IzdatiBrojPrimeraka = 3,
                    Slika = "https://www.delfi.rs/_img/artikli/2015/05/prokleta_avlija_vv.jpg"
                },
                new Knjiga()
                {
                    Naslov = "Rat i Mir",
                    Autor = "Lav Tolstoj",
                    GodinaIzdanja = 1869,
                    UkupanBrojPrimeraka = 20,
                    IzdatiBrojPrimeraka = 5,
                    Slika = "https://www.delfi.rs/_img/artikli/2015/05/prokleta_avlija_vv.jpg"
                },
                new Knjiga()
                {
                    Naslov = "Ana Karenjina",
                    Autor = "Lav Tolstoj",
                    GodinaIzdanja = 1877,
                    UkupanBrojPrimeraka = 15,
                    IzdatiBrojPrimeraka = 5,
                    Slika = "https://www.delfi.rs/_img/artikli/2015/05/prokleta_avlija_vv.jpg"
                },
                new Knjiga()
                {
                    Naslov = "Zlocin i Kazna",
                    Autor = "Fjodr Dostojevski",
                    GodinaIzdanja = 1866,
                    UkupanBrojPrimeraka = 37,
                    IzdatiBrojPrimeraka = 10,
                    Slika = "https://www.delfi.rs/_img/artikli/2015/05/prokleta_avlija_vv.jpg"
                }
            }
            }
        };

        public List<Knjiga> SveKnjige()
        {
            var sve_knjige = from zanr in zanrovi
                             from knjiga in zanr.knjige
                             select knjiga;
            return sve_knjige.ToList();
        }
        public Knjiga KnjigaZaId(int id)
        {
            var sve_knjige = from zanr in zanrovi
                             from knjiga in zanr.knjige
                             where knjiga.Id == id
                             select knjiga;
            return sve_knjige.FirstOrDefault();
        }

        public List<Knjiga> KnjigeZaZanrId(int id)
        {
            var svi_zanrovi = zanrovi.Where(zanr => zanr.Id == id);
            if(svi_zanrovi != null)
            {
                return svi_zanrovi.FirstOrDefault().knjige;
            }
            return null;
        }
        public List<Zanr> SviZanrovi()
        {
            return zanrovi;
        }

        public List<Knjiga> DostupneKnjige()
        {
            var sve_knjige = from zanr in zanrovi
                             from knjiga in zanr.knjige
                             where knjiga.UkupanBrojPrimeraka > knjiga.IzdatiBrojPrimeraka
                             select knjiga;
            return sve_knjige.ToList();
        }
    }
}
