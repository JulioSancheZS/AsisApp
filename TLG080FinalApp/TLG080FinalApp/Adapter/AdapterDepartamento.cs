using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V7.App;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TLG080FinalApp.com.somee.asisappbackend;

namespace TLG080FinalApp.Adapter
{
    class AdapterDepartamento : BaseAdapter
    {

        Activity context;
        List<DepartamentoSW> lista;
        ActivityDepartamento activity;
       

        public AdapterDepartamento(Activity context, List<DepartamentoSW> lista)
        {
            this.context = context;
            this.lista = lista;
            activity = (ActivityDepartamento)this.context;
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
            AdapterDepartamentoViewHolder holder = null;

            if (view != null)
                holder = view.Tag as AdapterDepartamentoViewHolder;

            if (holder == null)
            {
                holder = new AdapterDepartamentoViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                //replace with your item and your holder items
                //comment back in
                view = inflater.Inflate(Resource.Layout.layout_itemdepartamento, parent, false);
                holder.NomDepar = view.FindViewById<TextView>(Resource.Id.txtItemDepart);
                holder.btnElimiDepar = view.FindViewById<ImageView>(Resource.Id.eliminarDepar);
                //view.Tag = holder;
            }


            //fill in your items
            //holder.Title.Text = "new text here";
            holder.NomDepar.Text = item.NomDepartamento;
            //Boton eliminar
            holder.btnElimiDepar.Click += delegate
            {
                Android.App.AlertDialog.Builder deleteDataAlert = new Android.App.AlertDialog.Builder(context);
                deleteDataAlert.SetTitle("Eliminar Departamento");
                deleteDataAlert.SetMessage("¿Esta seguro?");
                deleteDataAlert.SetPositiveButton("Si", (senderAlert, args) =>
                {
                    if (Global.EliminarDepar(holder.btnElimiDepar.Id = item.Id))
                    {

                        Toast.MakeText(context, "Se ha eliminado el registro correctamente", ToastLength.Short).Show();
                        activity.ListadoDepart();
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

    class AdapterDepartamentoViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        public TextView NomDepar { get; set; }
        public ImageView btnElimiDepar { get; set; }
    }

}