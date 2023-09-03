using HarmonyAssistant.Data.DataSerialize.Base;
using HarmonyAssistant.Data.DataSerialize.SerializeObjects;
using System.Collections.Generic;

namespace HarmonyAssistant.Data.DataSerialize
{
    public class ProgramsData : DataSerialize<List<ProgramObject>>
    {
        public ProgramsData(string language) : base(language, "Programs.json") { }
    }
}
