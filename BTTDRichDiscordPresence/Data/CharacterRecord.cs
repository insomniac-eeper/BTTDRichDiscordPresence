namespace BTTDRichDiscordPresence.Data;

public record CharacterRecord(string Name, string Animal)
{
    public record PrisonerRecord(string Name, string Animal) : CharacterRecord(Name, Animal);
    public record NpcRecord(string Name, string Animal, string Job, string Workplace) : CharacterRecord(Name, Animal);
};