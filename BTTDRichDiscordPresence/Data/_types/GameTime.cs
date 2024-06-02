namespace BTTDRichDiscordPresence.Data;

/// <summary>
/// Represents the current game time for a save.
/// </summary>
/// <param name="Day">Day of current save. Should start at 1.</param>
/// <param name="Hours">Hour of the day of the current save.</param>
/// <param name="Minutes">Minutes of the hour of the day for the current save.</param>
public record struct GameTime(int Day, int Hours, int Minutes);