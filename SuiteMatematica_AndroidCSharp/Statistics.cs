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
    [Activity(Label = "Math-Tlon", Icon = "@drawable/icon")]
    public class Statistics : Activity
    {
        Button btnSearch;
        EditText txtSearch;
        ListView lv;
        IList<RegistroPractica> listItsms = null;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Statistics);

            btnSearch = FindViewById<Button>(Resource.Id.contactList_btnSearch);
            txtSearch = FindViewById<EditText>(Resource.Id.contactList_txtSearch);
            lv = FindViewById<ListView>(Resource.Id.contactList_listView);

            btnSearch.Click += delegate
            {
                LoadContactsInList();
            };

            LoadContactsInList();

        }

        private void LoadContactsInList()
        {
            AddressBookDbHelper dbVals = new AddressBookDbHelper(this);
            if (txtSearch.Text.Trim().Length < 1)
            {
                listItsms = dbVals.GetAllContacts();
            }
            else
            {
                listItsms = dbVals.GetContactsBySearchName(txtSearch.Text.Trim());
            }

            lv.Adapter = new ContactListBaseAdapter(this, listItsms);
        }
    }
}