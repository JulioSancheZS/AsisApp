using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SupportV7 = Android.Support.V7.App;
using TLG080FinalApp.com.somee.asisappbackend;
using Android.Support.Design.Widget;
using FR.Ganfra.Materialspinner;
using Android.Util;

namespace TLG080FinalApp
{
    [Activity(Label = "ActivityAsistencia", Theme = "@style/AppTheme")]
    public class ActivityAsistencia : Activity
    {
        TextInputLayout txtInputAsistencia;
        MaterialSpinner FkAlumnoAsis;
        MaterialSpinner FkEnumAsis;
        Button btnGuardarAsistencia;
        Button btnModalFecha;

        public static webservice servicio = new webservice();
        int IdAlumnoSpinner;
        int IdEnumSpinner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.asistencianew);
            // Create your application here
            txtInputAsistencia = FindViewById<TextInputLayout>(Resource.Id.txtaddFecha);
            FkAlumnoAsis = FindViewById<MaterialSpinner>(Resource.Id.spinnerAlumnoAsis);
            FkEnumAsis = FindViewById<MaterialSpinner>(Resource.Id.spinnerEnumAsis);
            btnGuardarAsistencia = FindViewById<Button>(Resource.Id.btnaddAsistencia);
            btnModalFecha = FindViewById<Button>(Resource.Id.btnaddFecha);

            btnModalFecha.Click += BtnModalFecha_Click;
            FkAlumnoAsis.ItemSelected += FkAlumnoAsis_ItemSelected;
            FkAlumnoAsis.ItemSelected += FkAlumnoAsis_ItemSelected1;
            btnGuardarAsistencia.Click += BtnGuardarAsistencia_Click;
            CargarAlumno();
            CargarEnum();
        }

        private void FkAlumnoAsis_ItemSelected1(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (e.Position != -1)
            {//??? no tenia problamas
                IdEnumSpinner = Global.ListaEnum()[e.Position].Id;
            }
        }

        private void FkAlumnoAsis_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (e.Position != -1)
            {
                IdAlumnoSpinner = Global.ListaAlumno()[e.Position]._Id;
            }
        }

        private void BtnGuardarAsistencia_Click(object sender, EventArgs e)
        {
            SupportV7.AlertDialog.Builder saveDataAlert = new SupportV7.AlertDialog.Builder(this);
            saveDataAlert.SetTitle("Guardar Asistencia");
            saveDataAlert.SetMessage("¿Esta seguro?");
            saveDataAlert.SetPositiveButton("Si", (senderAlert, args) =>
            {
                if (txtInputAsistencia.EditText.Text == "")
                {
                    Toast.MakeText(this, "Error!, los campos no pueden estar vacios", ToastLength.Short).Show();
                }
                else
                {
                    if (Global.AgregarAsisten(DateTime.Parse( txtInputAsistencia.EditText.Text), IdAlumnoSpinner, IdEnumSpinner))
                    {
                        Toast.MakeText(this, "Se ha guardado correctamente el registro", ToastLength.Short).Show();
                        txtInputAsistencia.EditText.Text = "";
                    }
                }

            });
            saveDataAlert.SetNegativeButton("Cancel", (senderAlert, args) =>
            {
                saveDataAlert.Dispose();
            });

            saveDataAlert.Show();
        }

        private void CargarAlumno()
        {
            var tempAlumno = (List<AlumnoSW>)servicio.ListaSpinnerAlumno().ToList();
            var alumno = tempAlumno.Select(x => x._Nombre).ToList();
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, alumno);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            FkAlumnoAsis.Adapter = adapter;
        }

        public void CargarEnum()
        {
            var tempEmun = (List<EnumAsisSW>)servicio.ListaEnum().ToList();
            var Enumasis = tempEmun.Select(x => x.EnumAsis).ToList();
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, Enumasis);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            FkEnumAsis.Adapter = adapter;

        }

        private void BtnModalFecha_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                txtInputAsistencia.EditText.Text = time.ToShortDateString();
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        // Create a class DatePickerFragment  
        public class DatePickerFragment : DialogFragment,
            DatePickerDialog.IOnDateSetListener
        {
            // TAG can be any string of your choice.  
            public static readonly string TAG = "X:" + typeof(DatePickerFragment).Name.ToUpper();
            // Initialize this value to prevent NullReferenceExceptions.  
            Action<DateTime> _dateSelectedHandler = delegate { };
            public static DatePickerFragment NewInstance(Action<DateTime> onDateSelected)
            {
                DatePickerFragment frag = new DatePickerFragment();
                frag._dateSelectedHandler = onDateSelected;
                return frag;
            }
            public override Dialog OnCreateDialog(Bundle savedInstanceState)
            {
                DateTime currently = DateTime.Now;
                DatePickerDialog dialog = new DatePickerDialog(Activity, this, currently.Year, currently.Month, currently.Day);
                return dialog;
            }
            public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
            {
                // Note: monthOfYear is a value between 0 and 11, not 1 and 12!  
                DateTime selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
                Log.Debug(TAG, selectedDate.ToShortDateString());
                _dateSelectedHandler(selectedDate);
            }
        }
    }
}