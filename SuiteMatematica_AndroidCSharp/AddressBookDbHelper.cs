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
using Android.Database;

namespace SuiteMatematica_AndroidCSharp
{
    class AddressBookDbHelper : SQLiteOpenHelper
    {
        private const string APP_DATABASENAME = "Registro.db3";
        private const int APP_DATABASE_VERSION = 1;

        public AddressBookDbHelper(Context ctx) :
            base(ctx, APP_DATABASENAME, null, APP_DATABASE_VERSION)
        {

        }

        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(@"CREATE TABLE IF NOT EXISTS registros (
                            idOperacion     INTEGER PRIMARY KEY AUTOINCREMENT,
                            operacion       TEXT NOT NULL,
                            nivelOperacion  TEXT NOT NULL,
                            bienOperacion   INT NOT NULL,
                            malOperacion    INT NOT NULL,
                            fechaOperacion  TEXT NOT NULL)");

            db.ExecSQL("INSERT INTO registros(operacion,nivelOperacion,bienOperacion,malOperacion,fechaOperacion)VALUES(\"Suma\",\"Nivel 1\",2,2,\"30-08-2016\")");
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            db.ExecSQL("DROP TABLE IF EXISTS registros");
            OnCreate(db);
        }

        //Retrive All Contact Details
        public IList<RegistroPractica> GetAllContacts()
        {
            SQLiteDatabase db = this.ReadableDatabase;

            ICursor c = db.Query("registros", new string[] { "idOperacion", "operacion", "nivelOperacion", "bienOperacion", "malOperacion", "fechaOperacion" }, null, null, null, null, null);

            var contacts = new List<RegistroPractica>();

            while (c.MoveToNext())
            {
                contacts.Add(new RegistroPractica
                {
                    idOperacion = c.GetInt(0),
                    operacion = c.GetString(1),
                    nivelOperacion = c.GetString(2),
                    bienOperacion = c.GetInt(3),
                    malOperacion = c.GetInt(4),
                    fechaOperacion = c.GetString(5)
                });
            }

            c.Close();
            db.Close();

            return contacts;
        }

        //Retrive All Contact Details
        public IList<RegistroPractica> GetContactsBySearchName(string nameToSearch)
        {

            SQLiteDatabase db = this.ReadableDatabase;

            ICursor c = db.Query("registros", new string[] { "idOperacion", "operacion", "nivelOperacion", "bienOperacion", "malOperacion", "fechaOperacion" }, "upper(operacion) LIKE ?", new string[] { "%" + nameToSearch.ToUpper() + "%" }, null, null, null, null);

            var contacts = new List<RegistroPractica>();

            while (c.MoveToNext())
            {
                contacts.Add(new RegistroPractica
                {
                    idOperacion = c.GetInt(0),
                    operacion = c.GetString(1),
                    nivelOperacion = c.GetString(2),
                    bienOperacion = c.GetInt(3),
                    malOperacion = c.GetInt(4),
                    fechaOperacion = c.GetString(5)
                });
            }

            c.Close();
            db.Close();

            return contacts;
        }

        //Add New Contact
        public void AddNewContact(RegistroPractica contactinfo)
        {
            SQLiteDatabase db = this.WritableDatabase;
            ContentValues vals = new ContentValues();
            vals.Put("operacion", contactinfo.operacion);
            vals.Put("nivelOperacion", contactinfo.nivelOperacion);
            vals.Put("bienOperacion", contactinfo.bienOperacion);
            vals.Put("malOperacion", contactinfo.malOperacion);
            vals.Put("fechaOperacion", contactinfo.fechaOperacion);
            db.Insert("registros", null, vals);
        }

        //Get contact details by contact Id
        public ICursor getContactById(int id)
        {
            SQLiteDatabase db = this.ReadableDatabase;
            ICursor res = db.RawQuery("SELECT * FROM registros WHERE idOperacion=" + id + "", null);
            return res;
        }

        //Delete Existing contact
        public void DeleteContact(string contactId)
        {
            if (contactId == null)
            {
                return;
            }

            //Obtain writable database
            SQLiteDatabase db = this.WritableDatabase;

            ICursor cursor = db.Query("registros",
                    new String[] { "idOperacion", "operacion", "nivelOperacion", "bienOperacion", "malOperacion", "fechaOperacion" }, "idOperacion=?", new string[] { contactId }, null, null, null, null);

            if (cursor != null)
            {
                if (cursor.MoveToFirst())
                {
                    // update the row
                    db.Delete("registros", "idOperacion=?", new String[] { cursor.GetString(0) });
                }

                cursor.Close();
            }
        }
    }
}