using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using TLG080FinalApp.com.somee.asisappbackend;

namespace TLG080FinalApp
{
    [Activity(Label = "ActivityRegister")]
    public class ActivityRegister : Activity
    {

        TextInputLayout txtEmailRegister;
        TextInputLayout txtpPassRegister;
        TextInputLayout txtPassRegisterRepit;
        Button btnRegistrar;
        //ProgressBar progressBarRegis;
        ResultRegister flag;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.layout_register);


            txtEmailRegister = FindViewById<TextInputLayout>(Resource.Id.txtEmailRegister);
            txtpPassRegister = FindViewById<TextInputLayout>(Resource.Id.txtpPassRegister);
            txtPassRegisterRepit = FindViewById<TextInputLayout>(Resource.Id.txtPassRegisterRepit);
            btnRegistrar = FindViewById<Button>(Resource.Id.btnRegistrar);

            btnRegistrar.Click += BtnRegistrar_Click;

        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtEmailRegister.EditText.Text == "" || txtpPassRegister.EditText.Text == "" || txtPassRegisterRepit.EditText.Text == "")
            {
                Toast.MakeText(this, "Error!, los campos no pueden estar vacios", ToastLength.Long).Show();
            }
            else
            {
                if (txtpPassRegister.EditText.Text != txtPassRegisterRepit.EditText.Text)
                {
                    Toast.MakeText(this, "Error!, La contraseña tiene que ser igual", ToastLength.Long).Show();
                }
                else
                {

                    Global.RegisterApp(txtEmailRegister.EditText.Text, txtpPassRegister.EditText.Text);
                    if (flag.Band == true)
                    {
                        Toast.MakeText(this, flag.Mensaje, ToastLength.Long).Show();
                        Intent i = new Intent(this, typeof(ActivityColegio));
                    }
                    else
                    {
                        Toast.MakeText(this, "Credenciales no Valida \n Por favor cree una cuenta",
                        ToastLength.Long).Show();
                    }
                }

            }
        }
    }
}