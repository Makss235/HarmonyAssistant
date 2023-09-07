using HarmonyAssistant.Core.TTC;
using System;

namespace HarmonyAssistant.Core.Skills.Base
{
    public class Skill
    {
        protected string PositiveAnswer(ICS iCS)
        {
            var positiveAnswers = iCS.WordsObject.Answers.Positive;
            string pa = positiveAnswers[new Random().Next(positiveAnswers.Count)];
            return pa;
        }

        protected string NegativeAnswer(ICS iCS)
        {
            var negativeAnswers = iCS.WordsObject.Answers.Negative;
            string na = negativeAnswers[new Random().Next(negativeAnswers.Count)];
            return na;
        }
    }
}
