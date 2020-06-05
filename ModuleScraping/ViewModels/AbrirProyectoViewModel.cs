using ModuleScraping.Eventos;
using ModuleScraping.Model.Recursos;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using ProyectoFinal.Core.Servicios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ModuleScraping.ViewModels
{
    class AbrirProyectoViewModel : BindableBase, INavigationAware
    {
        #region Atributos
        private string _title = "Crear proyecto";
        private string _path = "";
        private ProyectoClass proyectoClass = new ProyectoClass();
        private XmlProyecto xmlProyecto = new XmlProyecto();
        private readonly IRegionManager _regionManager;
        IEventAggregator _ea;
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
        public string Path
        {
            get { return _path; }
            set
            {
                SetProperty(ref _path, value);
            }
        }
        #endregion

        #region Comandos
        public DelegateCommand AbrirProyectoCommand { get; private set; }
        public DelegateCommand CargarPathArchivoServiceCommand { get; private set; }
        #endregion

        #region Constructores
        public AbrirProyectoViewModel(IRegionManager regionManager, IEventAggregator ea)
        {
            _regionManager = regionManager;
            AbrirProyectoCommand = new DelegateCommand(AbrirProyecto);
            CargarPathArchivoServiceCommand = new DelegateCommand(FileDialogServiceArchivo);

            _ea = ea;

        }
        #endregion

        #region Métodos
        private void SendProyectoChangeEvent()
        {
            _ea.GetEvent<ProyectoChangeEvent>().Publish(proyectoClass);
        }

        private void AbrirProyecto()
        {
            try {
                proyectoClass = xmlProyecto.CargarProyectoXML(Path);
                MessageBox.Show("Los datos del proyecto de han cargado con exito", "Proyecto Abierto");

                SendProyectoChangeEvent();

                _regionManager.Regions["InfoRegion"].RemoveAll();
                _regionManager.Regions["TabControlRegion"].RemoveAll();
            }
            catch (Exception e)
            {
                MessageBox.Show("El archivo de configuración esta dañado o mal configurado", "Error al cargar");
            }
            
        }
        private void FileDialogServiceArchivo()
        {
            string resultado = VentanaFileDialogService.VentanaFileDialogArchivoLaunch();
            if (resultado != null)
            {
                Path = resultado;
            }
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
