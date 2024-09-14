namespace BTTDRichDiscordPresence;

using System.Reflection;
using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Il2CppInterop.Runtime.Injection;
using UnityEngine;

/// <summary>
/// <see cref="BasePlugin"/> to add Discord Rich Presence Support.
/// </summary>

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin
{
    /// <summary>
    /// Gets shared logging instance.
    /// </summary>
    public static BepInEx.Logging.ManualLogSource Log { get; private set; }

    public override void Load()
    {
        Log = base.Log;
        base.Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

        this.AddComponent<BTTDRichPresence>();

        Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
    }
}