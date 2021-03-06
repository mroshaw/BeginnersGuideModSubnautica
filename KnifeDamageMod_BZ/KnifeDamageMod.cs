using HarmonyLib;
using Logger = QModManager.Utility.Logger;

namespace KnifeDamageMod_BZ
{
    /// <summary>
    /// Class to mod the knife
    /// </summary>
    class KnifeDamageMod
    {
        [HarmonyPatch(typeof(Knife))]
        [HarmonyPatch("Start")]
        internal class PatchKnifeStart
        {
            [HarmonyPostfix]
            public static void Postfix(Knife __instance)
            {
                // ### Enhancing the mod ###
                // Get the damage modifier
                float damageModifier = QMod.Config.KnifeModifier;
                // Double the knife damage
                float knifeDamage = __instance.damage;
                float newKnifeDamage = knifeDamage * damageModifier;
                __instance.damage = newKnifeDamage;
                Logger.Log(Logger.Level.Debug, $"Knife damage was: {knifeDamage}," +
                    $" is now: {newKnifeDamage}");
            }
        }
    }
}
