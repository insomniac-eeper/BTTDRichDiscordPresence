// ReSharper disable InconsistentNaming
namespace BTTDRichDiscordPresence;

using Discord;
using UnityEngine;

/// <summary>
/// Interacts with BTTD to determine rich discord presence.
/// </summary>
public class BTTDRichPresence : MonoBehaviour
{
    // TODO: Use following property for certain state checks.
#pragma warning disable CS0414 // Field is assigned but its value is never used
    private bool inGame;
#pragma warning restore CS0414 // Field is assigned but its value is never used

    private DiscordRichPresence discordRichPresence;

    private int currentMapId = -1;
    private int reportedMapId = -999;

    /// <summary>
    /// Runs once script is initialized regardless of enabled state.
    /// </summary>
    /// <remarks>
    /// This function ought to only be called once.
    /// </remarks>
    public void Awake()
    {
        this.DefineHooks();
        this.discordRichPresence ??= new DiscordRichPresence();
        this.discordRichPresence.Start();
    }

    /// <summary>
    /// Determines if the current state differs from the last reported state.
    /// </summary>
    public void Update()
    {
        if (this.ShouldUpdateActivity())
        {
            this.UpdateRichPresence();
        }

        this.discordRichPresence?.Update();
    }

    /// <summary>
    /// Determines if the current state differs from the last reported state.
    /// </summary>
    /// <returns>
    /// <c>true</c> if current state differs from last report, otherwise <c>false</c>.
    /// </returns>
    /// <remarks>
    /// Currently we only check map id. In the future we will want to have additional state checks.
    /// </remarks>
    private bool ShouldUpdateActivity()
    {
        return this.currentMapId != this.reportedMapId;
    }

    /// <summary>
    /// Gets slug for currently playing character corresponding to uploaded discord app assets and adds flavor text.
    /// </summary>
    /// <returns>
    /// A tuple containing two strings:
    /// - The first string is the slug for the protagonist character. This is a unique identifier for the character.
    /// - The second string is a descriptive string for the protagonist character, possibly used for display or logging purposes.
    /// </returns>
    private (string, string) GetProtagonistCharacterSlugs()
    {
        if (this.currentMapId == -1)
        {
            return (string.Empty, string.Empty);
        }

        // TODO: Check protagonist character
        // TODO: Determine how to detect when playing as Reed
        return ("thomas", "Playing Thomas");
    }

    private void UpdateRichPresence()
    {
        var gameDay = GameProcess.singleton?.allDay + 1;
        var detailString = gameDay == null ? string.Empty : $"Day {gameDay}";
        var (protagonistCharacterSlug, protagonistString) = this.GetProtagonistCharacterSlugs();

        Plugin.Log.LogInfo($"Setting presence for map {this.currentMapId}, {protagonistCharacterSlug}, {protagonistString}");

        var mapIdToSetOnSuccess = this.currentMapId;

        this.discordRichPresence.SetPresence(
            details: detailString,
            state: Constants.MapNames[this.currentMapId],
            largeImage: "main_menu",
            smallImage: protagonistCharacterSlug,
            smallText: protagonistString,
            resultCallback: result =>
            {
                if (result == Result.Ok)
                {
                    this.reportedMapId = mapIdToSetOnSuccess;
                    Plugin.Log.LogInfo($"Update Activity {result}");
                }
                else
                {
                    Plugin.Log.LogWarning($"Failed to update activity: {result}");
                }
            });
    }

    private void DefineHooks()
    {
        On.GameManage.ReadArchiveDataAndStartGame += (orig, gameManager, archiveId) =>
        {
            orig(gameManager, archiveId);
            this.currentMapId = MapManage.currentMap.id;
            this.inGame = true;
        };

        On.MapManage.SetCurrentMapAndShow += (orig, map) =>
        {
            orig(map);
            this.currentMapId = map.id;
        };

        On.Map.SetFocus += (orig, map, isFocus) =>
        {
            orig(map, isFocus);
            this.currentMapId = map.id;
        };

        On.GameManage.EndGameToReStart += (orig, gameManage, immediateStartId) =>
        {
            orig(gameManage, immediateStartId);
            this.inGame = false;
            this.currentMapId = -1;
        };
    }
}