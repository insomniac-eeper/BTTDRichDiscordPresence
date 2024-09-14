namespace BTTDRichDiscordPresence;

using Data;
using Events;

/// <summary>
/// Maintains a record of the current game state by using runtime detours on in-game functions.
/// </summary>
public class GameStateEvaluator
{
    /// <summary>
    /// Gets the current game state.
    /// </summary>
    public GameStateRecord GameState { get; private set; } = new(
        IsInMainMenu: true,
        Map: Maps.Get(-1)
    );

    /// <summary>
    /// Subscribes to runtime detours to update the game state.
    /// </summary>
    /// <remarks>
    /// I'm not a huge fan of using a bunch of lambda expressions here, I'd rather have a method for each hook.
    /// </remarks>
    public void DefineHooks()
    {
        EventManager.GameManageEvents.OnReadArchiveDataAndStartGame += () =>
        {
            var time = TimeManage.FormatTime(GameProcess.singleton.gameTime);

            this.GameState = this.GameState with
            {
                IsInMainMenu = false,
                Map = Maps.Get(MapManage.currentMap.id),
                DateTime = new GameTime(time.day, time.hour, time.minute)
            };
        };

        EventManager.MapManageEvents.OnSetCurrentMapAndShow += map =>
        {
            this.GameState = this.GameState with
            {
                Map = Maps.Get(map.id)
            };
        };

        // This no longer seems to be used since SetFocus is no longer an accessible MapManaage function
        EventManager.MapManageEvents.OnSetFocus += map =>
        {
            this.GameState = GameState with
            {
                Map = Maps.Get(map.id)
            };
        };

        EventManager.GameManageEvents.OnEndGameToReStart += () =>
        {
            this.GameState = GameState with
            {
                IsInMainMenu = true,
                Map = Maps.Get(-1)
            };
        };

        EventManager.GameProcessEvents.OnPassMinutes_TimePass += (gameProcess, _) =>
        {
            var time = TimeManage.FormatTime(gameProcess.gameTime);
            this.GameState = GameState with
            {
                DateTime = new GameTime(gameProcess.allDay + 1, time.hour, time.minute)
            };
        };

        EventManager.UI_Battle2Events.OnAwake += (uiBattle2) =>
        {
            var battleManage = uiBattle2.battleManage2;
            var protagonistFighter = battleManage.protagonistPlayer;
            var enemyFighter = battleManage.leftBattlePlayer == protagonistFighter ?
                battleManage.rightBattlePlayer :
                battleManage.leftBattlePlayer;

            var enemyCharacter = Characters.Get(enemyFighter.character.attribute.id);
            this.GameState = GameState with
            {
                Battle = new BattleRecord(enemyCharacter)
            };
        };

        EventManager.BattleManage2Events.OnEndBattle += (_) =>
        {
            this.GameState = GameState with
            {
                Battle = null
            };
        };

        // UI_Battle (as opposed to UI_Battle2) is used for spectating battles where the player is not involved.

        EventManager.CharacterManageEvents.OnSetProtagonist += (protagonist) =>
        {
            // Usually this protagonistId is set first via <see cref="InitManage"/> and then this function is called.
            // However since I am using this function to test and change characters I also need to set this here since
            // several checks rely on GameProcess.singleton.protagonistId.
            GameProcess.singleton.protagonistId = protagonist.attribute.id;
            this.GameState = GameState with
            {
                Protagonist = Characters.Get(protagonist.attribute.id)
            };
        };

        // When playing as Reed the protagonist doesn't change, rather the sprite and animation
        // of the protagonist do. Rather than expressing this nuance I chose to simply set the
        // gamestate with Reed as the protagonist and switch back when appropriate.
        EventManager.CharacterAnimationBasicConfigEvents.OnIsShowLeiDeClubPost += (ret, character) =>
        {
            //  This function is applied to all characters and run often so an early return is necessary.
            if (character.attribute.id != GameProcess.singleton.protagonistId)
            {
                return;
            }

            // If we no longer are playing as Reed we need to switch back to the original protagonist.
            if (ret == false)
            {
                var gameProtagonistId = GameProcess.singleton.protagonistId;
                // Since this function is run in perpetuity we may have already switched back to the original
                // protagonist, so we need to check if that is the case before creating another game state.
                if (this.GameState.Protagonist?.Id != gameProtagonistId)
                {
                    this.GameState = this.GameState with
                    {
                        Protagonist = Characters.Get(gameProtagonistId)
                    };
                }
            }
            else // We are playing as Reed
            {
                // If we have not yet changed the game state protagonist to Reed we need to so.
                if (this.GameState.Protagonist?.Id != 11017) // Reed's ID
                {
                    this.GameState = this.GameState with
                    {
                        Protagonist = Characters.Get(11017)
                    };
                }
            }
        };
    }
}