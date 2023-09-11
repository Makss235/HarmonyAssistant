using System;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Windows;

namespace HarmonyAssistant.Data.DataSerialize.Base
{
    public class BaseDataSerialize<T> where T : class
    {
        public event Action Serialized;

        protected string fileName;
        protected string language;
        protected string relativeFilePath;
        protected string fullFilePath;

        public virtual T JsonObject { get; set; }

        protected BaseDataSerialize()
        {
            Serialized += () => Deserialize();
        }

        public virtual void Initialize(string fileName, string language = null)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new Exception("file name is empty");
            this.fileName = fileName;
            if (string.IsNullOrEmpty(language))
                relativeFilePath = $"Files/{fileName}";
            else
            {
                this.language = language;
                relativeFilePath = $"Files/{this.language.ToUpper()}/{fileName}";
            }
            fullFilePath = Path.Combine(Environment.CurrentDirectory, relativeFilePath);
        }

        public virtual void Deserialize()
        {
            string allTextFronJson = File.ReadAllText(fullFilePath);
            JsonObject = JsonSerializer.Deserialize<T>(allTextFronJson);
        }

        public virtual async void Serialize()
        {
            File.WriteAllText(fullFilePath, string.Empty);
            using (FileStream fs = new FileStream(fullFilePath, FileMode.OpenOrCreate))
            {
                var options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                };
                await JsonSerializer.SerializeAsync(fs, JsonObject, options);
            }
            Serialized?.Invoke();
        }
    }
}
