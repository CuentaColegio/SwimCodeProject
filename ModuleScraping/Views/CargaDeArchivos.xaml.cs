using ModuleScraping.Model;
using ModuleScraping.ViewModels;
using Prism.Common;
using Prism.Regions;
using System.Windows.Controls;

namespace ModuleScraping.Views
{
    /// <summary>
    /// Lógica de interacción para CargaDeArchivos.xaml
    /// </summary>
    public partial class CargaDeArchivos : UserControl
    {
        public CargaDeArchivos()
        {
            InitializeComponent();
            RegionContext.GetObservableContext(this).PropertyChanged += ProyectScrapingData_PropertyChanged;
        }

        private void ProyectScrapingData_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var context = (ObservableObject<object>)sender;
            var ProyectoScrapingData = (ProyectScrapingData)context.Value;
            (DataContext as CargaDeArchivosViewModel).SpcrapingData = ProyectoScrapingData;
        }
    }
}
