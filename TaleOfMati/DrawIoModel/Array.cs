using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TaleOfMati.DrawIoModel
{
    [XmlRoot(ElementName = "Array")]
    public class Array
    {
        [XmlElement(ElementName = "mxPoint")]
        public List<MxPoint> MxPoint { get; set; }
        [XmlAttribute(AttributeName = "as")]
        public string As { get; set; }
    }
}
