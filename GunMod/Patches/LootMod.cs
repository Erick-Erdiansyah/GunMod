using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GunMod.Patches
{
    internal static class BlackFriday
    {
        [HarmonyPatch(typeof(PickupObject), MethodType.Getter)]
        [HarmonyPatch(nameof(PickupObject.PurchasePrice))]
        [HarmonyPostfix]
        static void Rich(ref int __result)
        {
            try
            {
                __result = 1;
            }
            catch (Exception e)
            {
                FileLog.Log(e.ToString());
            }
        }

    }
}
