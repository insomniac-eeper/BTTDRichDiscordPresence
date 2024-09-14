namespace BTTDRichDiscordPresence.Patches;

using Events;
using HarmonyLib;

[HarmonyPatch]
public class UIBattle2Patches
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(UI_Battle2), nameof(UI_Battle2.Awake))]
    // ReSharper disable once InconsistentNaming
    public static void UIBattle2_Awake_Postfix(UI_Battle2 __instance)
    {
        EventManager.UI_Battle2Events.Awake(__instance);
    }
}