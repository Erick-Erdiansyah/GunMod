using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BepInEx;

namespace main.Patches
{
    [HarmonyPatch(typeof(HealthHaver),MethodType.Getter)]
    internal class UnlimitedArmor
    {
        [HarmonyPatch(nameof(HealthHaver.Armor))]
        [HarmonyPostfix]
        static void Invincible(ref float __result) 
        {
            try
            {
                __result = 20;
            }
            catch (Exception e) {
                var log = new ManualLogSource("logger");
                BepInEx.Logging.Logger.Sources.Add(log);
                log.LogInfo(e.ToString());
                BepInEx.Logging.Logger.Sources.Remove(log);
            }
        }

    }

}
