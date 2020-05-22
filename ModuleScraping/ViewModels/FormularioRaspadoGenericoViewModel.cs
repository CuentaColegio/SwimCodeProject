using ModuleScraping.Model;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows;
using HtmlAgilityPack;
using System.Collections.Generic;
using Prism.Commands;
using ModuleScraping.Model.Raspado;

namespace ModuleScraping.ViewModels
{
    class FormularioRaspadoGenericoViewModel : BindableBase, INavigationAware
    {
        private Scrapy scrapy;
        private ProyectScrapingData _spcrapingData;
        private string _title = "Raspado generico";
        private string _documentoAScrapear;
        private HtmlDocument _documentoAScrapearHtml;
        private List<string> _listaNombresCargados;
        private List<string> _listaNombresDescargados;
        private List<string> _listaFianal;
        private string _textoConsultaXpath = "";
        private string _resultadoScrapeo = "";


        public List<string> ListaNombresCargados
        {
            get { return _listaNombresCargados; }
            set { SetProperty(ref _listaNombresCargados, value); }
        }
        public List<string> ListaNombresDescargados
        {
            get { return _listaNombresDescargados; }
            set { SetProperty(ref _listaNombresDescargados, value); }
        }
        public List<string> ListaFinal
        {
            get { return _listaFianal; }
            set { SetProperty(ref _listaFianal, value); }
        }
        
        public string ResultadoScrapeo
        {
            get { return _resultadoScrapeo; }
            set { SetProperty(ref _title, _resultadoScrapeo); }
        }
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public string TextoConsultaXpath
        {
            get { return _textoConsultaXpath; }
            set { SetProperty(ref _textoConsultaXpath, value); }
        }

        public HtmlDocument DocumentoAScrapearHtml
        {
            get { return _documentoAScrapearHtml; }
            set
            {
                SetProperty(ref _documentoAScrapearHtml, value);
            }
        }
        public string DocumentoAScrapear
        {
            get { return "Documento Selecionado: " + _documentoAScrapear; }
            set
            {
                SetProperty(ref _documentoAScrapear, value);
            }
        }
        public ProyectScrapingData SpcrapingData
        {
            get { return _spcrapingData; }
            set { SetProperty(ref _spcrapingData, value); }
        }

        public FormularioRaspadoGenericoViewModel()
        {
            _documentoAScrapearHtml = new HtmlDocument();
            RecargarListViewCommand = new DelegateCommand(RecargarListaDocumentosCargados);
            SelectedItemChangesCommand = new DelegateCommand<string>(SelectedItemChanges);
            EjecutarConsultaBox = new DelegateCommand(HacerConsultaXPath);
        }

        public DelegateCommand RecargarListViewCommand { get; private set; }
        public DelegateCommand EjecutarConsultaBox { get; private set; }
        public DelegateCommand<string> SelectedItemChangesCommand { get; private set; }

        private void HacerConsultaXPath()
        {
            scrapy = new Scrapy(DocumentoAScrapearHtml);
            ResultadoScrapeo = scrapy.SeleccionarNodosXPath(TextoConsultaXpath);

        }
        private void SelectedItemChanges(string nombreDoc) {
            DocumentoAScrapear = nombreDoc;
            // si true cargado
            // false descargado
            Boolean Cual = true;
            foreach(var item in ListaNombresCargados)
            {
                if (item.ToString() == nombreDoc)
                {
                    Cual = true;
                }
            }
            foreach (var item in ListaNombresDescargados)
            {
                if (item.ToString() == nombreDoc)
                {
                    Cual = false;
                }
            }

            if (Cual)
            {
                foreach (KeyValuePair<string, HtmlDocument> item in SpcrapingData.DocCargados)
                {
                    if (item.Key.ToString() == nombreDoc)
                    {
                        DocumentoAScrapearHtml = item.Value;
                    }
                }
            }
            else {
                foreach (KeyValuePair<string, HtmlDocument> item in SpcrapingData.DocDescargados)
                {
                    if (item.Key.ToString() == nombreDoc)
                    {
                        DocumentoAScrapearHtml = item.Value;
                    }
                }
            }
             
        }
        private void RecargarListaDocumentosCargados()
        {

            ListaFinal = _spcrapingData.NombresCargados;
            foreach (var nombre in _spcrapingData.NombresDescargados)
            {
                ListaFinal.Add(nombre.ToString());
            }
            RecargarListViewCargados();
            RecargarListViewDescargados();
        }

        private void RecargarListViewCargados()
        {
            ListaNombresCargados = _spcrapingData.NombresCargados;
        }
        private void RecargarListViewDescargados()
        {
            ListaNombresDescargados = _spcrapingData.NombresDescargados;
        }
        #region Navegar
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //this.RegionContext = regionManager.Regions[RegionNames.WorkerShowPersonalDataRegion].Context;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
        #endregion
    }
}
