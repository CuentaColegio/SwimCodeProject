using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleScraping.Model.Recursos
{
    public class EstanteriaClass
    {
        private List<FileInfoClass> _filesInfo = new List<FileInfoClass>();
        private List<FolderInfoClass> _foldersInfo = new List<FolderInfoClass>();
        private string _infoEstanteria = "";
        private string _nombre = "";

        public EstanteriaClass()
        {
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public EstanteriaClass(List<FileInfoClass> filesInfos, List<FolderInfoClass> folderInfo)
        {
            FilesInfos = filesInfos;
            FolderInfo = folderInfo;
        }
        public string InfoEstanteria
        {
            get { return _infoEstanteria; }
            set { _infoEstanteria = value; }
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

        public Dictionary<string, string> GetArchivosEstanteria()
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();

            for (int i = 0; i <= _filesInfo.Count; i++)
            {
                resultado.Add(_filesInfo[i].Nombre, _filesInfo[i].Path);
            }

            return resultado;
        }
        public Dictionary<string, string> GetCarpetasEstanteria()
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();

            for (int i = 0; i <= _foldersInfo.Count; i++)
            {
                resultado.Add(_foldersInfo[i].Nombre, _foldersInfo[i].Path);
            }

            return resultado;
        }
    }
}
