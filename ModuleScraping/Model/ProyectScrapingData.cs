using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ModuleScraping.Model
{
    public class ProyectScrapingData
    {
        #region Excepciones
        static Exception DocumentoExisteException = new Exception("El documento ya existe");
        #endregion

        #region Atributos
        // Documentos Cargados
        private Dictionary<string, HtmlDocument> _docCargados;
        // Lista de nombres cargados
        private List<string> _nombresCargados;
        // Lista de nombres descargados
        private List<string> _nombresDescargados;
        // Documentos Descargados
        private Dictionary<string, HtmlDocument> _docDescargados;
        #endregion

        #region Propiedades
        public Dictionary<string, HtmlDocument> DocDescargados
        {
            get { return _docCargados; }
            private set { _docCargados = value; }
        }
        public Dictionary<string, HtmlDocument> DocCargados
        {
            get { return _docCargados; }
            set { _docCargados = value; }
        }
        public List<string> NombresCargados
        {
            get { return _nombresCargados; }
            set { _nombresCargados = value; }
        }
        public List<string> NombresDescargados
        {
            get { return _nombresDescargados; }
            set { _nombresDescargados = value; }
        }
        #endregion

        #region Constructores
        public ProyectScrapingData() {
            _docCargados = new Dictionary<string, HtmlDocument>();
            _docDescargados = new Dictionary<string, HtmlDocument>();
            _nombresCargados = new List<string>();
            _nombresDescargados = new List<string>();
        }
        #endregion

        #region Métodos
        // Te dice si existe el documento en cargados
        public Boolean ExisteDocCargado(string Nombre)
        {
            foreach (KeyValuePair<string, HtmlDocument> item in DocCargados)
            {
                if(item.Key.ToString() == Nombre)
                {
                    return true;
                }
            }
            return false;
        }

        // Te dice si existe el documento en Descargados
        public Boolean ExisteDocDescargado(string URI)
        {
            foreach (KeyValuePair<string, HtmlDocument> item in DocDescargados)
            {
                if (item.Key.ToString() == URI)
                {
                    return true;
                }
            }
            return false;
        }
        // Metodo para guardar Doc. Descargados
        // Valgase la ambiguedad
        public void CargarDocDescargado(string URI, HtmlDocument htmlDocument)
        {
            // Si no existe cargar excepción
            if (!ExisteDocDescargado(URI)) {
                DocDescargados.Add(URI, htmlDocument);
                NombresDescargados.Add(URI);
            }
            else
            {
                throw DocumentoExisteException;
            }
        }
        // Metodo para guardar Doc. Cargados
        // Valgase la ambiguedad
        public void CargarDocCargado(string Path, HtmlDocument htmlDocument)
        {
            if (!ExisteDocCargado(Path))
            {
                DocCargados.Add(Path, htmlDocument);
                NombresCargados.Add(Path);
            }
            else
            {
                MessageBox.Show("El documento ya existe");
            }
        }

        #endregion
    }
}
