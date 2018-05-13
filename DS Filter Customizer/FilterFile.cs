using System.Collections.Generic;
using static DS_Filter_Customizer.FilterProfile;

namespace DS_Filter_Customizer
{
    class FilterFile
    {
        private static readonly Dictionary<FilterProfileType, string> filterProfileTypeNames = new Dictionary<FilterProfileType, string>()
        {
            [FilterProfileType.Global] = "Global",
            [FilterProfileType.Multiplier] = "Multiplier",
            [FilterProfileType.Detailed] = "Detailed",
            [FilterProfileType.FullControl] = "Full Control",
        };

        public FilterProfile Profile;
        public string Path;

        public FilterFile(FilterProfile profile, string path)
        {
            Profile = profile;
            Path = path;
        }

        public override string ToString()
        {
            return filterProfileTypeNames[Profile.Type] + ": " + Profile.Name;
        }
    }
}
