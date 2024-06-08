using BepInEx.Logging;
using HarmonyLib;
using HutongGames.PlayMaker.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GunMod.Patches
{
    [HarmonyPatch(typeof(Gun), MethodType.Getter)]
    internal static class AmmoAndCrit
    {
        [HarmonyPatch(nameof(Gun.ClipShotsRemaining))]
        [HarmonyPostfix]
        static void NoReload(Gun __instance,ref int __result)
        {
            try
            {
                __result = 100;
                __instance.InfiniteAmmo = true;
                __instance.reloadTime = 0;
                __instance.CriticalChance = 2;
                __instance.damageModifier = 50;
                __instance.CriticalDamageMultiplier = 20;
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
        [HarmonyPatch(nameof(PlayerController.Blanks))]
        [HarmonyPostfix]
        static void None(PlayerController __instance,ref int __result)
        {
            try
            {
                __result = 0;
                __instance.healthHaver.Armor = 10;
                __instance.startingGunIds.Clear();
                // the strale gun = 542, yariLauncer = 16, cannon = 480 , dragunfire = 670 
                __instance.startingGunIds.Add(542); // stratle
                __instance.startingGunIds.Add(480); // cannon
                __instance.startingPassiveItemIds.Add(137); // map
            }
            catch (Exception e)
            {
                FileLog.Log(e.ToString());
            }
        }

    }
}
