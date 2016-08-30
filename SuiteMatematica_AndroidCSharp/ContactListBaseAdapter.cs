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

namespace SuiteMatematica_AndroidCSharp
{
    [Activity(Label = "ContactListBaseAdapter")]
    public partial class ContactListBaseAdapter : BaseAdapter<RegistroPractica>
    {
        IList<RegistroPractica> contactListArrayList;
        private LayoutInflater mInflater;
        private Context activity;

        public ContactListBaseAdapter(Context context, IList<RegistroPractica> results)
        {
            this.activity = context;
            contactListArrayList = results;
            mInflater = (LayoutInflater)activity.GetSystemService(Context.LayoutInflaterService);
        }

        public override int Count
        {
            get { return contactListArrayList.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override RegistroPractica this[int position]
        {
            get { return contactListArrayList[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ImageView btnDelete;
            ContactsViewHolder holder = null;
            if (convertView == null)
            {
                convertView = mInflater.Inflate(Resource.Layout.Statistics_row, null);
                holder = new ContactsViewHolder();

                holder.txtOperacion = convertView.FindViewById<TextView>(Resource.Id.lr_operacion);
                holder.txtNivel = convertView.FindViewById<TextView>(Resource.Id.lr_nivel);
                holder.txtBien = convertView.FindViewById<TextView>(Resource.Id.lr_bien);
                holder.txtMal = convertView.FindViewById<TextView>(Resource.Id.lr_mal);
                holder.txtFecha = convertView.FindViewById<TextView>(Resource.Id.lr_fecha);
                btnDelete = convertView.FindViewById<ImageView>(Resource.Id.lr_deleteBtn);


                btnDelete.Click += (object sender, EventArgs e) =>
                {

                    AlertDialog.Builder builder = new AlertDialog.Builder(activity);
                    AlertDialog confirm = builder.Create();
                    confirm.SetTitle("Confirmas Eliminar");
                    confirm.SetMessage("Estás seguro de eliminar el Registro?");
                    confirm.SetButton("OK", (s, ev) =>
                    {
                        var poldel = (int)((sender as ImageView).Tag);

                        string id = contactListArrayList[poldel].idOperacion.ToString();
                        string fname = contactListArrayList[poldel].operacion;

                        contactListArrayList.RemoveAt(poldel);

                        DeleteSelectedContact(id);
                        NotifyDataSetChanged();

                        Toast.MakeText(activity, "Registro eliminado de forma exitosa", ToastLength.Short).Show();
                    });
                    confirm.SetButton2("Cancelar", (s, ev) =>
                    {

                    });

                    confirm.Show();
                };

                convertView.Tag = holder;
                btnDelete.Tag = position;
            }
            else
            {
                btnDelete = convertView.FindViewById<ImageView>(Resource.Id.lr_deleteBtn);
                holder = convertView.Tag as ContactsViewHolder;
                btnDelete.Tag = position;
            }

            holder.txtOperacion.Text = contactListArrayList[position].operacion.ToString();
            holder.txtNivel.Text = contactListArrayList[position].nivelOperacion;
            holder.txtBien.Text = contactListArrayList[position].bienOperacion.ToString();
            holder.txtMal.Text = contactListArrayList[position].malOperacion.ToString();
            holder.txtFecha.Text = contactListArrayList[position].fechaOperacion;

            if (position % 2 == 0)
            {
                convertView.SetBackgroundResource(Resource.Drawable.list_selector);
            }
            else
            {
                convertView.SetBackgroundResource(Resource.Drawable.list_selector_alternate);
            }

            return convertView;
        }

        public IList<RegistroPractica> GetAllData()
        {
            return contactListArrayList;
        }

        public class ContactsViewHolder : Java.Lang.Object
        {
            public TextView txtOperacion { get; set; }
            public TextView txtNivel { get; set; }
            public TextView txtBien { get; set; }
            public TextView txtMal { get; set; }
            public TextView txtFecha { get; set; }
        }

        private void DeleteSelectedContact(string contactId)
        {
            AddressBookDbHelper _db = new AddressBookDbHelper(activity);
            _db.DeleteContact(contactId);
        }
    }
}