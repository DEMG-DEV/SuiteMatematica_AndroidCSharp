using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SuiteMatematica_AndroidCSharp
{
    [Activity(Label = "Suite Matematica", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        string operacion;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button btnIniciar = FindViewById<Button>(Resource.Id.btnIniciar);
            Spinner spinner = FindViewById<Spinner>(Resource.Id.Operariones);
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.Operations, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            btnIniciar.Click += (object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(lvlSelector));
                intent.PutExtra("Operacion", operacion);
                StartActivity(intent);
            };

        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            operacion = spinner.GetItemAtPosition(e.Position).ToString();

            string toast = string.Format(Resources.GetText(Resource.String.Message_Main) + " {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }
    }
}

