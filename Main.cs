using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using main.Patches;

namespace main
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Main : BaseUnityPlugin
    {
        private const string modGUID = "Librarian.Test";
        private const string modName = "GunMod";
        private const string modVersion = "0.0.1";

        private readonly Harmony harmony = new Harmony(modGUID);
        private static Main instance;

        internal ManualLogSource logSource;

        void Awake()
        {
            if (instance == null) 
            { 
                instance = this;
            }

            logSource = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            logSource.LogInfo("hello, I'll add something here later");

            harmony.PatchAll(typeof(Main));
            harmony.PatchAll(typeof(UnlimitedArmor));

        }
    }
}
