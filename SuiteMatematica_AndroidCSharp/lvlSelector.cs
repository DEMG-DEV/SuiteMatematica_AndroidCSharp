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
    public class lvlSelector : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.lvlSelector);

            Button btnIniciar = FindViewById<Button>(Resource.Id.btnIniciarPractica);
            RadioButton rbl1 = FindViewById<RadioButton>(Resource.Id.radioButton1);
            RadioButton rbl2 = FindViewById<RadioButton>(Resource.Id.radioButton2);
            RadioButton rbl3 = FindViewById<RadioButton>(Resource.Id.radioButton3);
            RadioButton rbl4 = FindViewById<RadioButton>(Resource.Id.radioButton4);
            RadioButton rbl5 = FindViewById<RadioButton>(Resource.Id.radioButton5);

            btnIniciar.Text = Resources.GetText(Resource.String.btnIniciarPractica) + " " + Intent.Extras.GetString("Operacion");

            btnIniciar.Click += (object sender, EventArgs e) =>
            {
                switch (Intent.Extras.GetString("Operacion"))
                {
                    case "Sumas":
                        if (rbl1.Checked == true)
                        {
                            var intent = new Intent(this, typeof(Sumas));
                            intent.PutExtra("Limite", 10);
                            intent.PutExtra("Errores", 3);
                            intent.PutExtra("Nivel", "Nivel 1");
                            StartActivity(intent);
                        }
                        else if (rbl2.Checked == true)
                        {
                            var intent = new Intent(this, typeof(Sumas));
                            intent.PutExtra("Limite", 15);
                            intent.PutExtra("Errores", 3);
                            intent.PutExtra("Nivel", "Nivel 2");
                            StartActivity(intent);
                        }
                        else if (rbl3.Checked == true)
                        {
                            var intent = new Intent(this, typeof(Sumas));
                            intent.PutExtra("Limite", 20);
                            intent.PutExtra("Errores", 2);
                            intent.PutExtra("Nivel", "Nivel 3");
                            StartActivity(intent);
                        }
                        else if (rbl4.Checked == true)
                        {
                            var intent = new Intent(this, typeof(Sumas));
                            intent.PutExtra("Limite", 25);
                            intent.PutExtra("Errores", 2);
                            intent.PutExtra("Nivel", "Nivel 4");
                            StartActivity(intent);
                        }
                        else if (rbl5.Checked == true)
                        {
                            var intent = new Intent(this, typeof(Sumas));
                            intent.PutExtra("Limite", 30);
                            intent.PutExtra("Errores", 1);
                            intent.PutExtra("Nivel", "Nivel 5");
                            StartActivity(intent);
                        }
                        break;
                    case "Restas":
                        if (rbl1.Checked == true)
                        {
                            var intent = new Intent(this, typeof(Restas));
                            intent.PutExtra("Limite", 10);
                            intent.PutExtra("Errores", 3);
                            intent.PutExtra("Nivel", "Nivel 1");
                            StartActivity(intent);
                        }
                        else if (rbl2.Checked == true)
                        {
                            var intent = new Intent(this, typeof(Restas));
                            intent.PutExtra("Limite", 15);
                            intent.PutExtra("Errores", 3);
                            intent.PutExtra("Nivel", "Nivel 2");
                            StartActivity(intent);
                        }
                        else if (rbl3.Checked == true)
                        {
                            var intent = new Intent(this, typeof(Restas));
                            intent.PutExtra("Limite", 20);
                            intent.PutExtra("Errores", 2);
                            intent.PutExtra("Nivel", "Nivel 3");
                            StartActivity(intent);
                        }
                        else if (rbl4.Checked == true)
                        {
                            var intent = new Intent(this, typeof(Restas));
                            intent.PutExtra("Limite", 25);
                            intent.PutExtra("Errores", 2);
                            intent.PutExtra("Nivel", "Nivel 4");
                            StartActivity(intent);
                        }
                        else if (rbl5.Checked == true)
                        {
                            var intent = new Intent(this, typeof(Restas
                                ));
                            intent.PutExtra("Limite", 30);
                            intent.PutExtra("Errores", 1);
                            intent.PutExtra("Nivel", "Nivel 5");
                            StartActivity(intent);
                        }
                        break;
                    case "Multiplicaciones":
                        if (rbl1.Checked == true)
                        {
                            var intent = new Intent(this, typeof(Multiplicaciones));
                            intent.PutExtra("Limite", 10);
                            intent.PutExtra("Errores", 3);
                            intent.PutExtra("Nivel", "Nivel 1");
                            StartActivity(intent);
                        }
                        else if (rbl2.Checked == true)
                        {
                            var intent = new Intent(this, typeof(Multiplicaciones));
                            intent.PutExtra("Limite", 15);
                            intent.PutExtra("Errores", 3);
                            intent.PutExtra("Nivel", "Nivel 2");
                            StartActivity(intent);
                        }
                        else if (rbl3.Checked == true)
                        {
                            var intent = new Intent(this, typeof(Multiplicaciones));
                            intent.PutExtra("Limite", 20);
                            intent.PutExtra("Errores", 2);
                            intent.PutExtra("Nivel", "Nivel 3");
                            StartActivity(intent);
                        }
                        else if (rbl4.Checked == true)
                        {
                            var intent = new Intent(this, typeof(Multiplicaciones));
                            intent.PutExtra("Limite", 25);
                            intent.PutExtra("Errores", 2);
                            intent.PutExtra("Nivel", "Nivel 4");
                            StartActivity(intent);
                        }
                        else if (rbl5.Checked == true)
                        {
                            var intent = new Intent(this, typeof(Multiplicaciones));
                            intent.PutExtra("Limite", 30);
                            intent.PutExtra("Errores", 1);
                            intent.PutExtra("Nivel", "Nivel 5");
                            StartActivity(intent);
                        }
                        break;
                }
            };
        }
    }
}