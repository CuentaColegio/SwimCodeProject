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
            regionManager.RegisterViewWithRegion("TabControlRegion", typeof(AbrirProyecto));
            regionManager.RegisterViewWithRegion("ScrapingModuleGrid", typeof(ScrapingModuleGrid));
            regionManager.Regions["InfoRegion"].RemoveAll();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<FormularioRaspadoGenerico>();
            containerRegistry.RegisterForNavigation<CargaDeArchivos>();
            containerRegistry.RegisterForNavigation<ScrapingDataControl>();
            containerRegistry.RegisterForNavigation<CrearProyecto>();
            containerRegistry.RegisterForNavigation<AbrirProyecto>();
            containerRegistry.RegisterForNavigation<SeleccionarRecursos>();
            containerRegistry.RegisterForNavigation<DescargarFormulario>(); // Obsoleto
            containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>();
        }
    }
}