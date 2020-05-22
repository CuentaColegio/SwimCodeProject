using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using HtmlAgilityPack;

namespace ProyectoFinal.Core.Servicios
{
    public class Archivos
    {
        // Guarda documentos htmls en un path
        public static void GuardarDocHtml(string Doc, string path, string name)
        {
            path.Concat(name);
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write(Doc);
                }
            }
        }
        // Carga todos los .html de un directorio
        public static Dictionary<string, HtmlDocument> CargarDocsHtml(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            Dictionary<string, HtmlDocument> Htmls = new Dictionary<string, HtmlDocument>();
            HtmlDocument ArchivoHtml = new HtmlDocument();

            foreach (var fi in di.GetFiles("*.html"))
            {
                ArchivoHtml.LoadHtml(CargarArchivo(fi.FullName));
                Htmls.Add(fi.Name, ArchivoHtml);
            }

            return Htmls;
        }

        // Carga los archivos indicados por paths
        public static Dictionary<string, string> CargarDocsHtml(List<string> paths)
        {
            Dictionary<string, string> Htmls = new Dictionary<string, string>();
            DirectoryInfo di;

            foreach (var Arch in paths)
            {
                di = new DirectoryInfo(Arch);
                Htmls.Add(di.Name, CargarArchivo(Arch));
            }

            return Htmls;
        }

        // Carga archivo de un path y devuelve string
        public static string CargarArchivo(string path)
        {
            string Resultado = "";
            string linia;

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                while ((linia = sr.ReadLine()) != null)
                {
                    Resultado.Concat("\n" + linia);
                }
            }

            return Resultado;
        }

        public static HtmlDocument CargarArchivoEnDoc(string path)
        {
            string Resultado = "";
            string linia;
            HtmlDocument document = new HtmlDocument();
            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                while ((linia = sr.ReadLine()) != null)
                {
                    Resultado.Concat("\n" + linia);
                }
            }
            document.LoadHtml(Resultado);
            return document;
            /*
            string Resultado = "";
            string linia;
            HtmlDocument ArchivoHtml = new HtmlDocument();
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while ((linia = sr.ReadLine()) != null)
                    {
                        Resultado.Concat("\n" + linia);
                    }
                }

                ArchivoHtml.LoadHtml(Resultado);
            }
            catch (UnauthorizedAccessException)
            {
                FileAttributes attributes = File.GetAttributes(path);
                if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    attributes &= ~FileAttributes.ReadOnly;
                    File.SetAttributes(path, attributes);
                    File.Delete(path);
                }
                else
                {
                    throw;
                }
            }


            return ArchivoHtml;*/
        }
    }
}

