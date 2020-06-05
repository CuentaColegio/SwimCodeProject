using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleScraping.Model.Recursos
{
    public class PropiedadesProyectoClass
    {
        private string _nombre = "";
        private string _resumen = "";
        private string _infoProyecto = "";

        public PropiedadesProyectoClass() { }

        public string NombreProyecto
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Resumen
        {
            get { return _resumen; }
            set { _resumen = value; }
        }
        public string InfoProyecto
        {
            get { return _infoProyecto; }
            set { _infoProyecto = value; }
        }
    }
}
