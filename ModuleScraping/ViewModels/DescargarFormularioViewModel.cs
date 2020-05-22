using HtmlAgilityPack;
using ModuleScraping.Model.Raspado;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;

namespace ModuleScraping.ViewModels
{
    class DescargarFormularioViewModel : BindableBase, INavigationAware
    {
        #region Atributos
        private SpiderClass spiderClass;
        private string _pathCorrecta = "URL no introducida";
        private string _title = "Descargar Web/s";
        private string _path = "Introducir URI...";
        private System.Windows.Media.Brush _foregroundColor = System.Windows.Media.Brushes.Black;

        // Lista para guardar Doc. Html descargados
        List<HtmlDocument> htmls = new List<HtmlDocument>();
        #endregion

        #region Propiedades
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); 
            }
        }
        public string PathCorrecta
        {
            get { return _pathCorrecta; }
            set
            {
                SetProperty(ref _pathCorrecta, value);

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
        public string Path
        {
            get { return _path; }
            set { 
                    SetProperty(ref _path, value);
                    if(UrlValida(_path)){
                        PathCorrecta = "Valida";
                        ForegroundColor = System.Windows.Media.Brushes.Green;
                }
                else
                {
                    PathCorrecta = "No valida";
                    ForegroundColor = System.Windows.Media.Brushes.Red;
                }
                }
        }

        #endregion

        #region Constructor
        public DescargarFormularioViewModel()
        {
            spiderClass = new SpiderClass();
            DescargarUrl = new DelegateCommand(DescargarURl);
        }
        #endregion

        #region Comandos
        public DelegateCommand DescargarUrl { get; private set; }

        #endregion

        #region Métodos
        // Descargamos URI
        private void DescargarURl()
        {
            spiderClass.DescargarPagina(_path);
        }

        // Verificamos URI
        private Boolean UrlValida(string URI)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(URI, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            return result;
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
