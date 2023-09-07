using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace HarmonyAssistant.Data.DataSerialize.Base
{
    public class BaseDataSerialize<T> where T : class
    {
        protected string language;
        protected string fileName;
        protected string path;

        public virtual T JsonObject { get; set; }

        protected BaseDataSerialize() { }

        public virtual void Initialize(string language, string fileName)
        {
            this.language = language;
            if (string.IsNullOrEmpty(fileName))
                throw new Exception("file name is empty");
            this.fileName = fileName;

            path = $"/Data/Resources/Files/{language.ToUpper()}/{fileName}";
        }

        public virtual void Deserialize()
        {
            var info = Application.GetResourceStream(new Uri(path, UriKind.Relative));
            string allTextFronJson;
            using (Stream stream = info.Stream)
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                allTextFronJson = Encoding.Default.GetString(buffer);
            }
            JsonObject = JsonSerializer.Deserialize<T>(allTextFronJson);
        }
    }
}
