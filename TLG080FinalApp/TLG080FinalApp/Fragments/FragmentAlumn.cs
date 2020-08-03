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
    public class FragmentAlumn : Android.Support.V4.App.DialogFragment
    {
        TextInputLayout txtInputNombre;
        TextInputLayout txtInputApellido;
        TextInputLayout txtInputSexo;
        TextInputLayout txtInputTelefono;
        TextInputLayout txtInputEmail;
        MaterialSpinner FkGradoSpinner;
        Button btnGuardarAlumno;


        ActivityAlumno activity;


        public static webservice servicio = new webservice();
        int FkGrado;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            activity = (ActivityAlumno)this.Activity;
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.alumnonew, container, false);

            txtInputNombre = view.FindViewById<TextInputLayout>(Resource.Id.txtaddNombre);
            txtInputApellido = view.FindViewById<TextInputLayout>(Resource.Id.txtaddApellido);
            txtInputSexo = view.FindViewById<TextInputLayout>(Resource.Id.txtaddSexo);
            txtInputTelefono = view.FindViewById<TextInputLayout>(Resource.Id.txtaddTelefono);
            txtInputEmail = view.FindViewById<TextInputLayout>(Resource.Id.txtaddEmail);
            FkGradoSpinner = view.FindViewById<MaterialSpinner>(Resource.Id.spinnerGrado);

            btnGuardarAlumno = view.FindViewById<Button>(Resource.Id.btnaddAlumno);

           

            CargarGrado();
            FkGradoSpinner.ItemSelected += FkGradoSpinner_ItemSelected;
            btnGuardarAlumno.Click += BtnGuardarAlumno_Click;



            return view;
        }

        private void BtnGuardarAlumno_Click(object sender, EventArgs e)
        {
            SupportV7.AlertDialog.Builder saveDataAlert = new SupportV7.AlertDialog.Builder(Activity);
            saveDataAlert.SetTitle("Guardar Grado");
            saveDataAlert.SetMessage("¿Esta seguro?");
            saveDataAlert.SetPositiveButton("Si", (senderAlert, args) =>
            {
                if (txtInputNombre.EditText.Text == "")
                {
                    Toast.MakeText(Activity, "Error!, los campos no pueden estar vacios", ToastLength.Short).Show();
                }
                else
                {
                    if (Global.AgregarAlumno(txtInputNombre.EditText.Text, txtInputApellido.EditText.Text, txtInputSexo.EditText.Text, txtInputTelefono.EditText.Text, txtInputEmail.EditText.Text, FkGrado))
                    {
                        Toast.MakeText(Activity, "Se ha guardado correctamente el registro", ToastLength.Short).Show();
                        activity.ListadoAlumno();

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

        private void FkGradoSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (e.Position != -1)
            {
                FkGrado = Global.ListaSpinnerGrado()[e.Position]._Id;

            }
        }

        private void CargarGrado()
        {
            var tempGrado = (List<GradoSW>)servicio.ListaSpinnerGrado().ToList();
            var grado = tempGrado.Select(x => x._Descripcion).ToList();
            var adapter = new ArrayAdapter<string>(activity, Android.Resource.Layout.SimpleSpinnerDropDownItem, grado);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            FkGradoSpinner.Adapter = adapter;
        }
    }
}