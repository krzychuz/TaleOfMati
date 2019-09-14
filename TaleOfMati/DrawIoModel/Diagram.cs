using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TaleOfMati.DrawIoModel
{
    [XmlRoot(ElementName = "diagram")]
    public class Diagram
    {
        [XmlElement(ElementName = "mxGraphModel")]
        public MxGraphModel MxGraphModel { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }
}
