using Orient.Client;
using Orient.Client.API;
using Orient.Client.API.Query.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal.Core.OrientDB
{
    public class OrientDB
    {
        private ODatabase database;

        public void insertarNodo(string className, string fieldName, string fieldValue)
        {
            database.Insert().Into(className).Set(fieldName, fieldValue);
        }
        /*
        public void insertarNodo(string className, string fieldName, string fieldValue)
        {
            database.Insert().Into(className).Set(fieldName, fieldValue)
                database.
        }*/

        public void openDatabase(string _host, int _port, string _dbName, string _user, string _passwd)
        {

            // CONSOLE LOG
            Console.WriteLine("Opening Database: {0}", _dbName);

            // OPEN DATABASE
            database = new ODatabase(_host, _port, _dbName, ODatabaseType.Graph, _user, _passwd);
        }

    }
}
