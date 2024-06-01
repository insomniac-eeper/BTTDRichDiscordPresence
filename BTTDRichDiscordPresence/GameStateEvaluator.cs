namespace BTTDRichDiscordPresence;

using Data;

/// <summary>
/// Maintains a record of the current game state by using runtime detours on in-game functions.
/// </summary>
public class GameStateEvaluator
{
    /// <summary>
    /// Gets the current game state.
    /// </summary>
    public GameStateRecord GameState { get; private set; }

    /// <summary>
    /// Subscribes to runtime detours to update the game state.
    /// </summary>
    public void DefineHooks()
    {
        On.GameManage.ReadArchiveDataAndStartGame += (orig, gameManager, archiveId) =>
        {
            orig(gameManager, archiveId);
            this.GameState = this.GameState with
            {
                IsInMainMenu = false,
                Map = Maps.Get(MapManage.currentMap.id)
            };
        };

        On.MapManage.SetCurrentMapAndShow += (orig, map) =>
        {
            orig(map);
            this.GameState = GameState with
            {
                Map = Maps.Get(map.id)
            };
        };

        On.Map.SetFocus += (orig, map, isFocus) =>
        {
            orig(map, isFocus);
            this.GameState = GameState with
            {
                Map = Maps.Get(map.id)
            };
        };

        On.GameManage.EndGameToReStart += (orig, gameManage, immediateStartId) =>
        {
            orig(gameManage, immediateStartId);
            this.GameState = GameState with
            {
                IsInMainMenu = true,
                Map = Maps.Get(-1)
            };
        };
    }
}