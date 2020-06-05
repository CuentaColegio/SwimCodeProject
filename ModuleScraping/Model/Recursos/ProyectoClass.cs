using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleScraping.Model.Recursos
{
    public class ProyectoClass
    {
        private RecursosProyectoClass _recursosProyecto = new RecursosProyectoClass();
        private PropiedadesProyectoClass _propiedadesProyecto = new PropiedadesProyectoClass();

        public ProyectoClass()
        {
        }

        public RecursosProyectoClass RecursosProyecto
        {
            get { return _recursosProyecto; }
            set { _recursosProyecto = value; }
        }

        public PropiedadesProyectoClass PropiedadesProyecto
        {
            get { return _propiedadesProyecto; }
            set { _propiedadesProyecto = value; }
        }

        #region MetodosBibliotecas
        public List<BibliotecaClass> GetBibliotecas()
        {
            return _recursosProyecto.Bibliotecas;
        }

        public List<string> GetNombreBibliotecas()
        {
            List<string> nombres = new List<string>();

            for(int i = 0; i < _recursosProyecto.Bibliotecas.Count; i++)
            {
                nombres.Add(_recursosProyecto.Bibliotecas[i].Nombre);
            }

            return nombres;
        }

        public List<EstanteriaClass> GetEstanteriasBibliotecas()
        {
            List<EstanteriaClass> resultado = new List<EstanteriaClass>();

            for (int i = 0; i < _recursosProyecto.Bibliotecas.Count; i++)
            {
                for (int i1 = 0; i1 < _recursosProyecto.Bibliotecas[i].Estanterias.Count; i1++)
                {
                    resultado.Add(_recursosProyecto.Bibliotecas[i].Estanterias[i1]);
                }
            }

            return resultado;
        }
        public List<ColecionClass> GetColeccionesBibliotecas()
        {
            List<ColecionClass> resultado = new List<ColecionClass>();

            for (int i = 0; i < _recursosProyecto.Bibliotecas.Count; i++)
            {
                for (int i1 = 0; i1 < _recursosProyecto.Bibliotecas[i].Colecciones.Count; i1++)
                {
                    resultado.Add(_recursosProyecto.Bibliotecas[i].Colecciones[i1]);
                }
            }

            return resultado;
        }

        public List<FileInfoClass> GetArchivosBibliotecas()
        {
            List<FileInfoClass> resultado = new List<FileInfoClass>();

            for (int i = 0; i < _recursosProyecto.Bibliotecas.Count; i++)
            {
                for (int i1 = 0; i1 < _recursosProyecto.Bibliotecas[i].FilesInfos.Count; i1++)
                {
                    resultado.Add(_recursosProyecto.Bibliotecas[i].FilesInfos[i1]);
                }
            }

            return resultado;
        }
        public List<FolderInfoClass> GetCarpetasBibliotecas()
        {
            List<FolderInfoClass> resultado = new List<FolderInfoClass>();

            for (int i = 0; i < _recursosProyecto.Bibliotecas.Count; i++)
            {
                for (int i1 = 0; i1 < _recursosProyecto.Bibliotecas[i].FolderInfo.Count; i1++)
                {
                    resultado.Add(_recursosProyecto.Bibliotecas[i].FolderInfo[i1]);
                }
            }

            return resultado;
        }
        #endregion

        #region MetodosArchivosIndependientes
        public List<FileInfoClass> GetArchivosIndependientes()
        {
            return _recursosProyecto.FilesInfos;
        }
        public List<string> GetNombreArchivosIndependientes()
        {
            List<string> resultado = new List<string>();

            for (int i = 0; i < _recursosProyecto.FilesInfos.Count; i++)
            {
                resultado.Add(_recursosProyecto.FilesInfos[i].Nombre);
            }

            return resultado;
        }
        public Dictionary<string, string> GetDiccArchivosIndependientes()
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();

            for (int i = 0; i < _recursosProyecto.FilesInfos.Count; i++)
            {
                resultado.Add(_recursosProyecto.FilesInfos[i].Nombre, _recursosProyecto.FilesInfos[i].Path);
            }

            return resultado;
        }

        public List<FolderInfoClass> GetCarpetasIndependientes()
        {
            return _recursosProyecto.FolderInfo;
        }
        public List<string> GetNombresCarpetasIndependientes()
        {
            List<string> resultado = new List<string>();

            for (int i = 0; i < _recursosProyecto.FolderInfo.Count; i++)
            {
                resultado.Add(_recursosProyecto.FolderInfo[i].Nombre);
            }

            return resultado;
        }
        public Dictionary<string, string> GetDiccCarpetasIndependientes()
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();

            for (int i = 0; i < _recursosProyecto.FolderInfo.Count; i++)
            {
                resultado.Add(_recursosProyecto.FolderInfo[i].Nombre, _recursosProyecto.FolderInfo[i].Path);
            }

            return resultado;
        }

        public List<EstanteriaClass> GetEstanteriasIndependientes()
        {
            return _recursosProyecto.Estanterias;
        }
        public List<string> GetNombreEstanteriasIndependientes()
        {
            List<string> resultado = new List<string>();

            for (int i = 0; i < _recursosProyecto.Estanterias.Count; i++)
            {
                resultado.Add(_recursosProyecto.Estanterias[i].Nombre);
            }

            return resultado;
        }
        public Dictionary<string, string> GetDiccArhivosEstanteriasIndependientes()
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();

            for (int i = 0; i < _recursosProyecto.Estanterias.Count; i++)
            {
                foreach (var dict in _recursosProyecto.Estanterias[i].GetArchivosEstanteria())
                {
                    resultado.Add(dict.Key, dict.Value);
                }
            }

            return resultado;
        }
        public Dictionary<string, string> GetDiccCarpetasEstanteriasIndependientes()
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();

            for (int i = 0; i < _recursosProyecto.Estanterias.Count; i++)
            {
                foreach (var dict in _recursosProyecto.Estanterias[i].GetCarpetasEstanteria())
                {
                    resultado.Add(dict.Key, dict.Value);
                }
            }

            return resultado;
        }

        public List<ColecionClass> GetColeccionesIndependientes()
        {
            return _recursosProyecto.Colecciones;
        }
        public List<string> GetNombreColeccionesIndependientes()
        {
            List<string> resultado = new List<string>();

            for (int i = 0; i < _recursosProyecto.Colecciones.Count; i++)
            {
                resultado.Add(_recursosProyecto.Colecciones[i].Nombre);
            }

            return resultado;
        }


        #endregion
    }
}
