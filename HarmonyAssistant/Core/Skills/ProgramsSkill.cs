using HarmonyAssistant.Core.TTC;
using HarmonyAssistant.Data.DataSerialize;
using System.Collections.Generic;
using System.Diagnostics;

namespace HarmonyAssistant.Core.Skills
{
    public class ProgramsSkill
    {
        public OCS OpenProgram(ICS iCS)
        {
            List<bool> results = new List<bool>();

            foreach (var programObj in ProgramsData.JsonObject)
            {
                foreach (var callingNameProgram in programObj.CallingNames)
                {
                    FuzzyString.FuzzyString fuzzyString = new FuzzyString.FuzzyString();
                    var fuzzy = fuzzyString.FuzzySentence(callingNameProgram, iCS.CleanText);
                    if (fuzzy.Length == callingNameProgram.Length)
                    {
                        try
                        {
                            Process.Start(programObj.Path);
                            results.Add(true);
                        }
                        catch
                        {
                            results.Add(false);
                        }
                    }
                }
            }

            OCS oCS = new OCS();
            //foreach (bool result in results)
            //{
            //    if (!result)
            //    {
            //        oCS.Result = false;
            //        return oCS;
            //    };
            //}
            oCS.Result = results.Contains(true);
            return oCS;
        }
    }
}
