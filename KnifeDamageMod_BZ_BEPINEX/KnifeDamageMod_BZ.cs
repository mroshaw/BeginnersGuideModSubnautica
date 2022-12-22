using HarmonyLib;

namespace Mroshaw.KnifeDamageModBZ
{
    /// <summary>
    /// Class to mod the knife
    /// </summary>
    class KnifeDamageMod_BZ
    {
        [HarmonyPatch(typeof(Knife))]
        [HarmonyPatch("Start")]
        internal class PatchKnifeStart
        {
            [HarmonyPostfix]
            public static void Postfix(Knife __instance)
            {
                // Double the knife damage
                float knifeDamage = __instance.damage;
                float newKnifeDamage = knifeDamage * 2.0f;
                __instance.damage = newKnifeDamage;
                KnifeDamagePlugin.logger.LogInfo($"Knife damage was: {knifeDamage}, is now: {newKnifeDamage}");
            }
        }
    }
}
