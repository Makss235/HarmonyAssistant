using HarmonyAssistant.Core;
using System;

namespace HarmonyAssistant
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            HarmonyApplication harmonyApplication = new HarmonyApplication();
            harmonyApplication.Run();
        }
    }
}
