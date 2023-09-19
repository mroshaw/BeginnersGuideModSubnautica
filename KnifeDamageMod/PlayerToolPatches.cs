using HarmonyLib;

namespace DaftAppleGames.KnifeDamageMod
{
    [HarmonyPatch(typeof(PlayerTool))]
    internal class PlayerToolPatches
    {
        [HarmonyPatch(nameof(PlayerTool.Awake))]
        [HarmonyPostfix]
        public static void Awake_Postfix(PlayerTool __instance)
        {
            // Check to see if this is the knife
            if (__instance.GetType() == typeof(Knife))
            {
                // Convert our instance to a Knife instance
                Knife knife = __instance as Knife;

                // Write a line to our debug log
                KnifeDamagePlugin.Log.LogDebug($"Knife damage is {knife.damage}");

                // Make the knife do 5 times more damage
                // knife.damage *= 5.0f;

                // Enhancing the mod - apply option modifier
                knife.damage *= KnifeDamagePlugin.ModOptions.DamageMultiplier;

                // Write a line to our debug log
                KnifeDamagePlugin.Log.LogDebug($"Knife damage increased to {knife.damage}");
            }
        }
    }
}
