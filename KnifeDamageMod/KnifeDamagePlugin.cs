using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Nautilus.Handlers;
using static OVRHaptics;

namespace DaftAppleGames.KnifeDamageMod
{
    [BepInPlugin(MyGuid, PluginName, VersionString)]
    public class KnifeDamagePlugin : BaseUnityPlugin
    {
        private const string MyGuid = "com.daftapplegames.knifedamagemod";
        private const string PluginName = "Knife Damage Mod";
        private const string VersionString = "1.0.0";

        private static readonly Harmony Harmony = new Harmony(MyGuid);

        public static ManualLogSource Log;

        // Enhancing the mod - declare static ModOptions for use elsewhere
        public static ModOptions ModOptions;

        private void Awake()
        {
            // Enhancing the mod - Set up our Mod Options
            ModOptions = OptionsPanelHandler.RegisterModOptions<ModOptions>();

            Harmony.PatchAll();
            Logger.LogInfo(PluginName + " " + VersionString + " " + "loaded.");
            Log = Logger;
        }
    }
}
