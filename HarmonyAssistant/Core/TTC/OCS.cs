using System.Windows;

namespace HarmonyAssistant.Core.TTC
{
    public struct OCS
    {
        public bool Result { get; set; }
        public string AnswerString { get; set; }
        public object AnswerPresenter { get; set; }

        public OCS(bool result, string answerString, object answerPresenter)
        {
            Result = result;
            AnswerString = answerString;
            AnswerPresenter = answerPresenter;
        }
    }
}
