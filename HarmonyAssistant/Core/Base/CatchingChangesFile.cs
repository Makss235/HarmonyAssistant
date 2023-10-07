using System;
using System.IO;
using System.Threading;

namespace HarmonyAssistant.Core.Base
{
    /// <summary>Делегат функции-обработчика события изменения файла.</summary>
    /// <param name="textFile">Содержимое измененного файла.</param>
    public delegate void FileChangedHandler(string textFile);

    /// <summary>Класс, предоставляющий функционал 
    /// для отслеживания изменения файла.</summary>
    public class CatchingChangesFile
    {
        #region TextFile : string - Содержимое файла

        /// <summary>Содержимое файла.</summary>
        private string _TextFile = "";

        /// <summary>Содержимое файла.</summary>
        public string TextFile
        {
            get => _TextFile;
            set
            {
                _TextFile = value;
                FileChanged?.Invoke(TextFile);
            }
        }

        #endregion

        /// <summary>Поток, в котором происходит отслеживания изменений файла.</summary>
        public Thread CCFThread { get; set; }
        /// <summary>Событие, которое вызывается при изменении файла.</summary>
        public event FileChangedHandler FileChanged;

        /// <summary>Абсолютный путь до файла.</summary>
        private readonly string filePath;
        /// <summary>Поле, которое содержит значение, 
        /// запрещающее потоку завершиться.</summary>
        private bool canClose = false;

        /// <summary>Инициализирует новый объект класса CatchingChangesFile.</summary>
        /// <param name="filePath">Абсолютный путь до файла.</param>
        public CatchingChangesFile(string filePath)
        {
            // Инициализация полей и потока.
            this.filePath = filePath;
            CCFThread = new Thread(() => CatchChangeDateFile());
        }

        /// <summary>Запуск потока.</summary>
        public void Start() => CCFThread.Start();
        /// <summary>Остановка потока.</summary>
        public void Stop() => canClose = true;

        /// <summary>Отслеживание изменений файла.</summary>
        private void CatchChangeDateFile()
        {
            // Предыдущая дата изменения файла.
            DateTime previousWritingTime = File.GetLastWriteTime(filePath);

            while (!canClose)
            {
                string text = "";
                // Текущая дата изменения файла.
                DateTime currentWritingTime = File.GetLastWriteTime(filePath);
                // Если две даты равны,
                if (currentWritingTime == previousWritingTime)
                {
                    // То пропуск итерации.
                    Thread.Sleep(100);
                    continue;
                }
                // Если текущая больше предыдущей,
                else if (currentWritingTime > previousWritingTime)
                {
                    // Чтение файл.
                    text = OpenFile(filePath);
                    previousWritingTime = currentWritingTime;
                }

                // Проверка на пустоту.
                if (string.IsNullOrEmpty(text)) continue;
                TextFile = text;
                Thread.Sleep(30);
            }
        }

        /// <summary>Открытие файла и чтение.</summary>
        /// <param name="filePath">Абсолютный путь до файла.</param>
        /// <returns>Содержимое файла.</returns>
        private string OpenFile(string filePath)
        {
            while (!canClose)
            {
                // Попытка прочитать файл.
                try
                {
                    return File.ReadAllText(filePath);
                }
                catch (IOException)
                {
                    Thread.Sleep(1);
                    continue;
                }
            }
            return "";
        }
    }
}
