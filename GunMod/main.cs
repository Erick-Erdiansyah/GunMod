using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using GunMod.Patches;

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
        private Patches.Menu Menu;
        private bool ShowMenu = true;
        

        internal ManualLogSource logSource;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            logSource = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            Menu = new Patches.Menu();

            logSource.LogInfo("Menu Loaded");

            harmony.PatchAll(typeof(Main));

            harmony.PatchAll(typeof(Patches.BlankAndGun));
            
            logSource.LogInfo("gun and God is loaded");

            //harmony.PatchAll(typeof(Patches.BlackFriday));
            //logSource.LogInfo("Black friday is loaded");


        }

        private void OnGUI()
        {
            if (ShowMenu)
            {
                Menu.Draw();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F8))
            {
                ShowMenu = !ShowMenu;
            }
        }

    }
}

