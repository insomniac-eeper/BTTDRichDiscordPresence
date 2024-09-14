namespace BTTDRichDiscordPresence.Patches;

using Events;
using HarmonyLib;

[HarmonyPatch]
public class GameManagePatches
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(GameManage), nameof(GameManage.ReadArchiveDataAndStartGame))]
    // ReSharper disable once InconsistentNaming
    public static void GameManage_ReadArchiveDataAndStartGame_Postfix(GameManage __instance)
    {
        EventManager.GameManageEvents.ReadArchiveDataAndStartGame();
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(GameManage), nameof(GameManage.EndGameToReStart))]
    // ReSharper disable once InconsistentNaming
    public static void GameManage_EndGameToReStart_Postfix(GameManage __instance)
    {
        EventManager.GameManageEvents.EndGameToReStart();
    }
}