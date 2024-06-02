namespace BTTDRichDiscordPresence.Data;

/// <summary>
/// Map information relevant for rich presence.
/// </summary>
/// <param name="Id">In-game id.</param>
/// <param name="Name">English name of the location.</param>
public record struct MapRecord(int Id, string Name);