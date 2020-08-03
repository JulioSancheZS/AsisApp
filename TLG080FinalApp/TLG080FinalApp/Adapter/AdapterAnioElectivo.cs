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
    class AdapterAnioElectivo : BaseAdapter
    {

        Activity context;
        List<AnioElectivoSW> lista;
        ActivityAnioElecti activity;

        public AdapterAnioElectivo(Activity context, List<AnioElectivoSW> lista)
        {
            this.context = context;
            this.lista = lista;
            activity = (ActivityAnioElecti)this.context;
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
            var view = convertView;
            AdapterAnioElectivoViewHolder holder = null;

            var item = lista[position];//posicion de los item 

            if (view != null)
                holder = view.Tag as AdapterAnioElectivoViewHolder;

            if (holder == null)
            {
                holder = new AdapterAnioElectivoViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                //replace with your item and your holder items
                //comment back in
                view = inflater.Inflate(Resource.Layout.anioelectivoitem, parent, false);
                holder.txtDescripcion = view.FindViewById<TextView>(Resource.Id.txtDescripcioAnioList);
                holder.txtSemestre = view.FindViewById<TextView>(Resource.Id.txtSemestreList);
                holder.btnElimiAnio = view.FindViewById<ImageView>(Resource.Id.btnElimiAnioelec);
                //view.Tag = holder;
            }

            holder.txtDescripcion.Text = item._Descripcion;
            holder.txtSemestre.Text = item._Semestre;

            holder.btnElimiAnio.Click += delegate
            {
                Android.App.AlertDialog.Builder deleteDataAlert = new Android.App.AlertDialog.Builder(context);
                deleteDataAlert.SetTitle("Eliminar Año Electivo");
                deleteDataAlert.SetMessage("¿Esta seguro?");
                deleteDataAlert.SetPositiveButton("Si", (senderAlert, args) =>
                {
                    if (Global.EliminarAnio(holder.btnElimiAnio.Id = item._Id))
                    {

                        Toast.MakeText(context, "Se ha eliminado el registro correctamente", ToastLength.Short).Show();
                        activity.ListadoAnioElec();
                    }


                });
                deleteDataAlert.SetNegativeButton("Cancel", (senderAlert, args) =>
                {
                    deleteDataAlert.Dispose();
                });

                deleteDataAlert.Show();
            };

            //fill in your items
            //holder.Title.Text = "new text here";

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

    class AdapterAnioElectivoViewHolder : Java.Lang.Object
    {
       public TextView txtDescripcion { get; set; }
        public TextView txtSemestre { get; set; }
        public ImageView btnElimiAnio { get; set; }
    }
}