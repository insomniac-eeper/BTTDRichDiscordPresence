namespace BTTDRichDiscordPresence;

using BepInEx;
using UnityEngine;

/// <summary>
/// <see cref="BaseUnityPlugin"/> to add Discord Rich Presence Support.
/// </summary>
[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    /// <summary>
    /// Gets shared logging instance.
    /// </summary>
    public static BepInEx.Logging.ManualLogSource Log { get; private set; }

    private void Awake()
    {
        Log = this.Logger;
        this.Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

        var gObject = new GameObject(nameof(DiscordRichPresence));
        try
        {
            gObject.AddComponent<BTTDRichPresence>();
            GameObject.DontDestroyOnLoad(gObject);
        }
        catch (System.Exception e)
        {
            this.Logger.LogError($"Failed to create {nameof(DiscordRichPresence)}: {e}");
            GameObject.Destroy(gObject);
        }
    }
}