using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace Mroshaw.KnifeDamageModBZ
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    public class KnifeDamagePlugin : BaseUnityPlugin
    {
        private const string myGUID = "com.mroshaw.knifedamagemodbz";
        private const string pluginName = "Knife Damage Mod BZ";
        private const string versionString = "1.0.0";

        private static readonly Harmony harmony = new Harmony(myGUID);

        public static ManualLogSource logger;

        private void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "loaded.");
        }
    }
}