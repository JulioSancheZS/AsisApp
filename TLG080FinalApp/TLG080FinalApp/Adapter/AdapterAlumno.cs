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
using TLG080FinalApp.com.somee.asisappbackend;

namespace TLG080FinalApp.Adapter
{
    class AdapterAlumno : BaseAdapter
    {

        Activity context;
        List<AlumnoInnerJoin> lista;
        ActivityAlumno activity;

        public AdapterAlumno(Activity context, List<AlumnoInnerJoin> lista)
        {
            this.context = context;
            this.context = context;
            this.lista = lista;
            activity = (ActivityAlumno)this.context;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = lista[position];//posicion de los item 

            var view = convertView;
            AdapterAlumnoViewHolder holder = null;

            if (view != null)
                holder = view.Tag as AdapterAlumnoViewHolder;

            if (holder == null)
            {
                holder = new AdapterAlumnoViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                view = inflater.Inflate(Resource.Layout.alumnoitem, parent, false);
                holder.Nombre = view.FindViewById<TextView>(Resource.Id.txtNombre);
                holder.Sexo = view.FindViewById<TextView>(Resource.Id.txtSexo);
                holder.Telefono = view.FindViewById<TextView>(Resource.Id.txtTelefono);
                holder.Email = view.FindViewById<TextView>(Resource.Id.txtEmail);
                holder.Grado = view.FindViewById<TextView>(Resource.Id.txtFKGrado);
                holder.btnElimiAlumno = view.FindViewById<ImageView>(Resource.Id.btnEliminarAlumno);

                view.Tag = holder;
            }


            //fill in your items
            //holder.Title.Text = "new text here";
            holder.Nombre.Text = item._NomCompleto;      
            holder.Sexo.Text = item._Sexo;
            holder.Telefono.Text = item._Telefono;
            holder.Email.Text = item._Email;
            holder.Grado.Text = item._Grado;

            holder.btnElimiAlumno.Click += delegate
            {
                Android.App.AlertDialog.Builder deleteDataAlert = new Android.App.AlertDialog.Builder(context);
                deleteDataAlert.SetTitle("Eliminar Alumno");
                deleteDataAlert.SetMessage("¿Esta seguro?");
                deleteDataAlert.SetPositiveButton("Si", (senderAlert, args) =>
                {
                    if (Global.EliminarAlumno(holder.btnElimiAlumno.Id = item._Id))
                    {

                        Toast.MakeText(context, "Se ha eliminado el registro correctamente", ToastLength.Short).Show();
                        activity.ListadoAlumno();
                    }


                });
                deleteDataAlert.SetNegativeButton("Cancel", (senderAlert, args) =>
                {
                    deleteDataAlert.Dispose();
                });

                deleteDataAlert.Show();
            };

            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return lista.Count;
            }
        }

    }

    class AdapterAlumnoViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        public TextView Nombre{ get; set; }
        public TextView Sexo { get; set; }
        public TextView Telefono { get; set; }
        public TextView Email { get; set; }
        public TextView Grado { get; set; }
        public ImageView btnElimiAlumno { get; set; }
    }
}