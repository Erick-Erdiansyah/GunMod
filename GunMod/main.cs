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
        private Rect windowRect = new Rect(100, 40, 400, 300);
        private bool ShowMenu = true;
        bool infinite = false;
        bool critAmmo = false;
        string damage = "1";

        internal ManualLogSource logSource;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            logSource = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            logSource.LogInfo("Menu Loaded");

            harmony.PatchAll(typeof(Main));
            
            //harmony.PatchAll(typeof(Patches.BlankAndGun));
            //logSource.LogInfo("gun and shield is loaded");
            //harmony.PatchAll(typeof(Patches.BlackFriday));
            //logSource.LogInfo("Black friday is loaded");


        }

        private void OnGUI()
        {
            if (ShowMenu)
            {
                windowRect = GUILayout.Window(0, windowRect, DrawMenuWindow, "Gun Mod Menu by Librarian");
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F8))
            {
                ShowMenu = !ShowMenu;
            }
        }

        private void DrawMenuWindow(int windowID)
        {
            GUILayout.Label("Some mod Here");

            critAmmo = GUILayout.Toggle(critAmmo, "button for crit ammo");
            if (critAmmo)
            {
                harmony.PatchAll(typeof(Patches.AmmoAndCrit));
            }

            infinite = GUILayout.Toggle(infinite, "button for infinite ammo");
            AmmoAndCrit.Infinite = infinite;

            GUILayout.BeginHorizontal();
            GUILayout.Label("sum label ");
            damage = GUILayout.TextField(damage,3);
            if (GUILayout.Button("Button 2"))
            {
                int test = int.Parse(damage);
                Debug.LogError(test);
            }
            GUILayout.EndHorizontal();

            GUI.DragWindow();
        }
    }
}

