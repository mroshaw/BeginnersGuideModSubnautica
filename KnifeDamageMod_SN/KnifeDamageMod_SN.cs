using HarmonyLib;
using Logger = QModManager.Utility.Logger;

namespace Mroshaw.KnifeDamageMod_SN
{
    public static class KnifeDamageMod_SN
    {
        [HarmonyPatch(typeof(PlayerTool))]
        public static class PlayerTool_Patch
        {
            [HarmonyPatch(nameof(PlayerTool.Awake))]
            [HarmonyPostfix]
            public static void Awake_Postfix(PlayerTool __instance)
            {
                // Check to see if this is the knife
                if (__instance.GetType() == typeof(Knife))
                {
                    Knife knife = __instance as Knife;

                    // ### Enhancing the mod ###
                    // Get the damage modifier
                    float damageModifier = QMod.Config.KnifeModifier;

                    // Double the knife damage
                    float knifeDamage = knife.damage;
                    float newKnifeDamage = knifeDamage * damageModifier;
                    knife.damage = newKnifeDamage;

                    // Write to the QMM log file
                    Logger.Log(Logger.Level.Debug, $"Knife damage was: {knifeDamage}," +
                        $" is now: {newKnifeDamage}");
                }
            }
        }
    }
}