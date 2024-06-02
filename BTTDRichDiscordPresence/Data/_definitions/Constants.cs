namespace BTTDRichDiscordPresence;

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
    internal const long AppId = 1245657071815364680;

    /// <summary>
    /// Delay between retries in seconds.
    /// </summary>
    internal const int RetryDelay = 5;

    /// <summary>
    /// Delay between updates in seconds.
    /// </summary>
    internal const int UpdateActivityDelay = 5;
}