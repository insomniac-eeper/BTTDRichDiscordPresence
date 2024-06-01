namespace BTTDRichDiscordPresence;

using Data;

/// <summary>
/// Interprets <see cref="GameStateRecord"/> to define <see cref="DiscordRichPresenceRecord"/>.
/// </summary>
/// <remarks>
/// Currently interprets each field of <see cref="GameStateRecord"/> separetely and does not consider situations where
/// they may affect each other. This may be a future improvement.
/// </remarks>
public static class PresenceBuilder
{
    private record struct DiscordImageDefinition(string Key, string Description);

    public static DiscordRichPresenceRecord BuildPresence(GameStateRecord gameState)
    {
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