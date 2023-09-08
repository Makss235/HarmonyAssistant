using HarmonyAssistant.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyAssistant.Core.STT
{
    public class STT : StartPythonScript
    {
        #region Singleton

        private static STT instance;
        public static STT GetInstance()
        {
            if (instance == null)
                instance = new STT();
            return instance;
        }

        #endregion

        private STT() : base("stt", "main.py") { }
    }
}
