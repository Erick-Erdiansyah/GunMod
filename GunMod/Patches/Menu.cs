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

        bool Gog = false;
        bool Armor = false;
        bool WeaponStart = false;
        bool RandGun = false;
        bool Blank = false;
        bool infinite = false;
        bool crit = false;
        bool noReload = false;
        string blank = "1";
        string armor = "1";
        string damage = "40";
        string critical = "3";

        public void Draw()
        {
            windowRect = GUILayout.Window(0, windowRect, DrawMenuWindow, "GunMod by Librarian");
        }
        private void DrawMenuWindow(int windowID)
        {
            GUILayout.Label("Press F8 to open/close the menu");
            Gog = GUILayout.Toggle(Gog, "God Mode");
            BlankAndGun.GodMode = Gog;

            Armor = GUILayout.Toggle(Armor, "Activate Armor");
            BlankAndGun.Armor = Armor;

            GUILayout.BeginHorizontal();
            GUILayout.Label("Add Armor");
            armor = GUILayout.TextField(armor, 4);
            if (GUILayout.Button("OK"))
            {
                float.TryParse(armor, out float blnk);
                armor = blnk.ToString();
                BlankAndGun.armor = blnk;
            }
            GUILayout.EndHorizontal();

            WeaponStart = GUILayout.Toggle(WeaponStart, "Change the Starting weapon");
            GUILayout.Label("(ONLY WORK IN LOBBY)");
            BlankAndGun.StartingWeapon = WeaponStart;
            RandGun = GUILayout.Toggle(RandGun, "Change gun to random");
            BlankAndGun.RandomGun = RandGun;

            Blank = GUILayout.Toggle(Blank, "Activate Blank");
            BlankAndGun.blanks = Blank;

            GUILayout.BeginHorizontal();
            GUILayout.Label("Add Blanks");
            blank = GUILayout.TextField(blank, 4);
            if (GUILayout.Button("OK"))
            {
                int.TryParse(blank, out int blnk);
                blank = blnk.ToString();
                BlankAndGun.Blanks = blnk;
            }
            GUILayout.EndHorizontal();

            infinite = GUILayout.Toggle(infinite, "infinite ammo");
            AmmoAndCrit.Infinite = infinite;
            crit = GUILayout.Toggle(crit, " 100 % crit rate");
            AmmoAndCrit.Critical = crit;
            noReload = GUILayout.Toggle(noReload, "No reload");
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
            critical = GUILayout.TextField(critical, 4);
            if (GUILayout.Button("OK"))
            {
                float.TryParse(critical, out float crt);
                critical = crt.ToString();
                AmmoAndCrit.CriticalMod = crt;
            }
            GUILayout.EndHorizontal();

            GUI.DragWindow();
        }

    }
}
