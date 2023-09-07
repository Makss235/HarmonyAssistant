using HarmonyAssistant.Data.DataSerialize.Base;
using HarmonyAssistant.Data.DataSerialize.SerializeObjects;
using System.Collections.Generic;

namespace HarmonyAssistant.Data.DataSerialize
{
    public class SitesData : BaseDataSerialize<List<SiteObject>>
    {
        #region Singleton

        private static SitesData instance;

        public static SitesData GetInstance()
        {
            if (instance == null)
                instance = new SitesData();
            return instance;
        }

        #endregion

        private SitesData() : base() { }

        public override void Initialize(
            string language = "RU",
            string fileName = "Sites.json")
        {
            base.Initialize(language, fileName);
            Deserialize();
        }
    }
}
