using System.Collections.Generic;
using System.Xml;

namespace ModuleScraping.Model.Recursos
{
    class XmlProyecto
    {
        public XmlDocument doc;
        string rutaXml = "";

        public XmlProyecto()
        {
            doc = new XmlDocument();
        }

        public void _Añadir(string id, string nom, string ape, string dir)
        {

        }
        public void crearXml(string ruta, string nombre)
        {
            doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlNode root = doc.DocumentElement;

            doc.InsertBefore(xmlDeclaration, root);



            XmlNode element1 = doc.CreateElement("proyecto");
            doc.AppendChild(element1);

            XmlNode nodeToAppend = doc.CreateElement("propiedades");
            nodeToAppend.InnerText = "This title is created by code";



            /* Append node to parent */
            XmlNode firstNode = doc.SelectSingleNode("proyecto");
            firstNode.AppendChild(nodeToAppend);


            // proyecto
            // proyecto\propiedades
            // proyecto\recursos
            // proyecto\recursos\bibliotecas
            // proyecto\recursos\colecciones
            // proyecto\recursos\estanterias
            // proyecto\recursos\carpetas
            // proyecto\recursos\archivos

            doc.Save(ruta);
        }
        /*
        public void CrearProyectoDemo(string ruta, string nombre)
        {
            doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlNode Ruta = doc.DocumentElement;
            XmlElement Elemento = doc.DocumentElement; ;
            XmlAttribute attr;

            doc.InsertBefore(xmlDeclaration, Ruta);

            XmlNode ElementoAInsertar = doc.CreateElement("proyecto");
            doc.AppendChild(ElementoAInsertar);

            // Creamos estructura
            Ruta = doc.SelectSingleNode("proyecto");
            ElementoAInsertar = doc.CreateElement("propiedades");

            ElementoAInsertar.AppendChild(doc.CreateElement("nombre"));
            ElementoAInsertar.AppendChild(doc.CreateElement("resumen"));
            ElementoAInsertar.AppendChild(doc.CreateElement("InfoProyecto"));

            Ruta.AppendChild(ElementoAInsertar);
           
            ElementoAInsertar = doc.CreateElement("recursos");
            attr = doc.CreateAttribute("nombre");
            attr.Value = nombre;
            ElementoAInsertar.Attributes.SetNamedItem(attr);

            Ruta.AppendChild(ElementoAInsertar);

            doc.Save(ruta);
        }
        */
        public void CrearProyecto(string ruta, string nombre, string resumen, string infoProyecto)
        {
            doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlNode Ruta = doc.DocumentElement;
            XmlNode Comodin = doc.DocumentElement;

            doc.InsertBefore(xmlDeclaration, Ruta);
            doc.AppendChild(doc.CreateElement("proyecto"));
            Ruta = doc.SelectSingleNode("proyecto");

            // Creamos propiedades

            Comodin = InsertarNodoEnNodo(CrearNodo("propiedades"), CrearNodo("nombre", nombre));
            Comodin = InsertarNodoEnNodo(Comodin, CrearNodo("resumen", resumen));
            Comodin = InsertarNodoEnNodo(Comodin, CrearNodo("infoProyecto", infoProyecto));

            Ruta.AppendChild(Comodin);

            // Creamos resources

            Comodin = CrearNodo("recursos");
            Comodin = InsertarAtributo(Comodin, "nombre", "recursos" + nombre);
            Comodin = InsertarNodoEnNodo(Comodin, CrearNodo("infoRecursos"));
            Comodin = InsertarNodoEnNodo(Comodin, CrearNodo("bibliotecas"));
            Comodin = InsertarNodoEnNodo(Comodin, CrearNodo("colecciones"));
            Comodin = InsertarNodoEnNodo(Comodin, CrearNodo("estanterias"));

            Ruta.AppendChild(Comodin);

            // Borrar esta mierda
            string n = Ruta.ToString();



            doc.Save(ruta);
        }


        private XmlNode CrearNodo(string nombre, string contenido)
        {
            XmlNode nodo = doc.CreateElement(nombre);
            nodo.InnerText = contenido;
            return nodo;
        }
        private XmlNode CrearNodo(string nombre)
        {
            XmlNode nodo = doc.CreateElement(nombre);

            return nodo;
        }

        private XmlNode InsertarContenidoANodo(string contenido, XmlNode nodo)
        {
            nodo.InnerText = contenido;
            return nodo;
        }
        // https://es.stackoverflow.com/questions/132219/c%C3%B3mo-agregar-atributo-a-documento-xml
        private XmlNode InsertarAtributo(XmlNode nodo, string nombreAtributo, string contenido)
        {
            XmlAttribute attr = doc.CreateAttribute(nombreAtributo);
            attr.Value = contenido;

            nodo.Attributes.SetNamedItem(attr);

            return nodo;
        }

        private XmlNode InsertarNodoEnNodo(XmlNode nodo, XmlNode nodoHijo)
        {
            nodo.AppendChild(nodoHijo);

            return nodo;
        }

