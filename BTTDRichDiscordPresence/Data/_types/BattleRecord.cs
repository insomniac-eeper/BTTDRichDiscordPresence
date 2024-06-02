namespace BTTDRichDiscordPresence.Data;

/// <summary>
/// Relevant battle data for rich presence.
/// </summary>
/// <param name="Opponent">Assuming the protagonist is fighting, this is the opponent.</param>
public record struct BattleRecord(CharacterRecord Opponent);