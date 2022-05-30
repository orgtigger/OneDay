using Harmony;
using BattleTech.UI;
using System.Timers;
using BattleTech;
using BattleTech.UI.TMProWrapper;
using UnityEngine;

namespace OneDay.Patches
{

    //HandleEnterKeypress
    [HarmonyPatch(typeof(SGTimePlayPause), nameof(SGTimePlayPause.HandleEnterKeypress))]
    public static class SGTimePlayPause_Oneday_patch
    {
        public static bool onedaybool = false;

        public static void Postfix(SGTimePlayPause __instance)
        {
            var sim = UnityGameInstance.BattleTechGame.Simulation;

            

            if (__instance.TimeMoving)
            {
                __instance.SetTimeMoving(false);

            }
            else
            {
                __instance.SetTimeMoving(true);
                onedaybool = true;
            }

        }

    }

    [HarmonyPatch(typeof(SGTimePlayPause), nameof(SGTimePlayPause.SetDay))]
    public static class SGTimePlayPause_setday_patch
    {

        public static void Postfix(SGTimePlayPause __instance)
        {
            if (SGTimePlayPause_Oneday_patch.onedaybool)
            {
                __instance.SetTimeMoving(false);
                SGTimePlayPause_Oneday_patch.onedaybool = false;
            }
        }
    }

    //[HarmonyPatch(typeof(SGTimePlayPause), nameof(SGTimePlayPause.Init))]
    //public static class SGTimePlayPause_Init
    //{
    //    [SerializeField]
    //    public static HBSButton plusone = new HBSButton();


    //    public static void Postfix(SGTimePlayPause __instance)
    //    {


    //        plusone.enabled = true;
    //        //plusone.OnClicked += __instance.HandleEnterKeypress();
    //        plusone.SetText("+1");


    //    }

    //}

}