        // Carga proyectoXML
        public ProyectoClass CargarProyectoXML(string URIProyectoXML)
        {
            RecursosProyectoClass _recursosProyecto = new RecursosProyectoClass();
            PropiedadesProyectoClass _propiedadesProyecto = new PropiedadesProyectoClass();
            ProyectoClass proyecto = new ProyectoClass();

            doc.Load(URIProyectoXML);

            XmlNode NodoPropiedades = doc.SelectSingleNode("proyecto/propiedades");
            XmlNode NodoRecursos = doc.SelectSingleNode("proyecto/recursos");

            proyecto.PropiedadesProyecto = ReadPropiedadesProyecto(NodoPropiedades);
            proyecto.RecursosProyecto = ReadRecursosProyecto(NodoRecursos);

            return proyecto;
        }

        // Cargar propiedades del proyecto
        private PropiedadesProyectoClass ReadPropiedadesProyecto(XmlNode Propiedades)
        {
            PropiedadesProyectoClass resultado = new PropiedadesProyectoClass();
            XmlNodeList listaNodosPropiedades = Propiedades.ChildNodes;

            for (int i = 0; i < listaNodosPropiedades.Count; i++)
            {
                if (listaNodosPropiedades.Item(i).Name == "nombre")
                    resultado.NombreProyecto = listaNodosPropiedades.Item(i).InnerText;

                if (listaNodosPropiedades.Item(i).Name == "resumen")
                    resultado.Resumen = listaNodosPropiedades.Item(i).InnerText;

                if (listaNodosPropiedades.Item(i).Name == "InfoProyecto")
                    resultado.InfoProyecto = listaNodosPropiedades.Item(i).InnerText;
            }
            return resultado;
        }

        // Cargar todos los recursos del proyecto
        private RecursosProyectoClass ReadRecursosProyecto(XmlNode NodoRecursos)
        {
            RecursosProyectoClass recursosProyecto = new RecursosProyectoClass();
            XmlNodeList listaNodosRecursos = NodoRecursos.ChildNodes;

            for (int i = 0; i < listaNodosRecursos.Count; i++)
            {
                if (listaNodosRecursos.Item(i).Name == "infoRecursos")
                    recursosProyecto.InfoRecursos = listaNodosRecursos.Item(i).InnerText;

                if (listaNodosRecursos.Item(i).Name == "bibliotecas")
                    recursosProyecto.Bibliotecas = ReadBibliotecas(listaNodosRecursos.Item(i));

                if (listaNodosRecursos.Item(i).Name == "estanterias")
                    recursosProyecto.Estanterias = ReadEstanterias(listaNodosRecursos.Item(i));

                if (listaNodosRecursos.Item(i).Name == "colecciones")
                    recursosProyecto.Colecciones = ReadColecciones(listaNodosRecursos.Item(i));

                if (listaNodosRecursos.Item(i).Name == "carpetas")
                    recursosProyecto.FolderInfo = ReadCarpetas(listaNodosRecursos.Item(i));

                if (listaNodosRecursos.Item(i).Name == "archivos")
                    recursosProyecto.FilesInfos = ReadArchivos(listaNodosRecursos.Item(i));


                recursosProyecto.Nombre = NodoRecursos.Attributes["nombre"].Value;
            }

            return recursosProyecto;
        }

        // cargar todas las bibliotecas
        private List<BibliotecaClass> ReadBibliotecas(XmlNode bibliotecas)
        {
            List<BibliotecaClass> resultado = new List<BibliotecaClass>();
            XmlNodeList listaNodosBibliotecas = bibliotecas.ChildNodes;

            for (int i = 0; i < listaNodosBibliotecas.Count; i++)
            {
                resultado.Add(ReadBiblioteca(listaNodosBibliotecas.Item(i)));
            }
            return resultado;
        }
        // cargamos biblioteca
        private BibliotecaClass ReadBiblioteca(XmlNode biblioteca)
        {
            BibliotecaClass resultado = new BibliotecaClass();
            XmlNodeList listaNodosBilblioteca = biblioteca.ChildNodes;


            for (int i = 0; i < listaNodosBilblioteca.Count; i++)
            {
                if (listaNodosBilblioteca.Item(i).Name == "carpetas")
                    resultado.FolderInfo = ReadCarpetas(listaNodosBilblioteca.Item(i));

                if (listaNodosBilblioteca.Item(i).Name == "archivos")
                    resultado.FilesInfos = ReadArchivos(listaNodosBilblioteca.Item(i));

                if (listaNodosBilblioteca.Item(i).Name == "infoBiblioteca")
                    resultado.InfoBiblioteca = listaNodosBilblioteca.Item(i).InnerText;

                if (listaNodosBilblioteca.Item(i).Name == "estanterias")
                    resultado.Estanterias = ReadEstanterias(listaNodosBilblioteca.Item(i));

                if (listaNodosBilblioteca.Item(i).Name == "colecciones")
                    resultado.Colecciones = ReadColecciones(listaNodosBilblioteca.Item(i));

                resultado.Nombre = biblioteca.Attributes["nombre"].Value;
            }
            return resultado;
        }

