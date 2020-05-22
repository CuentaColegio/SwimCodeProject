using HtmlAgilityPack;
using System;

namespace ModuleScraping.Model.Raspado
{
    class Scrapy
    {
        private HtmlDocument _doc;
        private string _resultado;
        #region Constructores
        public Scrapy(HtmlDocument doc)
        {
            this._doc = doc;
        }
        #endregion


        #region Metodos.
        private Boolean PuedoSeleccionarNodosXPath(string ExpresionXPath)
        {

            HtmlNodeCollection htmlNodes = _doc.DocumentNode.SelectNodes(ExpresionXPath);
            if (htmlNodes != null)
            {
                return true;
            }
            else { return false; }
        }

        public string SeleccionarNodosXPath(string ExpresionXPath)
        {
            if (PuedoSeleccionarNodosXPath(ExpresionXPath)) {
            HtmlNodeCollection htmlNodes = _doc.DocumentNode.SelectNodes(ExpresionXPath);
            _resultado = htmlNodes.ToString();
            }
            else
            {
                _resultado = "Nodo no encontrado";
            }

            return _resultado;
        }
        #endregion
    }
}
