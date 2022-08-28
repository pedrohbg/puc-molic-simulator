using Puc.Molic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Puc.Molic
{
    public class TransformationHelper
    {
        public string ToXML(Diagram diagram)
        {
            using (var stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(typeof(Diagram));
                serializer.Serialize(stringwriter, diagram);
                return stringwriter.ToString();
            }
        }

        public static Diagram LoadFromXMLString(string xmlText)
        {
            using (var stringReader = new System.IO.StringReader(xmlText))
            {
                var serializer = new XmlSerializer(typeof(Diagram));
                return serializer.Deserialize(stringReader) as Diagram;
            }
        }
    }
}
