using System;
using System.Globalization;
using System.Xml;

namespace DS_Filter_Customizer
{
    public class Filter
    {
        public string Name;
        public int World, ID;
        public bool BrightnessSync, ContrastSync;
        public float BrightnessR, BrightnessG, BrightnessB;
        public float ContrastR, ContrastG, ContrastB;
        public float Saturation, Hue;

        public Filter(XmlNode nodeFilter, int version)
        {
            World = Int32.Parse(nodeFilter.Attributes["world"].Value);
            ID = Int32.Parse(nodeFilter.Attributes["id"].Value);

            XmlNode xmlNode = nodeFilter.SelectSingleNode("brightness");
            BrightnessSync = Boolean.Parse(xmlNode.Attributes["sync"].Value);
            string[] rgb = xmlNode.InnerText.Split(',');
            BrightnessR = Single.Parse(rgb[0], CultureInfo.InvariantCulture);
            BrightnessG = Single.Parse(rgb[1], CultureInfo.InvariantCulture);
            BrightnessB = Single.Parse(rgb[2], CultureInfo.InvariantCulture);

            xmlNode = nodeFilter.SelectSingleNode("contrast");
            ContrastSync = Boolean.Parse(xmlNode.Attributes["sync"].Value);
            rgb = xmlNode.InnerText.Split(',');
            ContrastR = Single.Parse(rgb[0], CultureInfo.InvariantCulture);
            ContrastG = Single.Parse(rgb[1], CultureInfo.InvariantCulture);
            ContrastB = Single.Parse(rgb[2], CultureInfo.InvariantCulture);

            Saturation = Single.Parse(nodeFilter.SelectSingleNode("saturation").InnerText, CultureInfo.InvariantCulture);
            Hue = Single.Parse(nodeFilter.SelectSingleNode("hue").InnerText, CultureInfo.InvariantCulture);
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
            xmlWriter.WriteValue(String.Format(CultureInfo.InvariantCulture, "{0},{1},{2}", BrightnessR, BrightnessG, BrightnessB));
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("contrast");
            xmlWriter.WriteAttributeString("sync", ContrastSync.ToString());
            xmlWriter.WriteValue(String.Format(CultureInfo.InvariantCulture, "{0},{1},{2}", ContrastR, ContrastG, ContrastB));
            xmlWriter.WriteEndElement();
            xmlWriter.WriteElementString("saturation", Saturation.ToString(CultureInfo.InvariantCulture));
            xmlWriter.WriteElementString("hue", Hue.ToString(CultureInfo.InvariantCulture));
            xmlWriter.WriteEndElement();
        }

        public override string ToString()
        {
            return Name;
        }

        public static Filter Lerp(Filter startFilter, Filter endFilter, float progress)
        {
            Filter result = startFilter.Clone();
            result.BrightnessR += (endFilter.BrightnessR - startFilter.BrightnessR) * progress;
            result.BrightnessG += (endFilter.BrightnessG - startFilter.BrightnessG) * progress;
            result.BrightnessB += (endFilter.BrightnessB - startFilter.BrightnessB) * progress;
            result.ContrastR += (endFilter.ContrastR - startFilter.ContrastR) * progress;
            result.ContrastG += (endFilter.ContrastG - startFilter.ContrastG) * progress;
            result.ContrastB += (endFilter.ContrastB - startFilter.ContrastB) * progress;
            result.Saturation += (endFilter.Saturation - startFilter.Saturation) * progress;
            result.Hue += (endFilter.Hue - startFilter.Hue) * progress;
            return result;
        }
    }
}
