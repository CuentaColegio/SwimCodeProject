using ModuleScraping.Eventos;
using ModuleScraping.Model.Recursos;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;

namespace ModuleScraping.ViewModels
{
    class SeleccionarRecursosViewModel : BindableBase, INavigationAware
    {
        #region Atributos
        private string _title = "SeleccionarRecursos";
        private ProyectoClass _proyectoClass = new ProyectoClass();
        private List<string> _itemsComboBox = new List<string>();
        private List<string> _itemsASeleccionar = new List<string>();
        private List<string> _itemsSeleccionados = new List<string>();
        IEventAggregator _ea;
        private string _itemASeleccionar;
        private string _itemSeleccionado;
        #endregion

        #region Propiedades
        public ProyectoClass ProyectoClass
        {
            get { return _proyectoClass; }
            set { SetProperty(ref _proyectoClass, value); }
        }
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public string itemASeleccionar
        {
            get { return _itemASeleccionar; }
            set
            {
                SetProperty(ref _itemASeleccionar, value);
                if (value == "Archivos")
                    CargarNombreArchivosIndependientesAComboBox();
                if (value == "Carpetas")
                    CargarNombreCarpetasIndependientesAComboBox();
                if (value == "Estanterias")
                    CargarNombreEstanteriasIndependientesAComboBox();
            }
        }
        public string itemSeleccionado
        {
            get { return _itemSeleccionado; }
            set
            {
                SetProperty(ref _itemSeleccionado, value);

            }
        }
        public List<string> ItemsComboBox
        {
            get { return _itemsComboBox; }
            set { SetProperty(ref _itemsComboBox, value); }
        }
        public List<string> ItemsASeleccionar
        {
            get { return _itemsASeleccionar; }
            set { SetProperty(ref _itemsASeleccionar, value); }
        }
        public List<string> ItemsSeleccionados
        {
            get { return _itemsSeleccionados; }
            set { SetProperty(ref _itemsSeleccionados, value); }
        }
        #endregion

        #region Comandos
        public DelegateCommand<string> SelectedItemChangesSeleccionadosCommand { get; private set; }
        public DelegateCommand<string> SelectedItemChangesASeleccionarCommand { get; private set; }
        #endregion
        #region Constructores
        public SeleccionarRecursosViewModel(IEventAggregator ea)
        {
            _ea = ea;

            ItemsComboBox.Add("Archivos");
            ItemsComboBox.Add("Carpetas");
            ItemsComboBox.Add("Estanterias");

            _ea.GetEvent<SetProyectoEvent>().Subscribe(SetProyectoEventReceived);
            GetProyectoEventSent();
            SelectedItemChangesSeleccionadosCommand = new DelegateCommand<string>(SelectedItemChangesASeleccionar);
            SelectedItemChangesASeleccionarCommand = new DelegateCommand<string>(SelectedItemChangesASeleccionar);
        }
        #endregion

        #region Métodos
        #region Métodos Lista
        private void SelectedItemChangesASeleccionar(string nombre)
        {

            ItemsSeleccionados.Add(nombre);
            ItemsASeleccionar.Remove(nombre);
        }

        #endregion

        #region MétodosListasDeManejoComboBox
        private void CargarNombreArchivosIndependientesAComboBox()
        {
            ItemsASeleccionar = _proyectoClass.GetNombreArchivosIndependientes();
        }
        private void CargarNombreCarpetasIndependientesAComboBox()
        {
            ItemsASeleccionar = _proyectoClass.GetNombresCarpetasIndependientes();
        }
        private void CargarNombreEstanteriasIndependientesAComboBox()
        {
            ItemsASeleccionar = _proyectoClass.GetNombreEstanteriasIndependientes();
        }
        #endregion
        private void GetProyectoEventSent()
        {
            _ea.GetEvent<GetProyectoEvent>().Publish("");
        }
        private void SetProyectoEventReceived(ProyectoClass proyecto)
        {
            ProyectoClass = proyecto;
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
