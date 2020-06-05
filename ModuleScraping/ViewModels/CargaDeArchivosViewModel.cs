using HtmlAgilityPack;
using ModuleScraping.Model;
using ModuleScraping.Model.Raspado;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using ProyectoFinal.Core.Servicios;
using System.ComponentModel;
using System.Windows;
using System.Linq.Expressions;

namespace ModuleScraping.ViewModels
{
    class CargaDeArchivosViewModel : BindableBase, INavigationAware
    {
        #region Atributos
        private ProyectScrapingData _spcrapingData;
        private SpiderClass spiderClass;
        private string _URICorrecta = "URI no introducida";
        private string _title = "Cargar documentos";
        private string _URI = "Introducir URI...";
        private string _path = "Introduzca path";
        private string _pathCarpeta = "Introduzca path";
        private System.Windows.Media.Brush _foregroundColor = System.Windows.Media.Brushes.Black;
        private IDialogService _dialogService;

        // Lista para guardar Doc. Html descargados
        List<HtmlDocument> htmls = new List<HtmlDocument>();
        #endregion

        #region Propiedades
        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
            }
        }

        public string URICorrecta
        {
            get { return _URICorrecta; }
            set
            {
                SetProperty(ref _URICorrecta, value);

            }
        }
        public string Path
        {
            get { return _path; }
            set
            {
                SetProperty(ref _path, value);

            }
        }
        public string PathCarpeta
        {
            get { return _pathCarpeta; }
            set
            {
                SetProperty(ref _pathCarpeta, value);

            }
        }
        public System.Windows.Media.Brush ForegroundColor
        {
            get { return _foregroundColor; }
            set
            {
                _foregroundColor = value;
                SetProperty(ref _foregroundColor, value);
            }
        }
        public string URI
        {
            get { return _URI; }
            set
            {
                SetProperty(ref _URI, value);
                if (UrlValida(_URI))
                {
                    URICorrecta = "Valida";
                    ForegroundColor = System.Windows.Media.Brushes.Green;
                }
                else
                {
                    URICorrecta = "No valida";
                    ForegroundColor = System.Windows.Media.Brushes.Red;
                }
            }
        }
        public ProyectScrapingData SpcrapingData
        {
            get { return _spcrapingData; }
            set { SetProperty(ref _spcrapingData, value); }
        }
        #endregion

        #region Constructor
        public CargaDeArchivosViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            spiderClass = new SpiderClass();
            DescargarURI = new DelegateCommand(DescargarURl);
            CargarArchivoCommand = new DelegateCommand(CargarArchivo);
            CargarCarpetaCommand = new DelegateCommand(CargarCarpeta);
            CargarPathArchivoServiceCommand = new DelegateCommand(FileDialogServiceArchivo);
            CargarPathCarpetaServiceCommand = new DelegateCommand(FileDialogServiceCarpeta);
        }
        #endregion

        #region Comandos
        public DelegateCommand DescargarURI { get; private set; }
        public DelegateCommand CargarArchivoCommand { get; private set; }
        public DelegateCommand CargarCarpetaCommand { get; private set; }
        public DelegateCommand CargarPathArchivoServiceCommand { get; private set; }
        public DelegateCommand CargarPathCarpetaServiceCommand { get; private set; }

        #endregion

        #region Métodos
        // Descargamos URI
        private void DescargarURl()
        {

            try
            {
                if (UrlValida(_URI))
                {
                    HtmlDocument doc = spiderClass.DescargarPagina(_URI);
                    SpcrapingData.CargarDocDescargado(_URI, doc);
                }
            }
            catch (Exception e)
            {
                ShowDialog(e.Message);
            }

        }
        private void ShowDialog(string message)
        {
            //using the dialog service as-is
            _dialogService.ShowDialog("NotificationDialog", new DialogParameters($"message={message}"), r =>
            { });
        }
        // Verificamos URI
        private Boolean UrlValida(string URI)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(URI, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            return result;
        }
        // Desca y guarda en SpcrapingData
        private void CargarArchivo()
        {
            try
            {
                SpcrapingData.CargarDocCargado(Path, Archivos.CargarArchivoEnDoc(Path));
            }catch(Exception e)
            {
                MessageBox.Show("Path incorrecta");
            }
         }

        private void CargarCarpeta()
        {
            
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = false;
            worker.DoWork += worker_CargarCarpeta;
            worker.RunWorkerCompleted += worker_CargarCarpetaCompleted;
            worker.RunWorkerAsync(PathCarpeta);
        }

        void worker_CargarCarpeta(object sender, DoWorkEventArgs e)
        {
            try{ 
            string path = (string)e.Argument;
            Dictionary<string, HtmlDocument> DocumentosACargar;
            // Cargamos documentos de la memoria
            DocumentosACargar = Archivos.CargarDocsHtml(path);
            e.Result = DocumentosACargar;
                // Miramos si estan ya cargados, y si no, lo Cargamos
            }
            catch(Exception ex){
                MessageBox.Show("Path incorrecta");
                e.Result = "";
            }

            
        }
        void worker_CargarCarpetaCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                //MessageBox.Show("Numbers between 0 and 10000 divisible by 7: ");
                foreach (KeyValuePair<string, HtmlDocument> item in (Dictionary<string, HtmlDocument>)e.Result)
            {
                SpcrapingData.CargarDocCargado(item.Key.ToString(), item.Value);
            }
            }
            catch (Exception ex)
            {
            }
        }


        // Abrimos buscador de archivos de Windows
        private void FileDialogServiceArchivo()
        {
            string resultado = VentanaFileDialogService.VentanaFileDialogArchivoLaunch();
            if(resultado != null)
            {
                Path = resultado;
            }
        }

        private void FileDialogServiceCarpeta()
        {
            string resultado = VentanaFileDialogService.VentanaFileDialogCarpetaLaunch();
            if (resultado != null)
            {
                PathCarpeta = resultado;
            }
        }

        #region MétodosNavegación
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
        #endregion
        #endregion
    }
}
