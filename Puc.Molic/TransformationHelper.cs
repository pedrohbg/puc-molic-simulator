using Puc.Molic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Puc.Molic
{
    //Serializers and deserializers for XML to Object
    //Author: Pedro Henrique Bof Gerico
    public class TransformationHelper
    {
        //convert object Diagram into XML
        public string ToXML(Diagram diagram)
        {
            using (var stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(typeof(Diagram));
                serializer.Serialize(stringwriter, diagram);
                return stringwriter.ToString();
            }
        }

        //convert XML diagram into Object Diagram
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
