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
    [Activity(Label = "Suite Matematica", Icon = "@drawable/icon")]
    public class lvlSelector : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.lvlSelector);

            Button btnIniciar = FindViewById<Button>(Resource.Id.btnIniciarPractica);

            btnIniciar.Text = Resources.GetText(Resource.String.btnIniciarPractica) + " " + Intent.Extras.GetString("Operacion");

            btnIniciar.Click += (object sender, EventArgs e) =>
            {
                switch (Intent.Extras.GetString("Operacion"))
                {
                    case "Sumas":
                        var intent = new Intent(this, typeof(Sumas));
                        StartActivity(intent);
                        break;
                    case "Restas":
                        break;
                    case "Multiplicaciones":
                        break;
                }
            };
        }
    }
}