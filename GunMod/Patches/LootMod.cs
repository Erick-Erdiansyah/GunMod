using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GunMod.Patches
{
    internal static class PickupOnCrack
    {
        [HarmonyPatch(typeof(PickupObject), MethodType.Getter)]
        [HarmonyPatch(nameof(PickupObject.PurchasePrice))]
        [HarmonyPostfix]
        static void Invincible(HealthPickup __instance, ref int __result)
        {
            try
            {
                __result = 1;
                __instance.healAmount = 3;
                __instance.armorAmount = 3;
            }
            catch (Exception e)
            {
                FileLog.Log(e.ToString());
            }
        }

    }
}
