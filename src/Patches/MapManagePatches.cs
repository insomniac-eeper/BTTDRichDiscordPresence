namespace BTTDRichDiscordPresence.Patches;

using Events;
using HarmonyLib;

[HarmonyPatch]
public class MapManagePatches
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(MapManage), nameof(MapManage.SetCurrentMapAndShow))]
    // ReSharper disable once InconsistentNaming
    public static void MapManage_SetCurrentMapAndShow_Postfix(ref Map map)
    {
        EventManager.MapManageEvents.SetCurrentMapAndShow(map);
    }
}