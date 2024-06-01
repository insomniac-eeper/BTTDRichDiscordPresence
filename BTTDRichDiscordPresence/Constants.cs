namespace BTTDRichDiscordPresence;

using System.Collections.Generic;

/// <summary>
/// General constants for the plugin.
/// </summary>
/// <remarks>
/// This class needs to be split into multiple classes that define constants according to their domain.
/// </remarks>
internal static class Constants
{
    /// <summary>
    /// Discord Application ID with name and assets;
    /// </summary>
    internal static long AppId { get; } = 1245657071815364680;

    /// <summary>
    /// Maximum number of retries when failing to connect.
    /// </summary>
    internal static int MaxRetries { get; } = 5;

    /// <summary>
    /// Delay between retries in seconds.
    /// </summary>
    internal static int RetryDelay { get; } = 5;
}