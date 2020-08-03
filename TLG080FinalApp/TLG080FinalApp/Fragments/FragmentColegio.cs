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
    public class FragmentColegio : Android.Support.V4.App.DialogFragment
    {
        TextInputLayout txtInputCole;
        MaterialSpinner FkDepart;
        MaterialSpinner FkAnio;
        Button btnGuardarCole;

        ActivityColegio activity;


        public static webservice servicio = new webservice();
        int FkDepartamento;
        int FkAnioElec;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            activity = (ActivityColegio)this.Activity;
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.colegionew, container, false);

            txtInputCole = view.FindViewById<TextInputLayout>(Resource.Id.txtaddColegio);
            FkDepart = view.FindViewById<MaterialSpinner>(Resource.Id.spinnerDepar);
            FkAnio = view.FindViewById<MaterialSpinner>(Resource.Id.spinnerAnioElec);
            btnGuardarCole = view.FindViewById<Button>(Resource.Id.btnaddColegio);

            btnGuardarCole.Click += BtnGuardarCole_Click;

            CargarDepartamento();
            CargarAnioElectivo();


            FkDepart.ItemSelected += FkDepart_ItemSelected;
            FkAnio.ItemSelected += FkAnio_ItemSelected;


            return view;
        }

        private void CargarAnioElectivo()
        {
            var tempAnioElec = (List<AnioElectivoSW>)servicio.ListaAnioElectivo().ToList();
            var anioElectivo = tempAnioElec.Select(x => x._Descripcion).ToList();
            var adapter = new ArrayAdapter<string>(activity, Android.Resource.Layout.SimpleSpinnerDropDownItem, anioElectivo);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            FkAnio.Adapter = adapter;
        }

        public void CargarDepartamento()
        {
            var tempDepartamento = (List<DepartamentoSW>)servicio.ListaDepartamento().ToList();
            var departamento = tempDepartamento.Select(x => x.NomDepartamento).ToList();
            var adapter = new ArrayAdapter<string>(activity, Android.Resource.Layout.SimpleSpinnerDropDownItem, departamento);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            FkDepart.Adapter = adapter;

        }

        private void FkDepart_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            //var spinner = (MaterialSpinner)sender;
            //FkDepartamento = string.Format("{0}", spinner.GetItemAtPosition(DepartList[e.Position].Id));
            if (e.Position != -1)
            {
                FkDepartamento = Global.ListaDepar()[e.Position].Id;
            }


            //var tempDepartamento = (List<DepartamentoSW>)servicio.ListaDepartamento().ToList();
            //var departamento = tempDepartamento.Where(x => x.Id == FkDepartamento);

        }

        private void FkAnio_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            if (e.Position != -1)
            {
                FkAnioElec = Global.ListaAnio()[e.Position]._Id;

            }

        }
        private void BtnGuardarCole_Click(object sender, EventArgs e)
        {
            SupportV7.AlertDialog.Builder saveDataAlert = new SupportV7.AlertDialog.Builder(Activity);
            saveDataAlert.SetTitle("Guardar Colegio");
            saveDataAlert.SetMessage("¿Esta seguro?");
            saveDataAlert.SetPositiveButton("Si", (senderAlert, args) =>
            {
                if (txtInputCole.EditText.Text == "")
                {
                    Toast.MakeText(Activity, "Error!, los campos no pueden estar vacios", ToastLength.Short).Show();
                }
                else
                {
                    if (Global.AgregarCole(txtInputCole.EditText.Text, FkDepartamento, FkAnioElec))
                    {
                        Toast.MakeText(Activity, "Se ha guardado correctamente el registro", ToastLength.Short).Show();
                        activity.ListadoColegio();

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