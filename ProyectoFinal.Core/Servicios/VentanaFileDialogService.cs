using Microsoft.WindowsAPICodePack.Dialogs;


namespace ProyectoFinal.Core.Servicios
{
    public static class VentanaFileDialogService
    {
        public static string VentanaFileDialogLaunch()
        {
            // https://stackoverflow.com/questions/1922204/open-directory-dialog
            // para saber si esta soportado.
            // CommonFileDialog.IsPlatformSupported

            string path = string.Empty;

            if (CommonFileDialog.IsPlatformSupported)
            {
                using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
                {
                    dialog.IsFolderPicker = true;
                    dialog.Multiselect = false;
                    // dialog.DefaultDirectory;
                    if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        path = dialog.FileName;
                    }
                }
            }
            else
            {
                // Si es anterior a windows XP
                using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
                {
                    System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                    path = dialog.SelectedPath;
                }
            }
            return path;
        }
    }
}
