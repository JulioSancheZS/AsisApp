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
    [Activity(Label = "ActivityCatalogos")]
    public class ActivityCatalogos : Activity
    {
        CardView btnDepartamento;
        CardView btnAnioElectivo;
        CardView btnColegio;
        CardView btnGrado;
        CardView btnTipoAsis;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.layout_catalogos);

            btnDepartamento = FindViewById<CardView>(Resource.Id.btnCardDepartamento);
            btnAnioElectivo = FindViewById<CardView>(Resource.Id.btnCardAnioElectivo);
            btnColegio = FindViewById<CardView>(Resource.Id.btnCardColegios);
            btnGrado = FindViewById<CardView>(Resource.Id.btnCardGrado);
            btnTipoAsis = FindViewById<CardView>(Resource.Id.btnCardEnumAsis);


            btnDepartamento.Click += BtnDepartamento_Click;
            btnAnioElectivo.Click += BtnAnioElectivo_Click;
            btnColegio.Click += BtnColegio_Click;
            btnGrado.Click += BtnGrado_Click;
            btnTipoAsis.Click += BtnTipoAsis_Click;
        }

        private void BtnTipoAsis_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityEnum));
            StartActivity(i);
        }

        private void BtnGrado_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityGrado));
            StartActivity(i);
        }

        private void BtnColegio_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityColegio));
            StartActivity(i);
        }

        private void BtnAnioElectivo_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityAnioElecti));
            StartActivity(i);
        }

        private void BtnDepartamento_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityDepartamento));
            StartActivity(i);
        }
    }
}