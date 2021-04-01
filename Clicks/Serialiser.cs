using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace JimsMacros
{
    public class Serialiser
    {
        public static string Serialise(AutoSettings autoSetting)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(AutoSettings));
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, autoSetting);
                    xml = sww.ToString(); // Your XML
                }
            }
            return xml;
        }
        
        public static AutoSettings Deserialize(string xml)
        {
            var serializer = new XmlSerializer(typeof(AutoSettings));
            AutoSettings result;

            using (TextReader reader = new StringReader(xml))
            {
                result = (AutoSettings)serializer.Deserialize(reader);
            }

            return result;
        }
        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
