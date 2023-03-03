using Magic.Framework.Schools;
using Microsoft.Xna.Framework;
using SpaceCore;
using StardewValley;

namespace Magic.Framework.Spells
{
    internal class CleanseSpell : Spell
    {
        /*********
        ** Public methods
        *********/
        public CleanseSpell()
            : base(SchoolId.Life, "cleanse") { }

        public override int GetManaCost(Farmer player, int level)
        {
            return 25;
        }



        public override int GetMaxCastingLevel()
        {
            return 1;
        }

        public override IActiveEffect OnCast(Farmer player, int level, int targetX, int targetY)
        {
            Game1.buffsDisplay.clearAllBuffs();
            player.currentLocation.localSoundAt("debuffSpell", player.getTileLocation());
            return null;
        }
    }
}
