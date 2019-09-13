using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TaleOfMati.XML
{
    [XmlRoot(ElementName = "mxGeometry")]
    public class MxGeometry
    {
        [XmlAttribute(AttributeName = "relative")]
        public string Relative { get; set; }
        [XmlAttribute(AttributeName = "as")]
        public string As { get; set; }
        [XmlElement(ElementName = "Array")]
        public Array Array { get; set; }
        [XmlAttribute(AttributeName = "x")]
        public string X { get; set; }
        [XmlAttribute(AttributeName = "y")]
        public string Y { get; set; }
        [XmlAttribute(AttributeName = "width")]
        public string Width { get; set; }
        [XmlAttribute(AttributeName = "height")]
        public string Height { get; set; }
        [XmlElement(ElementName = "mxPoint")]
        public List<MxPoint> MxPoint { get; set; }
    }
}
