using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SupportV7 = Android.Support.V7.App;
using TLG080FinalApp.com.somee.asisappbackend;
using Android.Support.Design.Widget;
using FR.Ganfra.Materialspinner;

namespace TLG080FinalApp.Fragments
{
    public class FragmentGrado : Android.Support.V4.App.DialogFragment
    {
        TextInputLayout txtInputGrado;
        MaterialSpinner FkCole;
        Button btnGuardarGrado;

        ActivityGrado activity;


        public static webservice servicio = new webservice();
        int FkColegio;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            activity = (ActivityGrado)this.Activity;
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.gradonew, container, false);

            txtInputGrado = view.FindViewById<TextInputLayout>(Resource.Id.txtaddnomGrado);
            FkCole = view.FindViewById<MaterialSpinner>(Resource.Id.spinnerColegioFK);

            btnGuardarGrado = view.FindViewById<Button>(Resource.Id.btnaddNewGrado);

            FkCole.ItemSelected += FkCole_ItemSelected;

            btnGuardarGrado.Click += BtnGuardarGrado_Click;
            CargarColegio();

            return view;
        }

        private void BtnGuardarGrado_Click(object sender, EventArgs e)
        {
            try
            {

                SupportV7.AlertDialog.Builder saveDataAlert = new SupportV7.AlertDialog.Builder(Activity);
                saveDataAlert.SetTitle("Guardar Grado");
                saveDataAlert.SetMessage("¿Esta seguro?");
                saveDataAlert.SetPositiveButton("Si", (senderAlert, args) =>
                {
                    if (txtInputGrado.EditText.Text == "")
                    {
                        Toast.MakeText(Activity, "Error!, los campos no pueden estar vacios", ToastLength.Short).Show();
                    }
                    else
                    {
                        if (Global.AgregarGrado(txtInputGrado.EditText.Text, FkColegio))
                        {
                            Toast.MakeText(Activity, "Se ha guardado correctamente el registro", ToastLength.Short).Show();
                            activity.ListadoGrado();

                        }
                    }

                    this.Dismiss();
                });
                saveDataAlert.SetNegativeButton("Cancel", (senderAlert, args) =>
                {
                    saveDataAlert.Dispose();
                });

                saveDataAlert.Show();
            }
            catch (Exception)
            {

                Toast.MakeText(Activity, "Algo anda mal", ToastLength.Short).Show();
            }
        }

        private void FkCole_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (e.Position != -1)
            {
                FkColegio = Global.ListColeSpinner()[e.Position]._Id;
            }
        }

        private void CargarColegio()
        {
            var tempColegio = (List<ColegioSW>)servicio.ListaSpinnerCole().ToList();
            var colegio = tempColegio.Select(x => x._NomColegio).ToList();
            var adapter = new ArrayAdapter<string>(activity, Android.Resource.Layout.SimpleSpinnerDropDownItem, colegio);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            FkCole.Adapter = adapter;
        }
    }
}