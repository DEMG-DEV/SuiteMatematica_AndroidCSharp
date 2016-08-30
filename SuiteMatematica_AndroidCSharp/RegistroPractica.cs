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
using Android.Database.Sqlite;
using Java.Lang;

namespace SuiteMatematica_AndroidCSharp
{
    public class RegistroPractica
    {
        public int idOperacion { get; set; }
        public string operacion { get; set; }
        public string nivelOperacion { get; set; }
        public int bienOperacion { get; set; }
        public int malOperacion { get; set; }
        public string fechaOperacion { get; set; }

        public static explicit operator RegistroPractica(Java.Lang.Object v)
        {
            throw new NotImplementedException();
        }

    }
}