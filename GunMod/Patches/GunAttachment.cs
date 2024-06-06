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
    internal class GunAttachment
    {
        [HarmonyPatch(nameof(Gun.reloadTime))]
        [HarmonyPostfix]
        static void Invincible(Gun __instance)
        {
            try
            {
                __instance.reloadTime = 0;
            }
            catch (Exception e)
            {
                var log = new ManualLogSource("logger");
                BepInEx.Logging.Logger.Sources.Add(log);
                log.LogInfo(e.ToString());
                BepInEx.Logging.Logger.Sources.Remove(log);
            }
        }

    }
}
