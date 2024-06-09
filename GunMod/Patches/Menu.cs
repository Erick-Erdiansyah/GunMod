using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine;

namespace GunMod.Patches
{
    internal class Menu
    {
        private Rect windowRect = new Rect(100, 40, 250, 300);

        bool infinite = false;
        bool crit = false;
        bool noReload = false;
        string damage = "40";
        string critical = "3";

        public void Draw()
        {
            windowRect = GUILayout.Window(0, windowRect, DrawMenuWindow, "Gun Mod Menu by Librarian");
        }
        private void DrawMenuWindow(int windowID)
        {
            GUILayout.Label("Some mod Here");

            infinite = GUILayout.Toggle(infinite, "infinite ammo");
            AmmoAndCrit.Infinite = infinite;
            crit = GUILayout.Toggle(crit, " 100 % crit rate");
            AmmoAndCrit.Critical = crit;
            noReload = GUILayout.Toggle(noReload, "Add science cannon");
            AmmoAndCrit.Clipshot = noReload;

            GUILayout.BeginHorizontal();
            GUILayout.Label("Damage Modifier");
            damage = GUILayout.TextField(damage, 4);
            if (GUILayout.Button("OK"))
            {
                int.TryParse(damage,out int dmg);
                damage = dmg.ToString();
                AmmoAndCrit.DamageMod = dmg;
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Critical Modifier");
            critical = GUILayout.TextField(damage, 4);
            if (GUILayout.Button("OK"))
            {
                int.TryParse(critical, out int crt);
                critical = crt.ToString();
                AmmoAndCrit.DamageMod = crt;
            }
            GUILayout.EndHorizontal();

            GUI.DragWindow();
        }

    }
}
