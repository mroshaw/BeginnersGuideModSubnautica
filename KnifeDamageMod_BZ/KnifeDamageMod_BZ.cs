using HarmonyLib;
using Logger = QModManager.Utility.Logger;

namespace Mroshaw.KnifeDamageModBZ
{
    /// <summary>
    /// Class to mod the knife
    /// </summary>
    public static class KnifeDamageMod_BZ
    {
        [HarmonyPatch(typeof(Knife))]
        public static class Knife_Patch
        {
            [HarmonyPatch(nameof(Knife.Start))]
            [HarmonyPostfix]
            public static void Start_Postfix(Knife __instance)
            {
                // ### Enhancing the mod ###
                // Get the damage modifier
                float damageModifier = QMod.Config.KnifeModifier;

                // Double the knife damage
                float knifeDamage = __instance.damage;
                float newKnifeDamage = knifeDamage * damageModifier;
                __instance.damage = newKnifeDamage;

                // Write to the QMM log file
                Logger.Log(Logger.Level.Debug, $"Knife damage was: {knifeDamage}," +
                    $" is now: {newKnifeDamage}");
            }
        }
    }
}