using AngleSharp;
using AngleSharp.Dom;
using System.Net.Http;
using System.Threading.Tasks;

namespace HarmonyAssistant.Core.Parsers.Base
{
    /// <summary>Базовый класс парсера сайта.</summary>
    public abstract class Parser
    {
        /// <summary>Получение документа AngleSharp из строки, содержащую HTML-код страницы.</summary>
        /// <param name="pageString">Строка, содержащая HTML-код страницы.</param>
        /// <returns>Документ AngleSharp.</returns>
        protected IDocument GetDocumentFromString(string pageString)
        {
            return Task.Run(async () =>
            {
                var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
                return await context.OpenAsync(req => req.Content(pageString));
            }).Result;
        }

        /// <summary>Получение строки, содержащую HTML-код страницы, из URL-адреса страницы.</summary>
        /// <param name="url">URL-адрес страницы.</param>
        /// <returns>Строка, содержащая HTML-код страницы.</returns>
        protected string GetStringFromUrl(string url)
        {
            return Task.Run(async () =>
            {
                HttpClient client = new HttpClient();
                return await client.GetStringAsync(url);
            }).Result;
        }

        /// <summary>Выполнение парсинга страницы.</summary>
        public abstract void Parse();
    }
}
