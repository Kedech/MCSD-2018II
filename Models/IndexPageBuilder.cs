using System.Collections.Generic;
using System;
using System.Text;

namespace WebServerProj
{
    public class IndexPageBuilder : ICustomBuilder
    {

        public string Build(object data)
        {
            if (data.GetType() != typeof(List<string>))
            {
                throw new Exception("IndexPageBuilder-Error-1: Tipo de datos en instancia no es List<string>()");
            }

            List<string> listaArchivos = new List<string>();
            listaArchivos = data as List<string>;

            var html = BodyBeginGenerator() +
            BulletListGenerator(listaArchivos) +
            BodyEndGenerator();
            return html;
        }

        public string HyperLinkGenerator(string target, string name)
        {
            return $"<a href={target}>{name}</a>";
        }

        public string BulletListGenerator(List<string> bullets)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<ul>");
            foreach (string element in bullets)
            {
                sb.AppendLine($"<li> {HyperLinkGenerator(element, element)} </li>");
            }
            sb.AppendLine("</ul>");
            return sb.ToString();
        }

        public string BodyBeginGenerator()
        {
            return "<!DOCTYPE Html><html><head><title>Index</title></head><body><h1> Index Of: </h1>";
        }
        public string BodyEndGenerator()
        {
            return "</body></html>";
        }
    }
}