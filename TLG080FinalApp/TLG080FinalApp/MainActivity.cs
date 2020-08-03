using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using Android.Support.Design.Widget;

namespace TLG080FinalApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : Activity
    {
        TextView linkRegister;
        TextInputLayout txtEmailLogin;
        TextInputLayout txtPassLogin;
        Button btnLogin;
        //ProgressBar progressBarLogin;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_Login);
            linkRegister = FindViewById<TextView>(Resource.Id.txtLinkRegister);
            txtEmailLogin = FindViewById<TextInputLayout>(Resource.Id.txtEmailLogin);
            txtPassLogin = FindViewById<TextInputLayout>(Resource.Id.txtPassLogin);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);

            linkRegister.Click += LinkRegister_Click;
            btnLogin.Click += BtnLogin_Click;
        }

        private void BtnLogin_Click(object sender, System.EventArgs e)
        {
            if (txtEmailLogin.EditText.Text == "" || txtPassLogin.EditText.Text == "")
            {
                Toast.MakeText(this, "Error!, los campos no pueden estar vacios", ToastLength.Long).Show();
            }
            else
            {
                if (Global.LoginApp(txtEmailLogin.EditText.Text, txtPassLogin.EditText.Text))
                {
                    Toast.MakeText(this, "Bienvenido!!", ToastLength.Long).Show();
                    Intent i = new Intent(this, typeof(ActivityColegio));
                    StartActivity(i);
                }
                else
                {
                    Toast.MakeText(this, "Credenciales no Valida \n Por favor cree una cuenta",
                    ToastLength.Long).Show();
                }

            }
        }

        private void LinkRegister_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityRegister));
            StartActivity(i);
        }
    }
}