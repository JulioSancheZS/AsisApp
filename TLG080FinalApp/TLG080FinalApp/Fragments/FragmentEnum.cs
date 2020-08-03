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
    public class FragmentEnum : Android.Support.V4.App.DialogFragment
    {
        TextInputLayout txtInputEnum;   
        Button guardarEnum;
        ActivityEnum activity;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            activity = (ActivityEnum)this.Activity;
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.emunnew, container, false);

            txtInputEnum = view.FindViewById<TextInputLayout>(Resource.Id.txtaddEnum);
            guardarEnum = view.FindViewById<Button>(Resource.Id.btnaddEnum);

            guardarEnum.Click += GuardarEnum_Click;

            return view;
        }

        private void GuardarEnum_Click(object sender, EventArgs e)
        {
            SupportV7.AlertDialog.Builder saveDataAlert = new SupportV7.AlertDialog.Builder(Activity);
            saveDataAlert.SetTitle("Guardar Tipo Asistencia");
            saveDataAlert.SetMessage("¿Esta seguro?");
            saveDataAlert.SetPositiveButton("Si", (senderAlert, args) =>
            {
                if (txtInputEnum.EditText.Text == "" )
                {
                    Toast.MakeText(Activity, "Error!, los campos no pueden estar vacios", ToastLength.Short).Show();
                }
                else
                {

                    if (Global.AgregarEnum(txtInputEnum.EditText.Text))
                    {
                        Toast.MakeText(Activity, "Se ha guardado correctamente el registro", ToastLength.Short).Show();
                        activity.ListadoEnum();

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