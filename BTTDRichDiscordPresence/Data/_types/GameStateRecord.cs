namespace BTTDRichDiscordPresence.Data;

using JetBrains.Annotations;

/// <summary>
/// Describes the current and relevant to rich presence state of the game.
/// </summary>
/// <param name="Protagonist">Character the player is controlling.</param>
/// <param name="Map">Current location of the player.</param>
/// <param name="DateTime">Day and time infor for current save.</param>
/// <param name="IsInMainMenu">Whether the player is in the main menu.</param>
/// <param name="Battle">Battle information if character is in battle.</param>
/// <param name="Minigame">Minigame information if the character is currently playing.</param>
public record struct GameStateRecord(
    bool IsInMainMenu,
    MapRecord Map,
    [CanBeNull] CharacterRecord Protagonist = null,
    GameTime? DateTime = null,
    BattleRecord? Battle = null,
    MinigameRecord? Minigame = null
    );