using ModuleScraping.Eventos;
using ModuleScraping.Model;
using ModuleScraping.Model.Recursos;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleScraping.ViewModels
{
    class ScrapingModuleGridViewModel : BindableBase
    {
        //Guarda documentos de scraping
        private ProyectScrapingData _spcrapingData;

        private ProyectoClass proyectoClass = new ProyectoClass();
        IEventAggregator _ea;

        private readonly IRegionManager _regionManager;
        private string _title = "Proyecto Final";
        
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ProyectScrapingData SpcrapingData
        {
            get { return _spcrapingData; }
            set { SetProperty(ref _spcrapingData, value); }

        }

        public ScrapingModuleGridViewModel(IRegionManager regionManager, IEventAggregator ea)
        {
            _ea = ea;

            _regionManager = regionManager;
            SpcrapingData = new ProyectScrapingData();
            // Hecho
            _ea.GetEvent<ProyectoChangeEvent>().Subscribe(CambiarANuevoProyectoConfig);
            
            _ea.GetEvent<GetProyectoEvent>().Subscribe(GetProyectoEventReceived);
        }
        //
        private void GetProyectoEventReceived(string n)
        {
            SetProyectoEventSend();
        }
        private void SetProyectoEventSend()
        {
            _ea.GetEvent<SetProyectoEvent>().Publish(proyectoClass);
        }

        private void ProyectoChangedEventSend()
        {
            try { 
            _ea.GetEvent<ProyectoCangedEvent>().Publish(proyectoClass);
            }catch(Exception e)
            {

            }
        }
        // Hecho
        private void CambiarANuevoProyectoConfig(ProyectoClass proyecto)
        {
            proyectoClass = proyecto;
            // Enviar a todos los oyentes
            ProyectoChangedEventSend();
        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("TabControlRegion", navigatePath);

        }
    }
}
