using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using SupportV7 = Android.Support.V7.App;
using TLG080FinalApp.com.somee.asisappbackend;

namespace TLG080FinalApp.Fragments
{
    public class FragmentDepartamento : Android.Support.V4.App.DialogFragment
    {
        TextInputLayout txtInputDepar;
        Button guardarDepart;

        ActivityDepartamento activity;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            activity = (ActivityDepartamento)this.Activity;

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.layout_newdepartamento, container, false);

            txtInputDepar = view.FindViewById<TextInputLayout>(Resource.Id.txtInputDepart);
            guardarDepart = view.FindViewById<Button>(Resource.Id.guardarDepart);

            guardarDepart.Click += GuardarDepart_Click;

            return view;
        }

        private void GuardarDepart_Click(object sender, EventArgs e)
        {
            SupportV7.AlertDialog.Builder saveDataAlert = new SupportV7.AlertDialog.Builder(Activity);
            saveDataAlert.SetTitle("Guardar Departamento");
            saveDataAlert.SetMessage("¿Esta seguro?");
            saveDataAlert.SetPositiveButton("Si", (senderAlert, args) =>
            {
                if (txtInputDepar.EditText.Text == "")
                {
                    Toast.MakeText(Activity, "Error!, los campos no pueden estar vacios", ToastLength.Short).Show();
                }
                else
                {

                    if (Global.AgregarDepar(txtInputDepar.EditText.Text))
                    {
                        Toast.MakeText(Activity, "Se ha guardado correctamente el registro", ToastLength.Short).Show();
                        activity.ListadoDepart();

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