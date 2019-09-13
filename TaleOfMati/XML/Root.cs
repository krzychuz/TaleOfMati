using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TaleOfMati.XML
{
    [XmlRoot(ElementName = "root")]
    public class Root
    {
        [XmlElement(ElementName = "mxCell")]
        public List<MxCell> MxCell { get; set; }
    }
}
