namespace BTTDRichDiscordPresence.Data;

/// <summary>
/// Minigame information relevant for rich presence.
/// </summary>
/// <param name="Minigame">Enum referring to the minigame being played.</param>
public record struct MinigameRecord(MinigameEnum Minigame);