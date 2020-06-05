using ModuleScraping.Eventos;
using ModuleScraping.Model.Recursos;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleScraping.ViewModels
{
    class GuardarResultadosViewModel : BindableBase, INavigationAware
    {
        #region Atributos
        private string _title = "Guardar Resultados";
        private ProyectoClass _proyectoClass = new ProyectoClass();
        IEventAggregator _ea;
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

        #endregion

        #region Comandos

        #endregion
        #region Constructores
        public GuardarResultadosViewModel(IEventAggregator ea)
        {
            _ea = ea;

            _ea.GetEvent<SetProyectoEvent>().Subscribe(SetProyectoEventReceived);
            GetProyectoEventSent();
            //CrearProyectoCommand = new DelegateCommand(CrearProyecto);
        }
        #endregion

        #region Métodos



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
