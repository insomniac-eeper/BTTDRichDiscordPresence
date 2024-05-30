// ReSharper disable InconsistentNaming
namespace BTTDRichDiscordPresence;

using System;
using Discord;
using JetBrains.Annotations;

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

    private int retries;
    private long lastAttemptTimestamp;

    /// <summary>
    /// Sets the presence for the discord client.
    /// </summary>
    /// <param name="details">First line in status.</param>
    /// <param name="state">Second line in status.</param>
    /// <param name="largeImage">Key to asset shown as a large image.</param>
    /// <param name="largeText">Text to show when hovering over large image.</param>
    /// <param name="smallImage">Key to asset shown as a small image on bottom right corner of large image.</param>
    /// <param name="smallText">Text to show when hovering over small image.</param>
    /// <param name="resultCallback">Callback to execute upon getting result of update.</param>
    public void SetPresence(
        string details = default,
        string state = default,
        string largeImage = default,
        string largeText = default,
        string smallImage = default,
        string smallText = default,
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
            Details = details,
            State = state,
            Timestamps = this.timestamps,
            Assets = new ()
            {
                LargeImage = largeImage,
                LargeText = largeText,
                SmallImage = smallImage,
                SmallText = smallText,
            },
        };

        activityManager.UpdateActivity(presence, resultCallback);
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
            if (this.lastAttemptTimestamp + Constants.RetryDelay < DateTimeOffset.Now.ToUnixTimeSeconds())
            {
                if (this.retries < Constants.MaxRetries)
                {
                    this.retries++;
                    _ = this.RegisterClient();
                }
                else
                {
                    Plugin.Log.LogWarning("Max retries for connecting to client reached.");
                    return;
                }
            }
        }

        this.client?.RunCallbacks();
    }

    private bool RegisterClient()
    {
        this.lastAttemptTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
        try
        {
            this.client = new Discord(Constants.AppId, (ulong)CreateFlags.Default);
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