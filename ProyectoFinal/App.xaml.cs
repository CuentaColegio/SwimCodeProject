using Prism.Ioc;
using Prism.Modularity;
using ProyectoFinal.Views;
using System.Windows;

namespace ProyectoFinal
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleScraping.ModuleScrapingModule>();

        }
    }
}
