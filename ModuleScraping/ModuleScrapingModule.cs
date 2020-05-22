using ModuleScraping.Servicios.Dialogos;
using ModuleScraping.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleScraping
{
    public class ModuleScrapingModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            //regionManager.RegisterViewWithRegion("TabControlRegion", typeof(FormularioRaspadoGenerico));
            regionManager.RegisterViewWithRegion("InfoRegion", typeof(ScrapingDataControl));
            regionManager.RegisterViewWithRegion("ScrapingModuleGrid", typeof(ScrapingModuleGrid));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<FormularioRaspadoGenerico>();
            containerRegistry.RegisterForNavigation<CargaDeArchivos>();
            containerRegistry.RegisterForNavigation<ScrapingDataControl>();
            containerRegistry.RegisterForNavigation<DescargarFormulario>(); // Obsoleto
            containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>();
        }
    }
}