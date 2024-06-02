namespace BTTDRichDiscordPresence;

using Data;

/// <summary>
/// Interprets <see cref="GameStateRecord"/> to define <see cref="DiscordRichPresenceRecord"/>.
/// </summary>
/// <remarks>
/// Currently interprets each field of <see cref="GameStateRecord"/> separetely and does not consider situations where
/// they may affect each other. This may be a future improvement.
/// </remarks>
public static class DiscordPresenceFromGamestateBuilder
{
    private record struct DiscordImageDefinition(string Key, string Description);

    /// <summary>
    /// Defines a <see cref="DiscordRichPresenceRecord"/> based on the given <see cref="GameStateRecord"/>.
    /// </summary>
    /// <param name="gameState">The current game state to evaluate.</param>
    /// <returns>Correspondingly generated <see cref="DiscordRichPresenceRecord"/>.</returns>
    public static DiscordRichPresenceRecord BuildPresence(GameStateRecord gameState)
    {
        // if map ID is Cell A103 when single cell is unlocked we are actually in A207
        if (gameState.Map.Id == 9 && CharacterManage.protagonistAttribute.IsSingleCell())
        {
            gameState = gameState with { Map = Maps.Get(8) }; // ID 8 is A207
        }

        var details = BuildDetailString(gameState);

        var smallImageDefinition = BuildSmallImageDefinition(gameState);
        var largeImageDefinition = BuildLargeImageDefinition(gameState);

        var state = BuildStateString(gameState);

        return new DiscordRichPresenceRecord(
            Details: details,
            State: state,
            LargeImageKey: largeImageDefinition.Key,
            LargeImageText: largeImageDefinition.Description,
            SmallImageKey: smallImageDefinition.Key,
            SmallImageText: smallImageDefinition.Description);
    }

    private static string BuildDetailString(GameStateRecord gameState)
    {
        return gameState.IsInMainMenu ?
            string.Empty :
            $"Day {gameState.DateTime?.Day} [{gameState.DateTime?.Hours}:{gameState.DateTime?.Minutes:D2}]";
    }

    private static DiscordImageDefinition BuildSmallImageDefinition(GameStateRecord gameState)
    {
        var protagonist = gameState.Protagonist;
        var protagonistAssetString = string.Empty;
        var protagonistAssetTextDescription = string.Empty;

        if (protagonist is not null)
        {
            protagonistAssetString = Assets.GetCharacterAssetString(protagonist);
            protagonistAssetTextDescription = $"Playing {protagonist.Name} the {protagonist.Animal}";
        }

        return new DiscordImageDefinition(
            Key: protagonistAssetString,
            Description: protagonistAssetTextDescription);
    }

    private static DiscordImageDefinition BuildLargeImageDefinition(GameStateRecord gameState)
    {
        var largeImageAssetString = Assets.GetMapAssetString(gameState.Map);
        var largeImageAssetTextDescription = gameState.Map.Name;

        return new DiscordImageDefinition(
            Key: largeImageAssetString,
            Description: largeImageAssetTextDescription);
    }

    private static string BuildStateString(GameStateRecord gameState)
    {
        string state;

        if (gameState.Battle is not null)
        {
            state = $"Battling {gameState.Battle?.Opponent.Name}";
            if (!string.IsNullOrEmpty(gameState.Battle?.Opponent.Animal))
            {
                state += $" the {gameState.Battle?.Opponent.Animal}";
            }
        }
        else
        {
            state = gameState.Map.Name;
        }

        return state;
    }
}