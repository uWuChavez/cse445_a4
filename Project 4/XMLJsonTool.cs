using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public static class XmlJsonTool
    {
        public static string Xml2Json(string xmlUrl)
        {
            // Convert the XML file located at xmlUrl to a JSON string and return it.
            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlUrl);

                string jsonText = JsonConvert.SerializeXmlNode(xmlDoc, Newtonsoft.Json.Formatting.Indented);
                JsonConvert.DeserializeXmlNode(jsonText); // Ensure it is deserializable
                return jsonText;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
