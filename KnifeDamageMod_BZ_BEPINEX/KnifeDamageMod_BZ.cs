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
                // Enhancing the MOD
                // Get the damage multiplier from the config file.
                float damageMultiplier = KnifeDamagePlugin_BZ.ConfigKnifeDamageMultiplier.Value;

                // Apply the damage multiplier
                float knifeDamage = __instance.damage;
                float newKnifeDamage = knifeDamage * damageMultiplier;
                __instance.damage = newKnifeDamage;

                // Write to the BepInEx log
                KnifeDamagePlugin_BZ.logger.LogInfo($"Knife damage was: {knifeDamage}," +
                    $" is now: {newKnifeDamage}");
            }
        }
    }
}
