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
    [Activity(Label = "ActivityMateria")]
    public class ActivityMateria : AppCompatActivity
    {
        ImageView addMateria;
        ListView listamateria;
        FragmentMateria fragmentMateria;

        List<MateriaInnerJoin> datosMateria;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.materiamain);

            addMateria = FindViewById<ImageView>(Resource.Id.btnModalMateria);
            listamateria = FindViewById<ListView>(Resource.Id.listMateria);

            ListadoMateria();
            // Create your application here
            addMateria.Click += AddMateria_Click;
        }

        private void AddMateria_Click(object sender, EventArgs e)
        {
            fragmentMateria = new FragmentMateria();
            var trans = SupportFragmentManager.BeginTransaction();
            fragmentMateria.Show(trans, "new materia");
        }

        public void ListadoMateria()
        {
            datosMateria = Global.ListaMateria();
            AdapterMateria adapter = new AdapterMateria(this, datosMateria);
            listamateria.Adapter = adapter;
        }
    }
}