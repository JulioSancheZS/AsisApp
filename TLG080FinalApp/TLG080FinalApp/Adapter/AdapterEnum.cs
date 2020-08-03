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
    class AdapterEnum : BaseAdapter
    {

        Activity context;
        List<EnumAsisSW> lista;
        ActivityEnum activity;

        public AdapterEnum(Activity context, List<EnumAsisSW> lista)
        {
            this.context = context;
            this.lista = lista;
            activity = (ActivityEnum)this.context;
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
            AdapterEnumViewHolder holder = null;

            if (view != null)
                holder = view.Tag as AdapterEnumViewHolder;

            if (holder == null)
            {
                holder = new AdapterEnumViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.emunitem, parent, false);
                holder.NomEnumAsis = view.FindViewById<TextView>(Resource.Id.txtEnum);
                holder.btnElimiEnum = view.FindViewById<ImageView>(Resource.Id.btnEliminarEnum);

                

                view.Tag = holder;
            }


            //fill in your items
            holder.NomEnumAsis.Text = item.EnumAsis;
            holder.btnElimiEnum.Click += delegate
            {
                Android.App.AlertDialog.Builder deleteDataAlert = new Android.App.AlertDialog.Builder(context);
                deleteDataAlert.SetTitle("Eliminar Tipo Asistencia");
                deleteDataAlert.SetMessage("¿Esta seguro?");
                deleteDataAlert.SetPositiveButton("Si", (senderAlert, args) =>
                {
                    if (Global.EliminarEnum(holder.btnElimiEnum.Id = item.Id))
                    {

                        Toast.MakeText(context, "Se ha eliminado el registro correctamente", ToastLength.Short).Show();
                        activity.ListadoEnum();
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

    class AdapterEnumViewHolder : Java.Lang.Object
    {
        public TextView NomEnumAsis { get; set; }
        public ImageView btnElimiEnum { get; set; }
    }
}