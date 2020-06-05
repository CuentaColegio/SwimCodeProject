using ModuleScraping.Views;
using ModuleScraping.Model.Recursos;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.IO;
using System.Windows;

namespace ModuleScraping.ViewModels
{
    class CrearProyectoViewModel : BindableBase, INavigationAware
    {
        #region Atributos
        private string _title = "Crear proyecto";
        private string _nombre = "";
        private string _resumen = "";
        private string _info = "";
        private string _path = "";
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
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                SetProperty(ref _nombre, value);
            }
        }
        public string Resumen
        {
            get { return _resumen; }
            set
            {
                SetProperty(ref _resumen, value);
            }
        }
        public string Info
        {
            get { return _info; }
            set
            {
                SetProperty(ref _info, value);
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
        public DelegateCommand CrearProyectoCommand { get; private set; }


        #endregion

        #region Constructores
        public CrearProyectoViewModel()
        {
            CrearProyectoCommand = new DelegateCommand(CrearProyecto);
        }

        #endregion

        #region Métodos
        private void CrearProyecto()
        {
            XmlProyecto xmlProyecto = new XmlProyecto();

            string msgtext = "Desea crear el proyecto " + _nombre + "?";
            string txt = "Crear proyecto";

            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxResult result = MessageBox.Show(msgtext, txt, button);
            
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if(Nombre != null && Nombre != "")
                    {
                        if (Directory.Exists(Path))
                        {
                            string s = Path + @"\" + Nombre + ".xml";
                            xmlProyecto.CrearProyecto(s, Nombre, Resumen, Info);
                            MessageBox.Show("El proyecto a sido creado", "Mensaje");
                        }
                        else
                        {
                            MessageBox.Show("No se encontro el path", "Mensaje");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nombre incorrecto", "Mensaje");
                    }

                    break;
                case MessageBoxResult.No:
        
                    break;
                case MessageBoxResult.Cancel:

                    break;
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
