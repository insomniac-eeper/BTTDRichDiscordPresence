namespace BTTDRichDiscordPresence.Patches;

using Events;
using HarmonyLib;

[HarmonyPatch]
public class GameProcessPatches
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(GameProcess), nameof(GameProcess.PassMinutes), typeof(TimePass))]
    // ReSharper disable once InconsistentNaming
    public static void GameProcess_PassMinutes_TimePass_Postfix(GameProcess __instance, ref TimePass timePass)
    {
        EventManager.GameProcessEvents.PassMinutes_TimePass(__instance, timePass);
    }
}