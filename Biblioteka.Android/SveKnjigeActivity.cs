using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Biblioteka.Modeli;
using Biblioteka.Servis;
using BibliotekaAndroid.Adapteri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotekaAndroid
{
    [Activity(Label = "Sve Knjige", MainLauncher = true)]
    public class SveKnjigeActivity : Activity
    {
        private List<Knjiga> sveKnjige;
        private ListView lvSveKnjige;
        private BibliotekaServis bibliotekaServis;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SveKnjigeView);
            bibliotekaServis = new BibliotekaServis();
            sveKnjige = bibliotekaServis.SveKnjige();
            lvSveKnjige = FindViewById<ListView>(Resource.Id.lvSveKnjige);
            lvSveKnjige.Adapter = new KnjigeListaAdapter(this, sveKnjige);
            lvSveKnjige.ItemClick += LvSveKnjige_ItemClick;

            // Create your application here
        }

        private void LvSveKnjige_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent intent = new Intent();
            intent.SetClass(this, typeof(KnjigaOpisActivity));
        }
    }
}