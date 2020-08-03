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

namespace TLG080FinalApp.Fragments
{
    public class FragmentAnioElectivo : Android.Support.V4.App.DialogFragment
    {
        TextInputLayout txtInputDescrip;
        TextInputLayout txtInputSemestre;
        Button guardarAnioElec;

        ActivityAnioElecti activity;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            activity = (ActivityAnioElecti)this.Activity;
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.anioelectivonew, container, false);

            txtInputDescrip = view.FindViewById<TextInputLayout>(Resource.Id.txtDescripcion);
            txtInputSemestre = view.FindViewById<TextInputLayout>(Resource.Id.txtSemestre);
            guardarAnioElec = view.FindViewById<Button>(Resource.Id.btnAddAnioelec);

            guardarAnioElec.Click += GuardarAnioElec_Click;

            return view;
        }

        private void GuardarAnioElec_Click(object sender, EventArgs e)
        {
            SupportV7.AlertDialog.Builder saveDataAlert = new SupportV7.AlertDialog.Builder(Activity);
            saveDataAlert.SetTitle("Guardar AñoElectivo");
            saveDataAlert.SetMessage("¿Esta seguro?");
            saveDataAlert.SetPositiveButton("Si", (senderAlert, args) =>
            {
                if (txtInputDescrip.EditText.Text == "" || txtInputSemestre.EditText.Text=="")
                {
                    Toast.MakeText(Activity, "Error!, los campos no pueden estar vacios", ToastLength.Short).Show();
                }
                else
                {

                    if (Global.AgregarAnio(txtInputDescrip.EditText.Text, txtInputSemestre.EditText.Text))
                    {
                        Toast.MakeText(Activity, "Se ha guardado correctamente el registro", ToastLength.Short).Show();
                        activity.ListadoAnioElec();

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
    }
}