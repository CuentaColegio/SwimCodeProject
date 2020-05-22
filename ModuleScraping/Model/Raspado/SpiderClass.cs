using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleScraping.Model.Raspado
{
    public class SpiderClass
    {
        HtmlWeb Web;

        public SpiderClass()
        {
            this.Web = new HtmlWeb();
        }

        // Pasas lista de urls y devuelve doc/s html
        public List<HtmlDocument> DescargarPaginas(List<string> urls)
        {

            List<HtmlDocument> htmls = new List<HtmlDocument>();
            HtmlDocument doc = new HtmlDocument();

            foreach (string url in urls)
            {
                htmls.Add(DescargarPagina(url));
            }
            return htmls;
        }

        // Descarga doc html
        public HtmlDocument DescargarPagina(string url)
        {
            HtmlDocument doc = new HtmlDocument();
            HtmlWeb Web = new HtmlWeb();
            doc = Web.Load(url);

            return doc;
        }
    }
}
