using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Biblioteka.Modeli;
using Biblioteka.Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotekaAndroid
{
    [Activity(Label = "Opis knjige")]
    public class KnjigaOpisActivity : Activity
    {
        private TextView tvNaslov;
        private TextView tvAutor;
        private TextView tvGodinaIzdanja;
        private TextView tvBrojPrimeraka;
        private EditText etBrojPrimeraka;
        private Button btnOtkazi;
        private Button btnIznajmi;

        private BibliotekaServis bibliotekaServis;
        private Knjiga knjiga;

        //

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.KnjigaOpisView);

            FindViews();
            bibliotekaServis = new BibliotekaServis();
            knjiga = bibliotekaServis.KnjigaZaId(2);
            UcitajViews();

            DodeliDogadjaje();

            // Create your application here
        }
        private void FindViews()
        {
            tvNaslov = FindViewById<TextView>(Resource.Id.tvNaslov);
            tvAutor = FindViewById<TextView>(Resource.Id.tvAutor);
            tvGodinaIzdanja = FindViewById<TextView>(Resource.Id.tvGodinaIzdanja);
            tvBrojPrimeraka = FindViewById<TextView>(Resource.Id.tvBrojDostupnihKnjiga);
            etBrojPrimeraka = FindViewById<EditText>(Resource.Id.etBrojKnjiga);
            btnOtkazi = FindViewById<Button>(Resource.Id.btnOtkazi);
            btnIznajmi = FindViewById<Button>(Resource.Id.btnIznajmi);
        }

        private void UcitajViews()
        {
            tvNaslov.Text = knjiga.Naslov;
            tvAutor.Text = knjiga.Autor;
            tvGodinaIzdanja.Text = (knjiga.GodinaIzdanja).ToString();
            tvBrojPrimeraka.Text = (knjiga.UkupanBrojPrimeraka - knjiga.IzdatiBrojPrimeraka).ToString();
        }

        private void DodeliDogadjaje()
        {
            btnIznajmi.Click += BtnIznajmi_Click;
            btnOtkazi.Click += BtnOtkazi_Click;
        }

        private void BtnOtkazi_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnIznajmi_Click(object sender, EventArgs e)
        {
            var br_knjiga = int.Parse(etBrojPrimeraka.Text);
            var poruka = "";
            if(knjiga.UkupanBrojPrimeraka - knjiga.IzdatiBrojPrimeraka - br_knjiga < 0)
            {
                poruka = "Ne moze se iznajmiti vise knjiga od dostupnih!";
            }
            else
            {
                knjiga.IzdatiBrojPrimeraka += br_knjiga;
                tvBrojPrimeraka.Text = (knjiga.UkupanBrojPrimeraka - knjiga.IzdatiBrojPrimeraka).ToString();
                poruka = $"Iznajmili ste {br_knjiga} knjiga";
            }

            var alert = new AlertDialog.Builder(this);
            alert.SetTitle("Iznajmljivanje");
            alert.SetMessage(poruka);
            alert.Show();
        }
    }
}