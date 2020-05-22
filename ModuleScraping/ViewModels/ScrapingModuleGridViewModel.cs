using ModuleScraping.Model;
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

        public ScrapingModuleGridViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            SpcrapingData = new ProyectScrapingData();
        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("TabControlRegion", navigatePath);

        }
    }
}
