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
    public class FragmentMateria : Android.Support.V4.App.DialogFragment
    {
        TextInputLayout txtInputMateria;
        MaterialSpinner FkAlumnoSpinner;
        Button btnGuardarMateria;

        ActivityMateria activity;

        public static webservice servicio = new webservice();
        int IdFkAlumno;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            activity = (ActivityMateria)this.Activity;
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.materianew, container, false);

            txtInputMateria = view.FindViewById<TextInputLayout>(Resource.Id.txtaddMateria);
            FkAlumnoSpinner = view.FindViewById<MaterialSpinner>(Resource.Id.spinnerAlumnoMateria);
            btnGuardarMateria = view.FindViewById<Button>(Resource.Id.btnaddMateria);

            FkAlumnoSpinner.ItemSelected += FkAlumnoSpinner_ItemSelected;
            btnGuardarMateria.Click += BtnGuardarMateria_Click;
            CargarAlumno();
 

            return view;
        }

        private void BtnGuardarMateria_Click(object sender, EventArgs e)
        {
            SupportV7.AlertDialog.Builder saveDataAlert = new SupportV7.AlertDialog.Builder(Activity);
            saveDataAlert.SetTitle("Guardar Colegio");
            saveDataAlert.SetMessage("¿Esta seguro?");
            saveDataAlert.SetPositiveButton("Si", (senderAlert, args) =>
            {
                if (txtInputMateria.EditText.Text == "")
                {
                    Toast.MakeText(Activity, "Error!, los campos no pueden estar vacios", ToastLength.Short).Show();
                }
                else
                {
                    if (Global.AgregarMateria(txtInputMateria.EditText.Text, IdFkAlumno))
                    {
                        Toast.MakeText(Activity, "Se ha guardado correctamente el registro", ToastLength.Short).Show();
                        activity.ListadoMateria();

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

        private void FkAlumnoSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (e.Position != -1)
            {
                IdFkAlumno = Global.ListaSpinnerAlumno()[e.Position]._Id;
            }
        }

        private void CargarAlumno()
        {
            var tempAlumno = (List<AlumnoSW>)servicio.ListaSpinnerAlumno().ToList();
            var alumno = tempAlumno.Select(x => x._Nombre).ToList();
            var adapter = new ArrayAdapter<string>(activity, Android.Resource.Layout.SimpleSpinnerDropDownItem, alumno);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            FkAlumnoSpinner.Adapter = adapter;
        }
    }
}