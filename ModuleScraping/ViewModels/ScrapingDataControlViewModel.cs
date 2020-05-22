using ModuleScraping.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using ProyectoFinal.Core.Commands.BaseCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleScraping.ViewModels
{
    class ScrapingDataControlViewModel : BindableBase, INavigationAware
    {
        // Para ListView
        // https://stackoverflow.com/questions/4703641/what-is-the-difference-between-listbox-and-listview
        #region Atributos
        private ProyectScrapingData _spcrapingData;
        private string _title = "Documentos";
        private List<string> _listaNombresCargados;
        private List<string> _listaNombresDescargados;

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
        public ProyectScrapingData SpcrapingData
        {
            get { return _spcrapingData; }
            set { 
                    SetProperty(ref _spcrapingData, value);
                }
        }
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
        #endregion

        #region Constructores
        public ScrapingDataControlViewModel()
        {
            _listaNombresCargados = new List<string>();
            _listaNombresDescargados = new List<string>();
            RecargarListViewCargadosCommand = new DelegateCommand(RecargarListViewCargados);
            RecargarListViewDescargadosCommand = new DelegateCommand(RecargarListViewDescargados);
        }
        #endregion

        #region Comandos
        public DelegateCommand RecargarListViewCargadosCommand { get; private set; }
        public DelegateCommand RecargarListViewDescargadosCommand { get; private set; }
        #endregion

        #region Métodos
        private void RecargarListViewCargados()
        {
            ListaNombresCargados = _spcrapingData.NombresCargados;
        }
        private void RecargarListViewDescargados()
        {
            ListaNombresDescargados = _spcrapingData.NombresDescargados;
        }
        #region Navigation métodos
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
        #endregion
    }
}
