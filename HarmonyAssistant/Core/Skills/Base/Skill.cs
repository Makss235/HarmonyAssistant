using HarmonyAssistant.Core.TTC;
using System;
using System.Collections.Generic;

namespace HarmonyAssistant.Core.Skills.Base
{
    /// <summary>Базовый класс навыков (skills) программы.</summary>
    public abstract class Skill
    {
        /// <summary>Случайно выбирает положительный ответ.</summary>
        /// <param name="iCS">Объект класса ICS, содержащий список ответов.</param>
        /// <returns>Строка, содержащая случайный положительный ответ.</returns>
        protected string PositiveAnswer(ICS iCS)
        {
            try
            {
                // Попытка выбрать случайный элемент.
                List<string> positiveAnswersList = iCS.WordsObject.Answers.Positive;
                string pasitiveAnswer = positiveAnswersList[new Random().Next(positiveAnswersList.Count)];
                return pasitiveAnswer;
            }
            catch
            {
                // В случае неудачи (произошла ошибка).
                return "Успешно";
            }
        }

        /// <summary>Случайно выбирает отрицательный ответ.</summary>
        /// <param name="iCS">Объект класса ICS, содержащий список ответов.</param>
        /// <returns>Строка, содержащая случайный отрицательный ответ.</returns>
        protected string NegativeAnswer(ICS iCS)
        {
            try
            {
                // Попытка выбрать случайный элемент.
                List<string> negativeAnswersList = iCS.WordsObject.Answers.Negative;
                string negativeAnswer = negativeAnswersList[new Random().Next(negativeAnswersList.Count)];
                return negativeAnswer;
            }
            catch
            {
                // В случае неудачи (произошла ошибка).
                return "Ошибка!";
            }
        }
    }
}
