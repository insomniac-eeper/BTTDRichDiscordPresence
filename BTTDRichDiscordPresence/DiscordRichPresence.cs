// ReSharper disable InconsistentNaming
namespace BTTDRichDiscordPresence;

using System;
using Discord;
using JetBrains.Annotations;

using Data;

/// <summary>
/// Simplified wrapper for Discord Game SDK to manage rich presence.
/// </summary>
public class DiscordRichPresence
{
    // ReSharper disable once InconsistentNaming
    [CanBeNull]
    [NonSerialized]
    private Discord client;

    private long startTimestamp;
    private ActivityTimestamps timestamps;

    private long lastAttemptTimestamp;

    /// <summary>
    /// Sets the presence for the discord client.
    /// </summary>
    /// <param name="presenceRecord">Simplified presence definition to be applied to rich presence.</param>
    /// <param name="resultCallback">Callback to execute upon getting result of update.</param>
    public void SetPresence(
        DiscordRichPresenceRecord presenceRecord,
        ActivityManager.UpdateActivityHandler resultCallback = default)
    {
        var activityManager = this.client?.GetActivityManager();
        if (activityManager == null)
        {
            Plugin.Log.LogWarning("Activity manager is null.");
            return;
        }

        var presence = new Activity()
        {
            Details = presenceRecord.Details,
            State = presenceRecord.State,
            Timestamps = this.timestamps,
            Assets = new ()
            {
                LargeImage = presenceRecord.LargeImageKey,
                LargeText = presenceRecord.LargeImageText,
                SmallImage = presenceRecord.SmallImageKey,
                SmallText = presenceRecord.SmallImageText,
            },
        };

        activityManager.UpdateActivity(presence, result =>
        {
            if (result == Result.NotRunning)
            {
                this.client?.Dispose();
                this.client = null;
            }
            resultCallback?.Invoke(result);
        });
    }

    /// <summary>
    /// Initializes the discord client and stores the start timestamp.
    /// </summary>
    public void Start()
    {
        this.startTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
        this.timestamps.Start = this.startTimestamp;

        // Creating the instance with the app id from discord
        this.RegisterClient();

        Plugin.Log.LogInfo("Client initialized.");
    }

    /// <summary>
    /// Runs the discord client callbacks and reconnect if null.
    /// </summary>
    /// <remarks>
    /// Currently there is no check for an initialized client but in a faulty state (e.g. disconnected).
    /// </remarks>
    public void Update()
    {
        if (this.client == null)
        {
            var now = DateTimeOffset.Now.ToUnixTimeSeconds();
            if (this.lastAttemptTimestamp + Constants.RetryDelay < now)
            {
                _ = this.RegisterClient();
                this.lastAttemptTimestamp = now;
            }
        }

        try
        {
            this.client?.RunCallbacks();
        }
        catch (Exception ex)
        {
            Plugin.Log.LogWarning("Failed to run callbacks: " + ex.Message);
            this.client?.Dispose();
            this.client = null;
        }

    }

    private bool RegisterClient()
    {
        this.lastAttemptTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
        try
        {
            this.client = new Discord(Constants.AppId, (ulong)CreateFlags.NoRequireDiscord);
            Plugin.Log.LogInfo("Client created.");
        }
        catch (Exception ex)
        {
            Plugin.Log.LogWarning("Failed to create client: " + ex.Message);
            return false;
        }

        return true;
    }
}