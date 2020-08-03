using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace TLG080FinalApp
{
    [Activity(Label = "ActivityDashboard")]
    public class ActivityDashboard : Activity
    {
        CardView btnAlumno;
        CardView btnAsistencia;
        CardView btnMateria;
        CardView btnCatalogo;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.layout_dashboard);
            btnCatalogo = FindViewById<CardView>(Resource.Id.btnCatalogos);
            btnMateria = FindViewById<CardView>(Resource.Id. btnMateria);
            btnAlumno = FindViewById<CardView>(Resource.Id.btnAlumno);
            btnAsistencia = FindViewById<CardView>(Resource.Id.btnAsistencia);

            btnCatalogo.Click += BtnCatalogo_Click;
            btnMateria.Click += BtnMateria_Click;
            btnAlumno.Click += BtnAlumno_Click;
            btnAsistencia.Click += BtnAsistencia_Click;
        }

        private void BtnAsistencia_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityAsistencia));
            StartActivity(i);
        }

        private void BtnAlumno_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityAlumno));
            StartActivity(i);
        }

        private void BtnMateria_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityMateria));
            StartActivity(i);
        }

        private void BtnCatalogo_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityCatalogos));
            StartActivity(i);
        }
    }
}