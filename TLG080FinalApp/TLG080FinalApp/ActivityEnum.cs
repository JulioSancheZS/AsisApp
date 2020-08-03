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
    [Activity(Label = "ActivityEnum")]
    public class ActivityEnum : AppCompatActivity
    {
        ImageView addEnumAsis;
        ListView listaenum;
        FragmentEnum fragmentEnum;

        List<EnumAsisSW> datosEnum;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.emunmain);
            addEnumAsis = FindViewById<ImageView>(Resource.Id.btnModalEnum);
            listaenum = FindViewById<ListView>(Resource.Id.listEnum);
            // Create your application here
            addEnumAsis.Click += AddEnumAsis_Click;
            ListadoEnum();
        }

        private void AddEnumAsis_Click(object sender, EventArgs e)
        {
            fragmentEnum = new FragmentEnum();
            var trans = SupportFragmentManager.BeginTransaction();
            fragmentEnum.Show(trans, "new Enum");
        }

        public void ListadoEnum()
        {
            datosEnum = Global.ListaEnum();
            AdapterEnum adapter = new AdapterEnum(this, datosEnum);
            listaenum.Adapter = adapter;
        }


    }
}