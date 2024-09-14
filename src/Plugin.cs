namespace BTTDRichDiscordPresence;

using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

/// <summary>
/// <see cref="BasePlugin"/> to add Discord Rich Presence Support.
/// </summary>

[BepInAutoPlugin]
public partial class Plugin : BasePlugin
{
    /// <summary>
    /// Gets shared logging instance.
    /// </summary>
    public new static ManualLogSource Log { get; private set; }

    public override void Load()
    {
        Log = base.Log;
        base.Log.LogInfo($"Plugin {Id} is loaded!");

        this.AddComponent<BTTDRichPresence>();

        Harmony.CreateAndPatchAll(GetType().Assembly, Id);
    }
}