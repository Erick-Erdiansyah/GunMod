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
        [HarmonyPatch(nameof(Gun.AdjustedReloadTime))]
        [HarmonyPrefix]
        static void NoReload(Gun __instance,ref float __result)
        {
            try
            {
                __result = 0;
                __instance.blankDamageToEnemies = 100;
                __instance.InfiniteAmmo = true;
                __instance.reloadTime = 0;
                __instance.CriticalChance = 1;
                __instance.damageModifier = 20;
                __instance.CriticalDamageMultiplier = 10;
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
                __result = 3;
                __instance.startingGunIds.Clear();
                __instance.startingGunIds.Add(542);
            }
            catch (Exception e)
            {
                FileLog.Log(e.ToString());
            }
        }

    }
}
