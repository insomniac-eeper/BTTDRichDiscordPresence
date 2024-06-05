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
        this.discordRichPresence.OnSuccessfulConnection += this.OnSuccessfulDiscordClientConnection;
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
    /// Determines whether activity should be updated based on previous state and last update time.
    /// </summary>
    /// <returns>
    /// <c>true</c> if current state differs from last report and enough time has past from previous update,
    /// otherwise <c>false</c>.
    /// </returns>
    private bool ShouldUpdateActivity()
    {
        var now = DateTimeOffset.Now.ToUnixTimeSeconds();
        if (now - this.lastActivityUpdateTimestamp < Constants.UpdateActivityDelay)
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

    private void OnSuccessfulDiscordClientConnection()
    {
        // Setting initial presence
        this.UpdateRichPresence();
    }
}