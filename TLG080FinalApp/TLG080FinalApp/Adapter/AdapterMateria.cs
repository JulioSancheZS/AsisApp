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
    class AdapterMateria : BaseAdapter
    {

        Activity context;
        List<MateriaInnerJoin> lista;
        ActivityMateria activity;

        public AdapterMateria(Activity context, List<MateriaInnerJoin> lista)
        {
            this.context = context;
            this.lista = lista;
            activity = (ActivityMateria)this.context;
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
            AdapterMateriaViewHolder holder = null;

            if (view != null)
                holder = view.Tag as AdapterMateriaViewHolder;

            if (holder == null)
            {
                holder = new AdapterMateriaViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.materiaitem, parent, false);
                holder.NomMateria = view.FindViewById<TextView>(Resource.Id.txtMateria);
                holder.NomAlumno = view.FindViewById<TextView>(Resource.Id.txtFkAlumnoMateria);
            
                holder.btnElimiMateria = view.FindViewById<ImageView>(Resource.Id.btnEliminarMateria);

                view.Tag = holder;
            }


            //fill in your items
            //holder.Title.Text = "new text here";
            //fill in your items
            //holder.Title.Text = "new text here";


            holder.NomMateria.Text = item._NomMateria;
            holder.NomAlumno.Text = item._Nombre + " " + item._Apellido;
            holder.btnElimiMateria.Click += delegate
            {
                Android.App.AlertDialog.Builder deleteDataAlert = new Android.App.AlertDialog.Builder(context);
                deleteDataAlert.SetTitle("Eliminar Materia");
                deleteDataAlert.SetMessage("¿Esta seguro?");
                deleteDataAlert.SetPositiveButton("Si", (senderAlert, args) =>
                {
                    if (Global.EliminarMateria(holder.btnElimiMateria.Id = item._Id))
                    {

                        Toast.MakeText(context, "Se ha eliminado el registro correctamente", ToastLength.Short).Show();
                        activity.ListadoMateria();
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

    class AdapterMateriaViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        public TextView NomMateria { get; set; }
        public TextView NomAlumno { get; set; }
        public ImageView btnElimiMateria { get; set; }
    }
}