namespace BTTDRichDiscordPresence.Patches;

using Events;
using HarmonyLib;

[HarmonyPatch]
public class CharacterManagePatches
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(CharacterManage), nameof(CharacterManage.SetProtagonist))]
    // ReSharper disable once InconsistentNaming
    public static void CharacterManage_SetProtagonist_Postfix(ref Character character)
    {
        EventManager.CharacterManageEvents.SetProtagonist(character);
    }
}