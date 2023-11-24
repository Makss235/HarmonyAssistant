using HarmonyAssistant.Data.DataSerialize.Base;
using System.Collections.Generic;

namespace HarmonyAssistant.Data.DataSerialize
{
    public class ProgramsData : BaseDataSerialize<List<NamesAndPathObject>>
    {
        #region Singleton

        private static ProgramsData instance;

        public static ProgramsData GetInstance()
        {
            if (instance == null)
                instance = new ProgramsData();
            return instance;
        }

        #endregion

        private ProgramsData() : base() { }

        public override void Initialize(
            string language = "RU",
            string fileName = "Programs.json")
        {
            base.Initialize(fileName, language);
            Deserialize();
        }
    }
}
