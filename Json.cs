using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public static class Xml2Json
    { 
        public static string Xml2Json(string xmlUrl)
        {
            // Convert the XML file located at xmlUrl to a JSON string and return it.
            try
            {
                XDocument xmlDoc = XDocument.Load(xmlUrl);
                string jsonText = JsonConvert.SerializeXmlNode(xmlDoc, Formatting.Indented);
                return jsonText;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
