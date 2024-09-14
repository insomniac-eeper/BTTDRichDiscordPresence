namespace BTTDRichDiscordPresence.Patches;

using Events;
using HarmonyLib;

[HarmonyPatch]
public class CharacterAnimationBasicConfigPatches
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(CharacterAnimationBasicConfig), nameof(CharacterAnimationBasicConfig.IsShowLeiDeClub))]
    // ReSharper disable once InconsistentNaming
    public static void CharacterAnimationBasicConfig_IsShowLeiDeClub_Postfix(ref Character character, bool __result)
    {
        EventManager.CharacterAnimationBasicConfigEvents.IsShowLeiDeClubPost(__result, character);
    }

}