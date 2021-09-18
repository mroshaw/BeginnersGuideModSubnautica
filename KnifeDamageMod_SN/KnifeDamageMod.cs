using HarmonyLib;
using Logger = QModManager.Utility.Logger;


namespace KnifeDamageMod_SN
{
    class KnifeDamageMod
    {
        [HarmonyPatch(typeof(PlayerTool))]
        [HarmonyPatch("Awake")]
        internal class PatchPlayerToolAwake
        {
            [HarmonyPostfix]
            public static void Postfix(PlayerTool __instance)
            {
                // Check to see if this is the knife
                if (__instance.GetType() == typeof(Knife))
                {
                    Knife knife = __instance.GetComponent<Knife>();

                    // ### Enhancing the mod ###
                    // Get the damage modifier
                    float damageModifier = QMod.Config.KnifeModifier;

                    // Double the knife damage
                    float knifeDamage = knife.damage;
                    float newKnifeDamage = knifeDamage * damageModifier;
                    knife.damage = newKnifeDamage;
                    Logger.Log(Logger.Level.Debug, $"Knife damage was: {knifeDamage}," +
                        $" is now: {newKnifeDamage}");
                }
            }
        }
    }
}
