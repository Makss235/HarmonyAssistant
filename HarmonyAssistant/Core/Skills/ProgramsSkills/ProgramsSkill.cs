using HarmonyAssistant.Core.Skills.Base;
using HarmonyAssistant.Core.TTC;
using HarmonyAssistant.Data.DataSerialize;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HarmonyAssistant.Core.Skills.ProgramsSkills
{
    public class ProgramsSkill : Skill
    {
        public OCS OpenProgram(ICS iCS)
        {
            List<bool> results = new List<bool>();

            foreach (var programObj in ProgramsData.GetInstance().JsonObject)
            {
                foreach (var callingNameProgram in programObj.Names)
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
            if (results.Contains(true))
            {
                oCS.Result = true;
                oCS.AnswerString = PositiveAnswer(iCS);
            }
            else
            {
                oCS.Result = false;
                oCS.AnswerString = NegativeAnswer(iCS);
            }
            return oCS;
        }
    }
}
