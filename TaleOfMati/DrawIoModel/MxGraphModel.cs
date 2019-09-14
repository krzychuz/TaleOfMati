using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TaleOfMati.DrawIoModel
{
    [XmlRoot(ElementName = "mxGraphModel")]
    public class MxGraphModel
    {
        [XmlElement(ElementName = "root")]
        public Root Root { get; set; }
        [XmlAttribute(AttributeName = "dx")]
        public string Dx { get; set; }
        [XmlAttribute(AttributeName = "dy")]
        public string Dy { get; set; }
        [XmlAttribute(AttributeName = "grid")]
        public string Grid { get; set; }
        [XmlAttribute(AttributeName = "gridSize")]
        public string GridSize { get; set; }
        [XmlAttribute(AttributeName = "guides")]
        public string Guides { get; set; }
        [XmlAttribute(AttributeName = "tooltips")]
        public string Tooltips { get; set; }
        [XmlAttribute(AttributeName = "connect")]
        public string Connect { get; set; }
        [XmlAttribute(AttributeName = "arrows")]
        public string Arrows { get; set; }
        [XmlAttribute(AttributeName = "fold")]
        public string Fold { get; set; }
        [XmlAttribute(AttributeName = "page")]
        public string Page { get; set; }
        [XmlAttribute(AttributeName = "pageScale")]
        public string PageScale { get; set; }
        [XmlAttribute(AttributeName = "pageWidth")]
        public string PageWidth { get; set; }
        [XmlAttribute(AttributeName = "pageHeight")]
        public string PageHeight { get; set; }
        [XmlAttribute(AttributeName = "background")]
        public string Background { get; set; }
        [XmlAttribute(AttributeName = "math")]
        public string Math { get; set; }
        [XmlAttribute(AttributeName = "shadow")]
        public string Shadow { get; set; }
    }
}
