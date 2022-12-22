using HarmonyLib;
using BepInEx.Logging;

namespace Mroshaw.KnifeDamageModSN
{
    /// <summary>
    /// Class to mod the knife
    /// </summary>
    public static class KnifeDamageMod_SN
    {
        [HarmonyPatch(typeof(PlayerTool))]
        public static class PatchPlayerTool_Patches
        {
            [HarmonyPatch(nameof(PlayerTool.Awake))]
            [HarmonyPostfix]
            public static void Awake_Prefix(PlayerTool __instance)
            {
                // Check to see if this is the knife
                if (__instance.GetType() == typeof(Knife))
                {
                    Knife knife = __instance as Knife;
                    // Double the knife damage
                    float knifeDamage = knife.damage;
                    float newKnifeDamage = knifeDamage * 2.0f;
                    knife.damage = newKnifeDamage;
  
                    KnifeDamagePlugin_SN.logger.Log(LogLevel.Info, $"Knife damage was: {knifeDamage}," +
                        $" is now: {newKnifeDamage}");
                }
            }
        }
    }
}