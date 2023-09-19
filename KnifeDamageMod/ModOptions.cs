using Nautilus.Json;
using Nautilus.Options.Attributes;

namespace DaftAppleGames.KnifeDamageMod
{
    /// <summary>
    /// Class to define options for our knife mode
    /// </summary>
    [Menu("Knife Damage Mod")]
    public class ModOptions : ConfigFile
    {
        // Damage Multiplier option
        [Slider("Damage Multiplier", 1.0f, 100.0f, DefaultValue = 1.0f, Format = "{0:F2}")]
        public float DamageMultiplier = 1.0f;
    }
}
