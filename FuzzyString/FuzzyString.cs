using System.Text;

namespace FuzzyString
{
    public class FuzzyString
    {
        /// <summary>
        /// Минимальное значение коэффициента совпадения
        /// </summary>
        public decimal MinFuzzyValue { get; set; } = 0.6M;

        /// <summary>
        /// Возвращает результат нечеткого сравнения слов.
        /// </summary>
        /// <param name="firstWord">Первое слово.</param>
        /// <param name="secondWord">Второе слово.</param>
        /// <returns>Результат нечеткого сравения слов.</returns>
        public bool FuzzyWord(string firstWord, string secondWord)
        {
            var normFirstWord = NormalizeWord(firstWord).ToList();
            var normSecondWord = NormalizeWord(secondWord).ToList();

            int countFirstWord = normFirstWord.Count;
            int countSecondWord = normSecondWord.Count;

            int min = countSecondWord < countFirstWord ?
                countSecondWord : countFirstWord;
            int max = countSecondWord < countFirstWord ?
                countFirstWord : countSecondWord;

            List<int> values = new List<int>();
            for (int k = 0; k < min; k++)
            {
                if (normFirstWord[k] == normSecondWord[k]) values.Add(1);
                else if (k + 1 < min)
                {
                    if (normFirstWord[k] == normSecondWord[k + 1])
                    {
                        if (normSecondWord.Count == min)
                            min--;
                        normSecondWord.Remove(normSecondWord[k]);
                        values.Add(0);
                    }
                }
                else values.Add(0);
            }
            var sumValues = values.Sum();
            decimal ratio = Convert.ToDecimal(sumValues) / Convert.ToDecimal(max);
            return ratio >= MinFuzzyValue;
        }

        /// <summary>
        /// Приводит слово к нормальному виду:
        /// - в нижнем регистре
        /// - удалены не буквы и не цифры
        /// - удвлены пробелы
        /// </summary>
        /// <param name="sentence">Слово.</param>
        /// <returns>Нормализованное слово.</returns>
        private string NormalizeWord(string sentence)
        {
            var resultContainer = new StringBuilder(100);
            var lowerSentece = sentence.ToLower();
            foreach (var c in lowerSentece)
            {
                if (IsNormalChar(c))
                {
                    resultContainer.Append(c);
                }
            }

            return resultContainer.ToString();
        }

        /// <summary>
        /// Возвращает признак подходящего символа.
        /// </summary>
        /// <param name="c">Символ.</param>
        /// <returns>True - если символ - буква или цифра, False - иначе.</returns>
        private bool IsNormalChar(char c)
        {
            return char.IsLetterOrDigit(c);
        }

        /// <summary>
        /// Сравнивает два преложения.
        /// </summary>
        /// <param name="firstSentence">Первое предложение (эталон).</param>
        /// <param name="secondSentence">Второе предложение.</param>
        /// <returns>Слова из первого преложения, совпавшие и во втором.</returns>
        public string FuzzySentence(string firstSentence, string secondSentence)
        {
            List<string> splitingFirstSentence = firstSentence.Split(' ').ToList();
            List<string> splitingSecondSentence = secondSentence.Split(' ').ToList();

            List<string> stringsList = new List<string>();
            for (int i = 0; i < splitingFirstSentence.Count; i++)
            {
                for (int j = 0; j < splitingSecondSentence.Count; j++)
                {
                    if (FuzzyWord(splitingFirstSentence[i], splitingSecondSentence[j]))
                        stringsList.Add(splitingFirstSentence[i]);
                }
            }
            return string.Join(" ", stringsList);
        }

        /// <summary>
        /// Сравнивает два преложения и заменяет совпавшие слова 
        /// второго предложения на слова первого.
        /// </summary>
        /// <param name="firstSentence">Первое предложение (эталон).</param>
        /// <param name="secondSentence">Второе предложение.</param>
        /// <returns>Слова из первого преложения, совпавшие и во втором.</returns>
        public string ReplaceFuzzyWord(string firstSentence, string secondSentence)
        {
            List<string> splitingFirstSentence = firstSentence.Split(' ').ToList();
            List<string> splitingSecondSentence = secondSentence.Split(' ').ToList();

            for (int i = 0; i < splitingFirstSentence.Count; i++)
            {
                for (int j = 0; j < splitingSecondSentence.Count; j++)
                {
                    if (FuzzyWord(splitingFirstSentence[i], splitingSecondSentence[j]))
                    {
                        splitingSecondSentence[j] = splitingFirstSentence[i];
                    }
                }
            }
            return string.Join(" ", splitingSecondSentence);
        }
    }
}