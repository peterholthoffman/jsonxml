using System;
using System.Xml;
using Newtonsoft.Json;

namespace xmljson
{
    class Program
    {
        static void Main(string[] args)
        {
            string src = System.IO.File.ReadAllText(@"C:\Temp\input-cda.xml");

            string json = xml2json(src);    // go from XML to JSON
            string xml  = json2xml(json);   // go from JSON to XML (roundtrip to compare with the original)
        }



        static string xml2json(string xml)
        {

            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xml);

            string json = JsonConvert.SerializeXmlNode(doc);

            using (System.IO.StreamWriter stringWriter = new System.IO.StreamWriter(@"C:\Temp\output-cda.json"))
            {
                stringWriter.Write(json);
                stringWriter.Flush();
            }
            return json;
        }



        static string json2xml(string json)
        {
            XmlDocument xml = new XmlDocument();
            xml = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(json);
            string output = xml.InnerXml;
            using (System.IO.StreamWriter stringWriter = new System.IO.StreamWriter(@"C:\Temp\output-cda.xml")) {
                stringWriter.Write(output);
                stringWriter.Flush();
            }
            return output;
        }
    }
}