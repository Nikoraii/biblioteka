using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Biblioteka.Android.PomocniFajlovi
{
    public class SlikaInternet
    {
        public static Bitmap VratiSlikuZaUrl(string url)
        {
            Bitmap bm = null;
            var webClient = new WebClient();
            var bajtovi = webClient.DownloadData(url);
            if(bajtovi != null && bajtovi.Length > 0)
            {
                bm = BitmapFactory.DecodeByteArray(bajtovi, 0, bajtovi.Length);
            }
            return bm;
        }
    }
}