using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using TLG080FinalApp.Adapter;
using TLG080FinalApp.com.somee.asisappbackend;
using TLG080FinalApp.Fragments;

namespace TLG080FinalApp
{
    [Activity(Label = "ActivityAnioElecti")]
    public class ActivityAnioElecti : AppCompatActivity
    {
        ImageView addAnioElec;
        ListView listaAnioElec;
        FragmentAnioElectivo fragmentAnioElectivo;

        List<AnioElectivoSW> datosAnioEle;
       

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.anioelectivomain);

            addAnioElec = FindViewById<ImageView>(Resource.Id.addAnioElec);
            listaAnioElec = FindViewById<ListView>(Resource.Id.listAnioelectivo);

            ListadoAnioElec();

            addAnioElec.Click += AddAnioElec_Click;
        }

        public void ListadoAnioElec()
        {
            datosAnioEle = Global.ListaAnio();
            AdapterAnioElectivo adapterAnioElectivo = new AdapterAnioElectivo(this,datosAnioEle);
            listaAnioElec.Adapter = adapterAnioElectivo;
        }

        private void AddAnioElec_Click(object sender, EventArgs e)
        {
            fragmentAnioElectivo = new FragmentAnioElectivo();
            var trans = SupportFragmentManager.BeginTransaction();
            fragmentAnioElectivo.Show(trans, "new anioElec");
        }
    }
}