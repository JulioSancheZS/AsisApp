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
    class AdapterColegio : BaseAdapter
    {

        Activity context;
        List<ColegioInnerJoin> lista;
        ActivityColegio activity;

        public AdapterColegio(Activity context, List<ColegioInnerJoin> lista)
        {
            this.context = context;
            this.lista = lista;
            activity = (ActivityColegio)this.context;
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
            AdapterColegioViewHolder holder = null;

            if (view != null)
                holder = view.Tag as AdapterColegioViewHolder;

            if (holder == null)
            {
                holder = new AdapterColegioViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                //replace with your item and your holder items
                //comment back in
                view = inflater.Inflate(Resource.Layout.colegioitem, parent, false);
                holder.NomCole = view.FindViewById<TextView>(Resource.Id.txtColegio);
                holder.NomDepar = view.FindViewById<TextView>(Resource.Id.txtFkDepar);
                holder.NomAnio = view.FindViewById<TextView>(Resource.Id.txtFkAnioElec);
                holder.btnElimiCole = view.FindViewById<ImageView>(Resource.Id.btnEliminarCole);

                view.Tag = holder;
            }

            //fill in your items
            //holder.Title.Text = "new text here";
            holder.NomCole.Text = item._NomColegio;
            holder.NomDepar.Text = item._NomDepartamento.ToString();
            holder.NomAnio.Text = item._NomAnioElectivo.ToString();

            holder.btnElimiCole.Click += delegate
            {
                Android.App.AlertDialog.Builder deleteDataAlert = new Android.App.AlertDialog.Builder(context);
                deleteDataAlert.SetTitle("Eliminar Colegio");
                deleteDataAlert.SetMessage("¿Esta seguro?");
                deleteDataAlert.SetPositiveButton("Si", (senderAlert, args) =>
                {
                    if (Global.EliminarCole(holder.btnElimiCole.Id = item._Id))
                    {

                        Toast.MakeText(context, "Se ha eliminado el registro correctamente", ToastLength.Short).Show();
                        activity.ListadoColegio();
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

    class AdapterColegioViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        public TextView NomCole { get; set; }
        public TextView NomDepar { get; set; }
        public TextView NomAnio { get; set; }
        public ImageView btnElimiCole { get; set; }
    }
}