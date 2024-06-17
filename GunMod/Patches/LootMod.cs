using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GunMod.Patches
{
    internal static class BlackFriday
    {
        [HarmonyPatch(typeof(PickupObject), MethodType.Getter)]
        [HarmonyPatch(nameof(PickupObject.PurchasePrice))]
        [HarmonyPostfix]
        static void Postfix(ref int __result)
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

    // minimap not working 
    // I'll fix it when I have more time
    // or when I  remember lol
    [HarmonyPatch(typeof(Minimap),nameof(Minimap.RevealAllRooms))]
    internal static class RevealMap
    {
        [HarmonyPostfix]
        static void Postfix(Minimap __instance)
        {
            try
            {
              __instance.RevealAllRooms(true);
            }
            catch (Exception e)
            {
                Debug.LogError(e.ToString());
            }
        }

    }
}
