using HarmonyAssistant.Data.DataSerialize.Base;
using HarmonyAssistant.Data.DataSerialize.SerializeObjects;
using System.Collections.Generic;

namespace HarmonyAssistant.Data.DataSerialize
{
    public class SitesData : DataSerialize<List<SiteObject>>
    {
        public SitesData(string language) : base(language, "Sites.json") { }
    }
}
