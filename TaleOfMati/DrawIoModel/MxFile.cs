using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TaleOfMati.DrawIoModel
{
    [XmlRoot(ElementName = "mxfile")]
    public class MxFile
    {
        [XmlElement(ElementName = "diagram")]
        public Diagram Diagram { get; set; }
        [XmlAttribute(AttributeName = "modified")]
        public string Modified { get; set; }
        [XmlAttribute(AttributeName = "host")]
        public string Host { get; set; }
        [XmlAttribute(AttributeName = "agent")]
        public string Agent { get; set; }
        [XmlAttribute(AttributeName = "etag")]
        public string Etag { get; set; }
        [XmlAttribute(AttributeName = "pages")]
        public string Pages { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "compressed")]
        public string Compressed { get; set; }
    }
}
