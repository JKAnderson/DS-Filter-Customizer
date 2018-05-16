using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace DS_Filter_Customizer
{
    public class FilterProfile
    {
        private const string PROFILE_DIR = "profiles";
        private const string XML_VERSION = "0";

        public enum FilterProfileType
        {
            Global,
            Multiplier,
            Detailed,
            FullControl,
        }

        private static readonly Dictionary<FilterProfileType, string> filterProfileTypeNames = new Dictionary<FilterProfileType, string>()
        {
            [FilterProfileType.Global] = "Global",
            [FilterProfileType.Multiplier] = "Multiplier",
            [FilterProfileType.Detailed] = "Detailed",
            [FilterProfileType.FullControl] = "Full Control",
        };

        private static readonly Regex filterNameRx = new Regex(@"^(?<world>[^,]+),(?<id>\S+)\s+(?<name>.+)$");
        private static readonly Regex filterLookupRx = new Regex(@"^(?<world1>[^,]+),(?<id1>\S+)\s+(?<world2>[^,]+),(?<id2>.+)$");

        private static readonly Dictionary<(int, int), string> filterDetailedNames, filterFullControlNames;
        private static readonly Dictionary<(int, int), (int, int)> filterDetailedLookup;

        private static readonly FilterProfile defaultFilterProfileGlobal, defaultFilterProfileMultiplier,
            defaultFilterProfileDetailed, defaultFilterProfileFullControl;

        static FilterProfile()
        {
            filterDetailedNames = new Dictionary<(int, int), string>();
            foreach (string line in Regex.Split(Properties.Resources.FilterDetailedNames, "[\r\n]+"))
            {
                Match match = filterNameRx.Match(line);
                int world = Int32.Parse(match.Groups["world"].Value);
                int id = Int32.Parse(match.Groups["id"].Value);
                string name = match.Groups["name"].Value;
                filterDetailedNames[(world, id)] = name;
            }

            filterFullControlNames = new Dictionary<(int, int), string>();
            foreach (string line in Regex.Split(Properties.Resources.FilterFullControlNames, "[\r\n]+"))
            {
                Match match = filterNameRx.Match(line);
                int world = Int32.Parse(match.Groups["world"].Value);
                int id = Int32.Parse(match.Groups["id"].Value);
                string name = match.Groups["name"].Value;
                filterFullControlNames[(world, id)] = name;
            }

            filterDetailedLookup = new Dictionary<(int, int), (int, int)>();
            foreach (string line in Regex.Split(Properties.Resources.FilterDetailedLookup, "[\r\n]+"))
            {
                Match match = filterLookupRx.Match(line);
                int world1 = Int32.Parse(match.Groups["world1"].Value);
                int id1 = Int32.Parse(match.Groups["id1"].Value);
                int world2 = Int32.Parse(match.Groups["world2"].Value);
                int id2 = Int32.Parse(match.Groups["id2"].Value);
                filterDetailedLookup[(world1, id1)] = (world2, id2);
            }

            defaultFilterProfileGlobal = new FilterProfile(Properties.Resources.DefaultFilterProfileGlobal, null);
            defaultFilterProfileMultiplier = new FilterProfile(Properties.Resources.DefaultFilterProfileMultiplier, null);
            defaultFilterProfileDetailed = new FilterProfile(Properties.Resources.DefaultFilterProfileDetailed, null);
            defaultFilterProfileFullControl = new FilterProfile(Properties.Resources.DefaultFilterProfileFullControl, null);
        }

        public static FilterProfile CreateFilterProfile(FilterProfileType filterProfileType, string name)
        {
            FilterProfile result = null;
            switch (filterProfileType)
            {
                case FilterProfileType.Global:
                    result = defaultFilterProfileGlobal.Clone(name);
                    break;
                case FilterProfileType.Multiplier:
                    result = defaultFilterProfileMultiplier.Clone(name);
                    break;
                case FilterProfileType.Detailed:
                    result = defaultFilterProfileDetailed.Clone(name);
                    break;
                case FilterProfileType.FullControl:
                    result = defaultFilterProfileFullControl.Clone(name);
                    break;
            }
            return result;
        }

        public static FilterProfile LoadFilterProfile(string path)
        {
            FilterProfile result = null;
            if (File.Exists(path))
                result = new FilterProfile(File.ReadAllText(path), path);
            return result;
        }


        public string Name, Path;
        public readonly FilterProfileType Type;
        public readonly List<Filter> Filters;

        private FilterProfile(string xml, string path)
        {
            Path = path;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            XmlNode nodeVersion = xmlDoc.SelectSingleNode("root/version");
            int version = Int32.Parse(nodeVersion.InnerText);

            XmlNode nodeName = xmlDoc.SelectSingleNode("root/name");
            Name = nodeName.InnerText;

            XmlNode nodeFilterType = xmlDoc.SelectSingleNode("root/type");
            Type = (FilterProfileType)Int32.Parse(nodeFilterType.InnerText);

            Filters = new List<Filter>();
            foreach (XmlNode nodeFilter in xmlDoc.SelectNodes("root/filters/filter"))
            {
                Filter filter = new Filter(nodeFilter, version);
                Filters.Add(filter);

                switch (Type)
                {
                    case FilterProfileType.Global:
                        filter.Name = "Global";
                        break;
                    case FilterProfileType.Multiplier:
                        filter.Name = "Multiplier";
                        break;
                    case FilterProfileType.Detailed:
                        filter.Name = filterDetailedNames[(filter.World, filter.ID)];
                        break;
                    case FilterProfileType.FullControl:
                        filter.Name = String.Format("{0}:{1} {2}",
                            filter.World, filter.ID, filterFullControlNames[(filter.World, filter.ID)]);
                        break;
                }
            }

            switch (Type)
            {
                case FilterProfileType.Global:
                case FilterProfileType.Multiplier:
                    break;
                case FilterProfileType.Detailed:
                    Filters.Sort((a, b) => a.Name.CompareTo(b.Name));
                    break;
                case FilterProfileType.FullControl:
                    Filters.Sort((a, b) =>
                    {
                        if (a.World.CompareTo(b.World) == 0)
                            return a.ID.CompareTo(b.ID);
                        else
                            return a.World.CompareTo(b.World);
                    });
                    break;
            }
        }

        private FilterProfile(FilterProfile clone, string name)
        {
            Name = name;
            Path = MakePath(PROFILE_DIR);
            Type = clone.Type;
            Filters = new List<Filter>();
            foreach (Filter filter in clone.Filters)
                Filters.Add(filter.Clone());
        }

        public FilterProfile Clone(string name)
        {
            return new FilterProfile(this, name);
        }

        public string MakePath(string directory)
        {
            string path = Regex.Replace(Name.ToLower(), @"\s", "_");
            path = Regex.Replace(path, @"[^\w\d]", "");
            if (File.Exists(directory + @"\" + path + ".xml"))
            {
                int x = 1;
                while (File.Exists(directory + @"\" + path + "_" + x + ".xml"))
                    x++;
                path += "_" + x;
            }
            return directory + @"\" + path + ".xml";
        }

        public void Save()
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            XmlWriter xmlWriter = XmlWriter.Create(Path, xmlWriterSettings);
            xmlWriter.WriteStartElement("root");
            xmlWriter.WriteElementString("version", XML_VERSION);
            xmlWriter.WriteElementString("name", Name);
            xmlWriter.WriteElementString("type", ((int)Type).ToString());
            xmlWriter.WriteStartElement("filters");
            foreach (Filter filter in Filters)
                filter.Save(xmlWriter);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.Close();
        }

        public Filter GetActiveFilter(int world, int filterID)
        {
            Filter result = null;
            switch (Type)
            {
                case FilterProfileType.Global:
                case FilterProfileType.Multiplier:
                    result = Filters[0];
                    break;

                case FilterProfileType.Detailed:
                    if (filterDetailedLookup.ContainsKey((world, filterID)))
                        (world, filterID) = filterDetailedLookup[(world, filterID)];
                    for (int i = 0; i < Filters.Count; i++)
                    {
                        Filter filter = Filters[i];
                        if (filter.World == world && filter.ID == filterID)
                        {
                            result = filter;
                            break;
                        }
                    }
                    break;

                case FilterProfileType.FullControl:
                    for (int i = 0; i < Filters.Count; i++)
                    {
                        Filter filter = Filters[i];
                        if (filter.World == world && filter.ID == filterID)
                        {
                            result = filter;
                            break;
                        }
                    }
                    break;
            }
            return result;
        }

        public Filter GetAppliedFilter(int world, int filterID)
        {
            Filter result = null;
            switch (Type)
            {
                case FilterProfileType.Global:
                case FilterProfileType.Detailed:
                case FilterProfileType.FullControl:
                    result = GetActiveFilter(world, filterID);
                    break;

                case FilterProfileType.Multiplier:
                    Filter baseFilter = defaultFilterProfileFullControl.GetAppliedFilter(world, filterID);
                    if (baseFilter != null)
                    {
                        result = GetActiveFilter(world, filterID).Clone();
                        result.BrightnessR *= baseFilter.BrightnessR;
                        result.BrightnessG *= baseFilter.BrightnessG;
                        result.BrightnessB *= baseFilter.BrightnessB;
                        result.ContrastR *= baseFilter.ContrastR;
                        result.ContrastG *= baseFilter.ContrastG;
                        result.ContrastB *= baseFilter.ContrastB;
                        result.Saturation *= baseFilter.Saturation;
                        result.Hue = baseFilter.Hue;
                    }
                    break;
            }
            return result;
        }

        public override string ToString()
        {
            return filterProfileTypeNames[Type] + ": " + Name;
        }
    }
}
