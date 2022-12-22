using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace Mroshaw.KnifeDamageModSN
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    public class KnifeDamagePlugin_SN : BaseUnityPlugin
    {
        private const string myGUID = "com.mroshaw.knifedamagemodsn";
        private const string pluginName = "Knife Damage Mod SN";
        private const string versionString = "1.0.0";

        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger = new ManualLogSource(pluginName);

        private void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo($"PluginName: {pluginName}, VersionString: {versionString} is loaded.");
            logger = Logger;
        }
    }
}
