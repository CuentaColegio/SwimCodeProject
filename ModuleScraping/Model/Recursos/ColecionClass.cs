using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleScraping.Model.Recursos
{
    public class ColecionClass
    {
        private List<FileInfoClass> _filesInfo = new List<FileInfoClass>();
        private List<FolderInfoClass> _foldersInfo = new List<FolderInfoClass>();
        private List<EstanteriaClass> _estanterias = new List<EstanteriaClass>();
        private string _infoColeccion = "";
        private string _nombre = "";

        public ColecionClass(List<FileInfoClass> filesInfos, List<FolderInfoClass> folderInfo, List<EstanteriaClass> estanterias)
        {
            FilesInfos = filesInfos;
            FolderInfo = folderInfo;
            Estanterias = estanterias;
        }

        public ColecionClass()
        {
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string InfoColeccion
        {
            get { return _infoColeccion; }
            set { _infoColeccion = value; }
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

    }
}
