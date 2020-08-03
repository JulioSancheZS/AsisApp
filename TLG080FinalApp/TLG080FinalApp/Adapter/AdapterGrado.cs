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
    class AdapterGrado : BaseAdapter
    {
        Activity context;
        List<GradoInnerJoin> lista;
        ActivityGrado activity;
     

        public AdapterGrado(Activity context, List<GradoInnerJoin> lista)
        {
            this.context = context;
            this.lista = lista;
            activity = (ActivityGrado)this.context;
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
            AdapterGradoViewHolder holder = null;

            if (view != null)
                holder = view.Tag as AdapterGradoViewHolder;

            if (holder == null)
            {
                holder = new AdapterGradoViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                view = inflater.Inflate(Resource.Layout.gradoitem, parent, false);
                holder.NomGrado = view.FindViewById<TextView>(Resource.Id.txtGrado);
                holder.NomColegio = view.FindViewById<TextView>(Resource.Id.txtFkColegioGrado);
              
                holder.btnElimiGrado = view.FindViewById<ImageView>(Resource.Id.btnEliminarGrado);
                view.Tag = holder;
            }

            holder.NomGrado.Text = item._NomGrado;
            holder.NomColegio.Text = item._NomColegio;
            //fill in your items
            //holder.Title.Text = "new text here";
            holder.btnElimiGrado.Click += delegate
            {
                try
                {
                    Android.App.AlertDialog.Builder deleteDataAlert = new Android.App.AlertDialog.Builder(context);
                    deleteDataAlert.SetTitle("Eliminar Grado");
                    deleteDataAlert.SetMessage("¿Esta seguro?");
                    deleteDataAlert.SetPositiveButton("Si", (senderAlert, args) =>
                    {
                        if (Global.EliminarGrado(holder.btnElimiGrado.Id = item._Id))
                        {

                            Toast.MakeText(context, "Se ha eliminado el registro correctamente", ToastLength.Short).Show();
                            activity.ListadoGrado();
                        }


                    });
                    deleteDataAlert.SetNegativeButton("Cancel", (senderAlert, args) =>
                    {
                        deleteDataAlert.Dispose();
                    });

                    deleteDataAlert.Show();
                }
                catch (Exception)
                {
                    Toast.MakeText(context, "Algo anda mal", ToastLength.Short).Show();
                    throw;
                }
                
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

    class AdapterGradoViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        public TextView NomGrado { get; set; }
        public TextView NomColegio { get; set; }
        public ImageView btnElimiGrado { get; set; }
    }
}