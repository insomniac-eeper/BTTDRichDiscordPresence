namespace BTTDRichDiscordPresence.Data;

public record CharacterRecord(int Id, string Name, string Animal)
{
    public record PrisonerRecord(int Id, string Name, string Animal) : CharacterRecord(Id, Name, Animal);
    public record NpcRecord(int Id, string Name, string Animal, string Job, string Workplace) : CharacterRecord(Id, Name, Animal);
};