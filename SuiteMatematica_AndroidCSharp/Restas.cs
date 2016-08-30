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
    public class Restas : Activity
    {
        Operaciones ope = new Operaciones();
        int Limite;//Cantidad a Hacer
        int Errores;// Errores disponibles
        string Nivel;// Nivel de la practica
        int Contador;//Cantidad hecha (bien y mal)
        int ContadorBien;
        int ContadorMal;
        int ContadorReinicio;
        int numero1, numero2, resultado;// Numeros de la operaccion y resultado(escrito por el usuario)
        bool btV, btS;// Valores con los cuales controlar el estado de los Botones: Siguiente, Validar

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.Restas);

            if (bundle != null)
            {
                // Recuperar Contadores de la Interfaz
                Limite = bundle.GetInt("limite");
                Errores = bundle.GetInt("errores");
                Nivel = bundle.GetString("nivel");
                Contador = bundle.GetInt("contador");
                ContadorBien = bundle.GetInt("bien");
                ContadorMal = bundle.GetInt("mal");
                ContadorReinicio = bundle.GetInt("reinicio");
                btS = bundle.GetBoolean("btS");
                btV = bundle.GetBoolean("btV");

                // Recuperar Numeros de la Operacion
                numero1 = bundle.GetInt("numero1");
                numero2 = bundle.GetInt("numero2");

                // Asignando Valores a la Interfaz   
                startSave();
            }
            else
            {
                // Primer Inicio de la Aplicacion
                Limite = Intent.Extras.GetInt("Limite");
                Errores = Intent.Extras.GetInt("Errores");
                Nivel = Intent.Extras.GetString("Nivel");
                Contador = 0;
                ContadorBien = 0;
                ContadorMal = 0;
                ContadorReinicio = 0;
                resultado = 0;
                btS = false;
                btV = true;

                start();
            }

            Button btnValida = FindViewById<Button>(Resource.Id.btnValidar);
            Button btnSiguiente = FindViewById<Button>(Resource.Id.btnSiguiente);
            EditText txtResultado = FindViewById<EditText>(Resource.Id.edittext);
            TextView lblCantRes = FindViewById<TextView>(Resource.Id.lblCantidad);
            TextView lblBien = FindViewById<TextView>(Resource.Id.lblBien);
            TextView lblMal = FindViewById<TextView>(Resource.Id.lblMal);
            TextView lblReiniciado = FindViewById<TextView>(Resource.Id.lblReiniciado);
            TextView lblLimiteErrores = FindViewById<TextView>(Resource.Id.lblLimite);

            btnSiguiente.Enabled = btS;
            btnValida.Enabled = btV;

            btnValida.Click += (object sender, EventArgs e) =>
            {
                try
                {
                    // Control del Estado de los botones
                    btV = false;
                    btS = true;

                    resultado = Convert.ToInt32(txtResultado.Text);
                    if (ope.checar(numero1, numero2, resultado, 2) == true)
                    {
                        // Mensaje para el usuario
                        string toast = string.Format(Resources.GetText(Resource.String.WellMessage) + " {0}", numero1 - numero2);
                        Toast.MakeText(this, toast, ToastLength.Long).Show();

                        // Estado de los Botones
                        btnSiguiente.Enabled = btS;
                        btnValida.Enabled = btV;

                        // Actualizacion de Contadores Internos
                        ContadorBien++;
                        Contador++;

                        // Actualiza Contadores de Interfaz
                        lblCantRes.Text = "";
                        lblBien.Text = "";
                        lblMal.Text = "";
                        lblReiniciado.Text = "";
                        txtResultado.Text = "";
                        lblLimiteErrores.Text = "";

                        lblCantRes.Text = Resources.GetText(Resource.String.lblCantidadDoIt) + " " + Convert.ToString(Limite - Contador);
                        lblBien.Text = Resources.GetText(Resource.String.lblBien) + " " + Convert.ToString(ContadorBien);
                        lblMal.Text = Resources.GetText(Resource.String.lblMal) + " " + Convert.ToString(ContadorMal);
                        lblReiniciado.Text = Resources.GetText(Resource.String.lblReiniciado) + " " + Convert.ToString(ContadorReinicio);
                        lblLimiteErrores.Text = Resources.GetText(Resource.String.lblLimite) + " " + Convert.ToString(Errores);
                    }
                    else
                    {
                        // Mensaje para el usuario
                        string toast = string.Format(Resources.GetText(Resource.String.WrongMessage) + " {0}", numero1 - numero2);
                        Toast.MakeText(this, toast, ToastLength.Long).Show();

                        // Estado de los Botones
                        btnSiguiente.Enabled = btS;
                        btnValida.Enabled = btV;

                        // Actualizacion de Contadores Internos
                        ContadorMal++;
                        Contador++;

                        // Actualiza Contadores de Interfaz
                        lblCantRes.Text = "";
                        lblBien.Text = "";
                        lblMal.Text = "";
                        lblReiniciado.Text = "";
                        txtResultado.Text = "";
                        lblLimiteErrores.Text = "";

                        lblCantRes.Text = Resources.GetText(Resource.String.lblCantidadDoIt) + " " + Convert.ToString(Limite - Contador);
                        lblBien.Text = Resources.GetText(Resource.String.lblBien) + " " + Convert.ToString(ContadorBien);
                        lblMal.Text = Resources.GetText(Resource.String.lblMal) + " " + Convert.ToString(ContadorMal);
                        lblReiniciado.Text = Resources.GetText(Resource.String.lblReiniciado) + " " + Convert.ToString(ContadorReinicio);
                        lblLimiteErrores.Text = Resources.GetText(Resource.String.lblLimite) + " " + Convert.ToString(Errores);
                    }
                }
                catch (Exception ex)
                {

                }
            };

            btnSiguiente.Click += (object sender, EventArgs e) =>
            {
                // Estado Nuevo de los Botones
                btS = false;
                btV = true;

                if (ContadorMal == Errores)
                {
                    // Mensaje para el usuario
                    string toast = string.Format(Resources.GetText(Resource.String.RestartMessage) + " {0} Errores", ContadorMal);
                    Toast.MakeText(this, toast, ToastLength.Long).Show();

                    // Guardado en la Base de Datos
                    buttonSave();

                    // Reinicio
                    Contador = 0;
                    ContadorMal = 0;
                    ContadorBien = 0;
                    ContadorReinicio++;
                    lblReiniciado.Text = "";
                    lblReiniciado.Text = Resources.GetText(Resource.String.lblReiniciado) + " " + Convert.ToString(ContadorReinicio);                    
                    start();
                }
                else if (Contador == Limite)
                {
                    // Guardado en la Base de Datos
                    buttonSave();

                    // Mensaje para el usuario
                    string toast = string.Format("Gracias por utilizar nuestra aplicacion");
                    Toast.MakeText(this, toast, ToastLength.Long).Show();

                    var intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);
                }
                else
                {
                    start();
                }
            };
        }

        void buttonSave()
        {
            AddressBookDbHelper db = new AddressBookDbHelper(this);

            RegistroPractica ab = new RegistroPractica();

            ab.operacion = "Restas";
            ab.nivelOperacion = Nivel;
            ab.bienOperacion = ContadorBien;
            ab.malOperacion = ContadorMal;
            ab.fechaOperacion = DateTime.Now.ToString("g");

            try
            {
                db.AddNewContact(ab);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            // Guardar Contadores de la Interfaz
            outState.PutInt("limite", Limite);
            outState.PutInt("errores", Errores);
            outState.PutString("nivel", Nivel);
            outState.PutInt("contador", Contador);
            outState.PutInt("bien", ContadorBien);
            outState.PutInt("mal", ContadorMal);
            outState.PutInt("reinicio", ContadorReinicio);

            // Guardar Numeros de la Operacion
            outState.PutInt("numero1", numero1);
            outState.PutInt("numero2", numero2);

            // Guardar Estado de los Botones
            outState.PutBoolean("btV", btV);
            outState.PutBoolean("btS", btS);

            // always call the base implementation!
            base.OnSaveInstanceState(outState);
        }

        private void start()
        {
            Button btnValida = FindViewById<Button>(Resource.Id.btnValidar);
            Button btnSiguiente = FindViewById<Button>(Resource.Id.btnSiguiente);
            TextView lblCantRes = FindViewById<TextView>(Resource.Id.lblCantidad);
            TextView lblN1 = FindViewById<TextView>(Resource.Id.lblN1);
            TextView lblN2 = FindViewById<TextView>(Resource.Id.lblN2);
            TextView lblBien = FindViewById<TextView>(Resource.Id.lblBien);
            TextView lblMal = FindViewById<TextView>(Resource.Id.lblMal);
            TextView lblReiniciado = FindViewById<TextView>(Resource.Id.lblReiniciado);
            TextView lblLimiteErrores = FindViewById<TextView>(Resource.Id.lblLimite);

            btnSiguiente.Enabled = btS;
            btnValida.Enabled = btV;

            //Obtengo numeros aleatorios
            numero1 = ope.getRandom(3);
            numero2 = ope.getRandom(3);

            //Asigno a los TextBox
            lblN1.Text = Convert.ToString(numero1);
            lblN2.Text = Convert.ToString(numero2);

            //Asigno valor a los contadores
            lblCantRes.Text = Resources.GetText(Resource.String.lblCantidadDoIt) + " " + Convert.ToString(Limite - Contador);
            lblBien.Text = Resources.GetText(Resource.String.lblBien) + " " + Convert.ToString(ContadorBien);
            lblMal.Text = Resources.GetText(Resource.String.lblMal) + " " + Convert.ToString(ContadorMal);
            lblReiniciado.Text = Resources.GetText(Resource.String.lblReiniciado) + " " + Convert.ToString(ContadorReinicio);
            lblLimiteErrores.Text = Resources.GetText(Resource.String.lblLimite) + " " + Convert.ToString(Errores);
        }

        private void startSave()
        {
            TextView lblCantRes = FindViewById<TextView>(Resource.Id.lblCantidad);
            TextView lblN1 = FindViewById<TextView>(Resource.Id.lblN1);
            TextView lblN2 = FindViewById<TextView>(Resource.Id.lblN2);
            TextView lblBien = FindViewById<TextView>(Resource.Id.lblBien);
            TextView lblMal = FindViewById<TextView>(Resource.Id.lblMal);
            TextView lblReiniciado = FindViewById<TextView>(Resource.Id.lblReiniciado);
            TextView lblLimiteErrores = FindViewById<TextView>(Resource.Id.lblLimite);

            //Asigno a los TextBox
            lblN1.Text = Convert.ToString(numero1);
            lblN2.Text = Convert.ToString(numero2);

            //Asigno valor a los contadores
            lblCantRes.Text = Resources.GetText(Resource.String.lblCantidadDoIt) + " " + Convert.ToString(Limite - Contador);
            lblBien.Text = Resources.GetText(Resource.String.lblBien) + " " + Convert.ToString(ContadorBien);
            lblMal.Text = Resources.GetText(Resource.String.lblMal) + " " + Convert.ToString(ContadorMal);
            lblReiniciado.Text = Resources.GetText(Resource.String.lblReiniciado) + " " + Convert.ToString(ContadorReinicio);
            lblLimiteErrores.Text = Resources.GetText(Resource.String.lblLimite) + " " + Convert.ToString(Errores);
        }
    }
}