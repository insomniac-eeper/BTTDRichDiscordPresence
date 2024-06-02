namespace BTTDRichDiscordPresence.Data;

/// <summary>
/// Discord presence update information.
/// </summary>
/// <param name="Details">Topmost line in presence.</param>
/// <param name="State">Second line in presence.</param>
/// <param name="LargeImageKey">Asset key for large image to display. Can be a link.</param>
/// <param name="LargeImageText">Text displayed when hovering over large image.</param>
/// <param name="SmallImageKey">Asset key for small image to display on top of large images bottom right corner.
/// Can be a link.</param>
/// <param name="SmallImageText">Text displayed when hovering over small image.</param>
public record DiscordRichPresenceRecord(
    string Details,
    string State,
    string LargeImageKey,
    string LargeImageText,
    string SmallImageKey,
    string SmallImageText);