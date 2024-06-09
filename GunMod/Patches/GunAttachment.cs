using BepInEx.Logging;
using HarmonyLib;
using HutongGames.PlayMaker.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GunMod.Patches
{
    [HarmonyPatch(typeof(Gun), MethodType.Getter)]
    internal class AmmoAndCrit
    {
        static public bool Infinite { get; set; }
        static public bool Clipshot { get; set; }
        static public bool Critical { get; set; }
        static public int DamageMod { get; set; }
        static public float CriticalMod { get; set; }

        [HarmonyPatch(nameof(Gun.ClipShotsRemaining))]
        [HarmonyPostfix]
        static void NoReload(Gun __instance,ref int __result)
        {
            try
            {
                if (Clipshot)
                {
                    __result = 100;
                    __instance.reloadTime = 0;
                }
                if (Critical)
                {
                    __instance.CriticalChance = 2;
                }

                __instance.InfiniteAmmo = Infinite;
                __instance.damageModifier = DamageMod;
                __instance.CriticalDamageMultiplier = CriticalMod;
            }
            catch (Exception e)
            {
                FileLog.Log(e.ToString());
            }
        }

    }

    [HarmonyPatch(typeof(PlayerController), MethodType.Getter)]
    internal static class BlankAndGun
    {
        static public int Blanks { get; set; }
        static public bool StartingWeapon { get; set; }
        static public bool GodMode { get; set; }
        static public bool RandomGun {get; set;}

        [HarmonyPatch(nameof(PlayerController.Blanks))]
        [HarmonyPostfix]
        static void None(PlayerController __instance,ref int __result)
        {
            try
            {
                if (GodMode)
                {
                    __instance.healthHaver.IsVulnerable = false;
                }
                if (StartingWeapon)
                {
                    __instance.startingGunIds.Clear();
                    // the strale gun = 542, yariLauncer = 16, cannon = 480 , dragunfire = 670 
                    __instance.startingGunIds.Add(542); // stratle
                    __instance.startingGunIds.Add(480); // cannon
                    __instance.startingPassiveItemIds.Add(137); // map
                }
                if (RandomGun)
                {
                    __instance.ChangeToRandomGun();
                    __instance.CharacterUsesRandomGuns = true;
                }
                __result = Blanks;

            }
            catch (Exception e)
            {
                Debug.LogError(e.ToString());
            }
        }

    }
}
