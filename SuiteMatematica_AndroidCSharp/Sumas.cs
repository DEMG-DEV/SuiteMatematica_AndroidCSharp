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
    public class Sumas : Activity
    {
        Operaciones ope = new Operaciones();
        int Limite;//Cantidad a Hacer
        int Errores;// Meter en un "Toast" cada vez que se equivoque
        string Nivel;
        int Contador;//Cantidad hecha (bien y mal)
        int ContadorBien;
        int ContadorMal;
        int ContadorReinicio;
        int numero1, numero2, resultado;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Sumas);

            Limite = Intent.Extras.GetInt("Limite");
            Errores = Intent.Extras.GetInt("Errores");
            Nivel = Intent.Extras.GetString("Nivel");
            Contador = 0;
            ContadorBien = 0;
            ContadorMal = 0;
            ContadorReinicio = 0;
            resultado = 0;

            start();


        }

        private void start()
        {
            TextView lblCantRes = FindViewById<TextView>(Resource.Id.lblCantidad);
            TextView lblN1 = FindViewById<TextView>(Resource.Id.lblN1);
            TextView lblN2 = FindViewById<TextView>(Resource.Id.lblN2);
            TextView lblBien = FindViewById<TextView>(Resource.Id.lblBien);
            TextView lblMal = FindViewById<TextView>(Resource.Id.lblMal);
            TextView lblReiniciado = FindViewById<TextView>(Resource.Id.lblReiniciado);

            //Obtengo numeros aleatorios
            numero1 = ope.getRandom(3);
            numero2 = ope.getRandom(3);
            //Asigno a los TextBox
            lblN1.Text = Convert.ToString(numero1);
            lblN2.Text = Convert.ToString(numero2);
            //Asigno valor a los contadores
            lblCantRes.Text = lblCantRes.Text + " " + Convert.ToString(Limite - Contador);
            lblBien.Text = lblBien.Text + " " + Convert.ToString(ContadorBien);
            lblMal.Text = lblMal.Text + " " + Convert.ToString(ContadorMal);
            lblReiniciado.Text = lblReiniciado.Text + " " + Convert.ToString(ContadorReinicio);
        }
    }
}