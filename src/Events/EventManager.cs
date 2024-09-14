namespace BTTDRichDiscordPresence.Events;

using System;

public static class EventManager
{
    public static class GameManageEvents
    {
        public static event Action OnReadArchiveDataAndStartGame;
        public static event Action OnEndGameToReStart;

        public static void ReadArchiveDataAndStartGame()
        {
            Plugin.Log.LogWarning($"Called {nameof(ReadArchiveDataAndStartGame)}");
            OnReadArchiveDataAndStartGame?.Invoke();
        }
        public static void EndGameToReStart()
        {
            Plugin.Log.LogWarning($"Called {nameof(EndGameToReStart)}");
            OnEndGameToReStart?.Invoke();
        }
    }


    public static class MapManageEvents
    {
        public static event Action<Map> OnSetCurrentMapAndShow;
        public static event Action<Map> OnSetFocus;

        public static void SetCurrentMapAndShow(Map map)
        {
            Plugin.Log.LogWarning($"Called {nameof(SetCurrentMapAndShow)}");
            OnSetCurrentMapAndShow?.Invoke(map);
        }
        public static void SetFocus(Map map)
        {
            OnSetFocus?.Invoke(map);
        }
    }

    public static class GameProcessEvents
    {
        public static event Action<GameProcess, TimePass> OnPassMinutes_TimePass;

        public static void PassMinutes_TimePass(GameProcess gameProcess, TimePass timePass)
        {
            OnPassMinutes_TimePass?.Invoke(gameProcess, timePass);
        }
    }

    public static class  UI_Battle2Events
    {
        public static event Action<UI_Battle2> OnAwake;
        public static void Awake(UI_Battle2 uiBattle2)
        {
            OnAwake?.Invoke(uiBattle2);
        }
    }

    public static class BattleManage2Events
    {
        public static event Action<BattleManage> OnEndBattle;
        public static void EndBattle(BattleManage uiBattle2)
        {
            OnEndBattle?.Invoke(uiBattle2);
        }
    }

    public static class CharacterManageEvents
    {
        public static event Action<Character> OnSetProtagonist;
        public static void SetProtagonist(Character protagonist)
        {
            OnSetProtagonist?.Invoke(protagonist);
        }
    }

    public static class CharacterAnimationBasicConfigEvents
    {
        public static event Action<bool, Character> OnIsShowLeiDeClubPost;
        public static void IsShowLeiDeClubPost(bool returnValue, Character character)
        {
            OnIsShowLeiDeClubPost?.Invoke(returnValue, character);
        }
    }




}