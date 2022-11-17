using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Biblioteka.Android.PomocniFajlovi;
using Biblioteka.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotekaAndroid.Adapteri
{
    class KnjigeListaAdapter : BaseAdapter<Knjiga>
    {

        private Activity context;
        private List<Knjiga> sveKnjige;

        public KnjigeListaAdapter(Activity context, List<Knjiga> sveKnjige)
        {
            this.context = context;
            this.sveKnjige = sveKnjige;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Knjiga this[int position]
        {
            get
            {
                return sveKnjige[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            // I NACIN
            //if(view == null)
            //{
            //    view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            //}

            //TextView tv = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            //tv.Text = sveKnjige[position].Naslov;

            // II NACIN
            //if(view == null)
            //{
            //    view = context.LayoutInflater.Inflate(Android.Resource.Layout.ActivityListItem, null);
            //}

            //TextView tv = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            //ImageView iv = view.FindViewById<ImageView>(Android.Resource.Id.Icon);
            //tv.Text = sveKnjige[position].Naslov;
            //iv.SetImageBitmap(SlikaInternet.VratiSlikuZaUrl(sveKnjige[position].Slika));

            // II NACIN
            if (view == null)
            {
                view = context.LayoutInflater.Inflate(BibliotekaAndroid.Resource.Layout.KnjigaRedView, null);
            }

            var tvNaslovRow = view.FindViewById<TextView>(BibliotekaAndroid.Resource.Id.tvNaslovRow);
            var tvAutorRow = view.FindViewById<TextView>(BibliotekaAndroid.Resource.Id.tvAutorRow);
            var tvBrojPrimerakaRow = view.FindViewById<TextView>(BibliotekaAndroid.Resource.Id.tvBrojPrimerakaRow);
            var ivSlikaRow = view.FindViewById<ImageView>(BibliotekaAndroid.Resource.Id.ivSlikaRow);
            tvNaslovRow.Text = sveKnjige[position].Naslov;
            tvAutorRow.Text = sveKnjige[position].Autor;
            tvBrojPrimerakaRow.Text = (sveKnjige[position].UkupanBrojPrimeraka - sveKnjige[position].IzdatiBrojPrimeraka).ToString();
            tvNaslovRow.Text = sveKnjige[position].Naslov;
            ivSlikaRow.SetImageBitmap(SlikaInternet.VratiSlikuZaUrl(sveKnjige[position].Slika));

            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return sveKnjige.Capacity;
            }
        }

    }

    class KnjigeListaAdaptersViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}