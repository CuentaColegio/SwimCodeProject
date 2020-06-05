using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleScraping.Model.Recursos
{
    public class BibliotecaClass
    {
        private List<ColecionClass> _colecciones = new List<ColecionClass>();
        private List<EstanteriaClass> _estanterias = new List<EstanteriaClass>();
        private List<FileInfoClass> _files = new List<FileInfoClass>();
        private List<FolderInfoClass> _carpetas = new List<FolderInfoClass>();
        private string _infoBiblioteca = "";
        private string _nombre = "";

        public BibliotecaClass()
        {
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string InfoBiblioteca
        {
            get { return _infoBiblioteca; }
            set { _infoBiblioteca = value; }
        }
        public List<FileInfoClass> FilesInfos
        {
            get { return _files; }
            set { _files = value; }
        }
        public List<FolderInfoClass> FolderInfo
        {
            get { return _carpetas; }
            set { _carpetas = value; }
        }
        public List<EstanteriaClass> Estanterias
        {
            get { return _estanterias; }
            set { _estanterias = value; }
        }
        public List<ColecionClass> Colecciones
        {
            get { return _colecciones; }
            set { _colecciones = value; }
        }
    }
}
