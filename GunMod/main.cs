using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GunMod
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Main : BaseUnityPlugin
    {
        private const string modGUID = "Librarian.GunMod";
        private const string modName = "GunMod";
        private const string modVersion = "0.1.0";

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
            harmony.PatchAll(typeof(Patches.AmmoAndCrit));
            logSource.LogInfo("Amo And Crit is loaded");
            harmony.PatchAll(typeof(Patches.BlankAndGun));
            logSource.LogInfo("gun and shield is loaded");
            harmony.PatchAll(typeof(Patches.BlackFriday));
            logSource.LogInfo("Black friday is loaded");


        }
    }
}

