namespace BTTDRichDiscordPresence.Patches;

using Events;
using HarmonyLib;

[HarmonyPatch]
public class BattleManagePatches
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(BattleManage), nameof(BattleManage.EndBattle))]
    // ReSharper disable once InconsistentNaming
    public static void BattleManage_EndBattle_Postfix(BattleManage __instance)
    {
        EventManager.BattleManage2Events.EndBattle(__instance);
    }
}