using ModuleScraping.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace ProyectoFinal.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private string _title = "SwimCode";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand<string> NavigateTabControlRegionCommand { get; private set; }
        public DelegateCommand<string> NavigateInfoRegionCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateTabControlRegionCommand = new DelegateCommand<string>(NavigateTabControlRegion);
            NavigateInfoRegionCommand = new DelegateCommand<string>(NavigateInfoRegion);
        }
        private void NavigateTabControlRegion(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("TabControlRegion", navigatePath);
                
        }
        private void NavigateInfoRegion(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("InfoRegion", navigatePath);

        }
    }
}
