using HarmonyLib;

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
                // Double the knife damage
                float knifeDamage = __instance.damage;
                float newKnifeDamage = knifeDamage * 2.0f;
                __instance.damage = newKnifeDamage;
                KnifeDamagePlugin.logger.LogInfo($"Knife damage was: {knifeDamage}, is now: {newKnifeDamage}");
            }
        }
    }
}
