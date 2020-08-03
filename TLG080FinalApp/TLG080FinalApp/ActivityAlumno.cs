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
    [Activity(Label = "ActivityAlumno")]
    public class ActivityAlumno : AppCompatActivity
    {
        ImageView addAlumno;
        ListView listaAlumno;
        FragmentAlumn fragmentAlumno;
        List<AlumnoInnerJoin> datosAlumno;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.alumnomain);
            // Create your application here
            addAlumno = FindViewById<ImageView>(Resource.Id.btnModalAlumno);
            listaAlumno = FindViewById<ListView>(Resource.Id.listAlumno);
            addAlumno.Click += AddAlumno_Click;
            ListadoAlumno();
        }

        private void AddAlumno_Click(object sender, EventArgs e)
        {
            fragmentAlumno = new FragmentAlumn();
            var trans = SupportFragmentManager.BeginTransaction();
            fragmentAlumno.Show(trans, "new Alumno");
        }

        public void ListadoAlumno()
        {
            datosAlumno = Global.ListaAlumno();
            AdapterAlumno adapter = new AdapterAlumno(this, datosAlumno);
            listaAlumno.Adapter = adapter;
        }
    }
}