// ReSharper disable InconsistentNaming
namespace BTTDRichDiscordPresence;

using Data;

using Discord;
using System;
using UnityEngine;

/// <summary>
/// Interacts with BTTD to determine rich discord presence.
/// </summary>
public class BTTDRichPresence : MonoBehaviour
{

    private DiscordRichPresence discordRichPresence;
    private GameStateEvaluator gameStateEvaluator;

    private GameStateRecord lastReportedGameState;

    private long lastActivityUpdateTimestamp;

    /// <summary>
    /// Runs once script is initialized regardless of enabled state.
    /// </summary>
    /// <remarks>
    /// This function ought to only be called once.
    /// </remarks>
    public void Awake()
    {
        this.gameStateEvaluator ??= new GameStateEvaluator();
        this.gameStateEvaluator.DefineHooks();
        this.discordRichPresence ??= new DiscordRichPresence();
        this.discordRichPresence.Start();
        lastActivityUpdateTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
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
        var now = DateTimeOffset.Now.ToUnixTimeSeconds();
        if (now - this.lastActivityUpdateTimestamp < 5)
        {
            return false;
        }

        lastActivityUpdateTimestamp = now;
        return gameStateEvaluator.GameState != lastReportedGameState;
    }

    private void UpdateRichPresence()
    {
        var gameState = gameStateEvaluator.GameState;
        var discordPresence = DiscordPresenceFromGamestateBuilder.BuildPresence(gameState);

        #if DEBUG
        Plugin.Log.LogWarning($"GameState: {gameState}");
        #endif

        this.discordRichPresence.SetPresence(
            discordPresence,
            resultCallback: result =>
            {
                if (result == Result.Ok)
                {
                    this.lastReportedGameState = gameState;
                    Plugin.Log.LogInfo($"Update Activity {result}");
                }
                else
                {
                    Plugin.Log.LogWarning($"Failed to update activity: {result}");
                }
            });
    }
}