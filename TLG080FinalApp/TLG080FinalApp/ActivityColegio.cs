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
    [Activity(Label = "ActivityColegio")]
    public class ActivityColegio : AppCompatActivity
    {
        ImageView addColegio;
        ListView listaColegio;
        FragmentColegio fragmentColegio;

        List<ColegioInnerJoin> datosCole;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.colegiomain);

            addColegio = FindViewById<ImageView>(Resource.Id.btnModalColegio);
            listaColegio = FindViewById<ListView>(Resource.Id.listColegio);

            ListadoColegio();
     
            addColegio.Click += AddColegio_Click;
        }

        private void AddColegio_Click(object sender, EventArgs e)
        {
            fragmentColegio = new FragmentColegio();
            var trans = SupportFragmentManager.BeginTransaction();
            fragmentColegio.Show(trans, "new colegio");
        }

        public void ListadoColegio()
        {
            datosCole = Global.ListaCole();
            AdapterColegio adapter = new AdapterColegio(this, datosCole);
            listaColegio.Adapter = adapter;
        }
    }
}