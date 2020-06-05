using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleScraping.Model.Recursos
{
    public class FolderInfoClass
    {
        private string _nombre = "";
        private string _path = "";
        private string _info = "";

        public FolderInfoClass(string nombre, string path)
        {
            Nombre = nombre;
            Path = path;
        }

        public FolderInfoClass()
        {
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
    }
}