        // carga colecciones
        private List<ColecionClass> ReadColecciones(XmlNode colecciones)
        {
            List<ColecionClass> resultado = new List<ColecionClass>();
            XmlNodeList listaNodosColecciones = colecciones.ChildNodes;

            for (int i = 0; i < listaNodosColecciones.Count; i++)
            {
                resultado.Add(ReadColeccion(listaNodosColecciones.Item(i)));
            }
            return resultado;
        }

        // Cargar coleccion
        private ColecionClass ReadColeccion(XmlNode coleccion)
        {
            ColecionClass resultado = new ColecionClass();
            XmlNodeList listaNodosColeccion = coleccion.ChildNodes;


            for (int i = 0; i < listaNodosColeccion.Count; i++)
            {
                if (listaNodosColeccion.Item(i).Name == "carpetas")
                    resultado.FolderInfo = ReadCarpetas(listaNodosColeccion.Item(i));

                if (listaNodosColeccion.Item(i).Name == "archivos")
                    resultado.FilesInfos = ReadArchivos(listaNodosColeccion.Item(i));

                if (listaNodosColeccion.Item(i).Name == "infoColeccion")
                    resultado.InfoColeccion = listaNodosColeccion.Item(i).Value;

                if (listaNodosColeccion.Item(i).Name == "estanterias")
                    resultado.Estanterias = ReadEstanterias(listaNodosColeccion.Item(i));

                resultado.Nombre = coleccion.Attributes["nombre"].Value;
            }
            return resultado;
        }
        // Carga cada estanteria en listaEstanterias
        private List<EstanteriaClass> ReadEstanterias(XmlNode estanterias)
        {
            List<EstanteriaClass> resultado = new List<EstanteriaClass>();
            XmlNodeList listaNodosEstanterias = estanterias.ChildNodes;

            for (int i = 0; i < listaNodosEstanterias.Count; i++)
            {
                resultado.Add(ReadEstanteria(listaNodosEstanterias.Item(i)));
            }
            return resultado;
        }
        // Cargar estanteria
        private EstanteriaClass ReadEstanteria(XmlNode estanteria)
        {
            EstanteriaClass resultado = new EstanteriaClass();
            XmlNodeList listaNodosEstanteria = estanteria.ChildNodes;

            for (int i = 0; i < listaNodosEstanteria.Count; i++)
            {

                if (listaNodosEstanteria.Item(i).Name == "carpetas")
                    resultado.FolderInfo = ReadCarpetas(listaNodosEstanteria.Item(i));

                if (listaNodosEstanteria.Item(i).Name == "archivos")
                    resultado.FilesInfos = ReadArchivos(listaNodosEstanteria.Item(i));

                if (listaNodosEstanteria.Item(i).Name == "infoEstanteria")
                    resultado.InfoEstanteria = listaNodosEstanteria.Item(i).Value;
            }
            return resultado;
        }
        // Carga todos los Archivos en archivos, desde un nodo archivos
        private List<FileInfoClass> ReadArchivos(XmlNode archivos)
        {
            List<FileInfoClass> resultado = new List<FileInfoClass>();
            XmlNodeList listaNodosArchivos = archivos.ChildNodes;
            XmlNode Archivo;

            for (int i = 0; i < listaNodosArchivos.Count; i++)
            {
                Archivo = listaNodosArchivos.Item(i);
                resultado.Add(ReadArchivo(Archivo));
            }

            return resultado;
        }

        // Carga nombre y path en FileInfoClass, desde un nodo archivo
        private FileInfoClass ReadArchivo(XmlNode archivo)
        {
            FileInfoClass resultado = new FileInfoClass();

            resultado.Nombre = archivo.Attributes["nombre"].Value;
            resultado.Path = archivo.Attributes["path"].Value;

            return resultado;
        }
        // Carga todos las Carpetas en carpetas, desde un nodo carpetas
        private List<FolderInfoClass> ReadCarpetas(XmlNode carpetas)
        {
            List<FolderInfoClass> resultado = new List<FolderInfoClass>();
            XmlNodeList listaNodosCarpetas = carpetas.ChildNodes;
            XmlNode Carpeta;

            for (int i = 0; i < listaNodosCarpetas.Count; i++)
            {
                Carpeta = listaNodosCarpetas.Item(i);
                resultado.Add(ReadCarpeta(Carpeta));
            }
            return resultado;
        }

        // Carga nombre y path en FolderInfoClass, desde un nodo carpeta
        private FolderInfoClass ReadCarpeta(XmlNode carpeta)
        {
            FolderInfoClass resultado = new FolderInfoClass();

            resultado.Nombre = carpeta.Attributes["nombre"].Value;
            resultado.Path = carpeta.Attributes["path"].Value;

            return resultado;
        }

        public void _DeleteNodo(string id_borrar)
        {
        }

        public void _UpdateXml(string id_update, string nom, string ape, string dir)
        {
        }
    }
}
