using System;
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Contexts;
using System.Xml;
using System.Xml.Schema;
using Newtonsoft.Json;

/**
 * This template file is created for ASU CSE445 Distributed SW Dev Assignment 4.
 * Please do not modify or delete any existing class/variable/method names. However, you can add more variables and functions.
 * Uploading this file directly will not pass the autograder's compilation check, resulting in a grade of 0.
 * **/

namespace ConsoleApp1
{
    public class Program
    {
        public static string xmlURL = "https://uwuchavez.github.io/cse445_a4/Hotels.xml";
        public static string xmlErrorURL = "https://uwuchavez.github.io/cse445_a4/HotelsErrors.xml";
        public static string xsdURL = "https://uwuchavez.github.io/cse445_a4/Hotels.xsd";

        public static void Main(string[] args)
        {
            string result = Verification(xmlURL, xsdURL);
            Console.WriteLine(result);


            result = Verification(xmlErrorURL, xsdURL);
            Console.WriteLine(result);


            result = Xml2Json(xmlURL);
            Console.WriteLine(result);
        }

        // Q2.1
        public static string Verification(string xmlUrl, string xsdUrl)
        {
            //return "No Error" if XML is valid. Otherwise, return the desired exception message.
            try
            {
                string errors = "";
                XmlSchemaSet sc = new XmlSchemaSet();
                //Add the schema to the schema colletion before validation
                sc.Add(null, xsdUrl);

                //Define the settings for the XmlReader
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas = sc; //Associate the schema with the settings
                string errorMessages = "";
                settings.ValidationEventHandler += new ValidationEventHandler((sender, e) =>
                {
                    errorMessages += $"Line {e.Exception.LineNumber}: {e.Message}\n";
                });

                //Create the XmlReader object
                XmlReader reader = XmlReader.Create(xmlUrl, settings);
                //Parse the file.
                while (reader.Read()) ;
                reader.Close();

                if (string.IsNullOrEmpty(errorMessages))
                    return "No errors are found";
                else
                    return errorMessages;
            }
            catch (Exception ex)
            {
                return "Error validating XML" + ex.Message;
            }
        }

        public static string Xml2Json(string xmlUrl)
        {
            // The returned jsonText needs to be de-serializable by Newtonsoft.Json package. (JsonConvert.DeserializeXmlNode(jsonText))
            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlUrl);
                string jsonText = JsonConvert.SerializeXmlNode(xmlDoc, Newtonsoft.Json.Formatting.Indented);
                JsonConvert.DeserializeXmlNode(jsonText);
                return jsonText;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

}