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
    [Activity(Label = "ActivityGrado")]
    public class ActivityGrado : AppCompatActivity
    {


        ImageView addGrado;
        ListView listagrado;
        FragmentGrado fragmentGrado;
        List<GradoInnerJoin> datosGrado;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.gradomain);
            addGrado = FindViewById<ImageView>(Resource.Id.btnModalGrado);
            listagrado = FindViewById<ListView>(Resource.Id.listGrado);
            // Create your application here
            addGrado.Click += AddGrado_Click;
            ListadoGrado();
        }

        private void AddGrado_Click(object sender, EventArgs e)
        {
            fragmentGrado = new FragmentGrado();
            var trans = SupportFragmentManager.BeginTransaction();
            fragmentGrado.Show(trans, "new grado");
        }

        public void ListadoGrado()
        {
            datosGrado = Global.ListaGrado();
            AdapterGrado adapter = new AdapterGrado(this, datosGrado);
            listagrado.Adapter = adapter;
        }
    }
}