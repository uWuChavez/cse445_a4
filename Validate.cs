using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Schema;

namespace ConsoleApp1
{
    public static class Validate
    {
        public static string Verification(string xmlUrl, string xsdUrl)
        {
            StringBuilder errors = new StringBuilder();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, xsdUrl);
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += (sender, e) =>
            {
                errors.AppendLine($"Line {e.Exception.LineNumber}: {e.Message}");
            };

            using (XmlReader reader = XmlReader.Create(xmlUrl, settings))
            {
                try
                {
                    while (reader.Read()) { }
                }
                catch (Exception ex)
                {
                    errors.AppendLine(ex.Message);
                }
            }
            return errors.Length == 0 ? "No Error" : errors.ToString();
        }
    }
}
