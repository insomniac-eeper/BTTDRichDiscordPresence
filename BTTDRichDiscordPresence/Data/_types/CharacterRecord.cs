namespace BTTDRichDiscordPresence.Data;

/// <summary>
/// Character information relevant for rich presence.
/// </summary>
/// <param name="Id">Identifier used in-game.</param>
/// <param name="Name">English name of the character.</param>
/// <param name="Animal">English animal name of the character.</param>
public record CharacterRecord(int Id, string Name, string Animal)
{
    /// <summary>
    /// Prisoner character information.
    /// </summary>
    /// <inheritdoc cref="CharacterRecord"/>
    public record PrisonerRecord(int Id, string Name, string Animal) : CharacterRecord(Id, Name, Animal);

    /// <summary>
    /// Npc character information.
    /// </summary>
    /// <inheritdoc cref="CharacterRecord"/>
    /// <param name="Job">Job title.</param>
    /// <param name="Workplace">Job location.</param>
    public record NpcRecord(int Id, string Name, string Animal, string Job, string Workplace) : CharacterRecord(Id, Name, Animal);
};