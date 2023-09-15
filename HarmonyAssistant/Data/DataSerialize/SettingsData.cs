using HarmonyAssistant.Data.DataSerialize.Base;
using HarmonyAssistant.Data.DataSerialize.SerializeObjects;
using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Windows;

namespace HarmonyAssistant.Data.DataSerialize
{
    public class SettingsData : BaseDataSerialize<SettingsObject>
    {
        #region Singleton

        private static SettingsData instance;

        public static SettingsData GetInstance()
        {
            if (instance == null)
                instance = new SettingsData();
            return instance;
        }

        #endregion

        private SettingsData() : base() { }

        public override void Initialize(
            string language = null,
            string fileName = "Settings.json")
        {
            base.Initialize(fileName);
            Deserialize();
        }
    }
}
