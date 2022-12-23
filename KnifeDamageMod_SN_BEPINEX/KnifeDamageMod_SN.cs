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
        public static class PlayerTool_Patch
        {
            [HarmonyPatch(nameof(PlayerTool.Awake))]
            [HarmonyPostfix]
            public static void Awake_Prefix(PlayerTool __instance)
            {
                // Check to see if this is the knife
                if (__instance.GetType() == typeof(Knife))
                {
                    // Enhancing the MOD
                    // Get the damage multiplier from the config file.
                    float damageMultiplier = KnifeDamagePlugin_SN.ConfigKnifeDamageMultiplier.Value;

                    // Get the Knife instance
                    Knife knife = __instance as Knife;

                    // Apply the damage multiplier
                    float knifeDamage = knife.damage;
                    float newKnifeDamage = knifeDamage * damageMultiplier;
                    knife.damage = newKnifeDamage;
  
                    // Write to the BepInEx log
                    KnifeDamagePlugin_SN.logger.Log(LogLevel.Info, $"Knife damage was: {knifeDamage}," +
                        $" is now: {newKnifeDamage}");
                }
            }
        }
    }
}