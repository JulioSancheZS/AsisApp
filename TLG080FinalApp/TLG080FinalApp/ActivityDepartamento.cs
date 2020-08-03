using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using TLG080FinalApp.Adapter;
using TLG080FinalApp.com.somee.asisappbackend;
using TLG080FinalApp.Fragments;

namespace TLG080FinalApp
{
    [Activity(Label = "Departamento")]
    public class ActivityDepartamento : AppCompatActivity
    {
        ListView listaDepar;
        ImageView addDepar;
        List<DepartamentoSW> datosDepar;

        FragmentDepartamento fragmentDepartamento;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

           
            SetContentView(Resource.Layout.layout_departamento);
            // Create your application here

            listaDepar = FindViewById<ListView>(Resource.Id.listadeparta);
            addDepar = FindViewById<ImageView>(Resource.Id.adddepartamento);

            ListadoDepart();

            addDepar.Click += AddDepar_Click;
        }

        public void ListadoDepart()
        {
            datosDepar = Global.ListaDepar();
            AdapterDepartamento adapter = new AdapterDepartamento(this, datosDepar);
            listaDepar.Adapter = adapter;
        }

        private void AddDepar_Click(object sender, EventArgs e)
        {
            fragmentDepartamento = new FragmentDepartamento();
            var trans = SupportFragmentManager.BeginTransaction();
            fragmentDepartamento.Show(trans, "new depart");
        }
    }
}