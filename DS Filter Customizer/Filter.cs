using System;
using System.Xml;

namespace DS_Filter_Customizer
{
    public class Filter
    {
        public string Name;
        public readonly int World, ID;
        public bool BrightnessSync, ContrastSync;
        public float BrightnessR, BrightnessG, BrightnessB;
        public float ContrastR, ContrastG, ContrastB;
        public float Saturation, Hue;

        public Filter(XmlNode nodeFilter)
        {
            World = Int32.Parse(nodeFilter.Attributes["world"].Value);
            ID = Int32.Parse(nodeFilter.Attributes["id"].Value);

            XmlNode xmlNode = nodeFilter.SelectSingleNode("brightness");
            BrightnessSync = Boolean.Parse(xmlNode.Attributes["sync"].Value);
            string[] rgb = xmlNode.InnerText.Split(',');
            BrightnessR = Single.Parse(rgb[0]);
            BrightnessG = Single.Parse(rgb[1]);
            BrightnessB = Single.Parse(rgb[2]);

            xmlNode = nodeFilter.SelectSingleNode("contrast");
            ContrastSync = Boolean.Parse(xmlNode.Attributes["sync"].Value);
            rgb = xmlNode.InnerText.Split(',');
            ContrastR = Single.Parse(rgb[0]);
            ContrastG = Single.Parse(rgb[1]);
            ContrastB = Single.Parse(rgb[2]);

            Saturation = Single.Parse(nodeFilter.SelectSingleNode("saturation").InnerText);
            Hue = Single.Parse(nodeFilter.SelectSingleNode("hue").InnerText);
        }

        private Filter(Filter clone)
        {
            Name = clone.Name;
            World = clone.World;
            ID = clone.ID;
            BrightnessSync = clone.BrightnessSync;
            BrightnessR = clone.BrightnessR;
            BrightnessG = clone.BrightnessG;
            BrightnessB = clone.BrightnessB;
            ContrastSync = clone.ContrastSync;
            ContrastR = clone.ContrastR;
            ContrastG = clone.ContrastG;
            ContrastB = clone.ContrastB;
            Saturation = clone.Saturation;
            Hue = clone.Hue;
        }

        public Filter Clone()
        {
            return new Filter(this);
        }

        public void Save(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("filter");
            xmlWriter.WriteAttributeString("world", World.ToString());
            xmlWriter.WriteAttributeString("id", ID.ToString());
            xmlWriter.WriteStartElement("brightness");
            xmlWriter.WriteAttributeString("sync", BrightnessSync.ToString());
            xmlWriter.WriteValue(String.Format("{0},{1},{2}", BrightnessR, BrightnessG, BrightnessB));
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("contrast");
            xmlWriter.WriteAttributeString("sync", ContrastSync.ToString());
            xmlWriter.WriteValue(String.Format("{0},{1},{2}", ContrastR, ContrastG, ContrastB));
            xmlWriter.WriteEndElement();
            xmlWriter.WriteElementString("saturation", Saturation.ToString());
            xmlWriter.WriteElementString("hue", Hue.ToString());
            xmlWriter.WriteEndElement();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
