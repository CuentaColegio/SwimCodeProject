using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleScraping.Model.Recursos
{
    public class RecursosProyectoClass
    {
        private List<BibliotecaClass> _bibliotecas = new List<BibliotecaClass>();
        private List<ColecionClass> _colecciones = new List<ColecionClass>();
        private List<EstanteriaClass> _estanterias = new List<EstanteriaClass>();
        private List<FileInfoClass> _filesInfo = new List<FileInfoClass>();
        private List<FolderInfoClass> _foldersInfo = new List<FolderInfoClass>();
        private string _nombreProyecto = "";
        private string _infoRecursos = "";

        public RecursosProyectoClass()
        {
        }

        public string Nombre
        {
            get { return _nombreProyecto; }
            set { _nombreProyecto = value; }
        }
        public string InfoRecursos
        {
            get { return _infoRecursos; }
            set { _infoRecursos = value; }
        }
        public List<FileInfoClass> FilesInfos
        {
            get { return _filesInfo; }
            set { _filesInfo = value; }
        }
        public List<FolderInfoClass> FolderInfo
        {
            get { return _foldersInfo; }
            set { _foldersInfo = value; }
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
        public List<BibliotecaClass> Bibliotecas
        {
            get { return _bibliotecas; }
            set { _bibliotecas = value; }
        }
    }
}
