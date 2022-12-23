using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace Mroshaw.KnifeDamageModBZ
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    public class KnifeDamagePlugin_BZ : BaseUnityPlugin
    {
        private const string myGUID = "com.mroshaw.knifedamagemodbz";
        private const string pluginName = "Knife Damage Mod BZ";
        private const string versionString = "1.0.0";

        // Enhancing the MOD
        // Declare damage multiplier config entry
        public static ConfigEntry<float> ConfigKnifeDamageMultiplier;

        private static readonly Harmony harmony = new Harmony(myGUID);

        public static ManualLogSource logger;

        private void Awake()
        {
            // Enhancing the MOD
            // Setup damage multiplier config entry
            ConfigKnifeDamageMultiplier = Config.Bind("General",        // The section under which the option is shown
                "KnifeDamageMultiplier",                                // The key of the configuration option
                1.0f,                                                   // The default value
                "Knife damage multiplier.");   							// Description of the config value

            // Patch in our MOD
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "loaded.");
            logger = Logger;
        }
    }
}