using Magic.Framework.Schools;
using Magic.Framework.Spells.Effects;
using Microsoft.Xna.Framework;
using SpaceCore;
using SpaceShared;
using StardewValley;
using xTile.Tiles;

namespace Magic.Framework.Spells
{
    internal class KilnSpell : Spell
    {
        /*********
        ** Public methods
        *********/
        public KilnSpell()
            : base(SchoolId.Elemental, "kiln") { }

        public override int GetManaCost(Farmer player, int level)
        {
            return 5;
        }

        public override bool CanCast(Farmer player, int level)
        {
            //Player needs wood or drift wood in the inventory
            int woodAmount = 9 - (level + 1) * 2;
            return base.CanCast(player, level) && (player.hasItemInInventory(StardewValley.Object.wood, woodAmount) || player.hasItemInInventory(169, woodAmount));
        }

        public override IActiveEffect OnCast(Farmer player, int level, int targetX, int targetY)
        {

            int woodAmount = 9 - (level + 1) * 2;
            if (player.hasItemInInventory(StardewValley.Object.wood, woodAmount))
            {
                player.consumeObject(StardewValley.Object.wood, woodAmount);
                Game1.createObjectDebris(StardewValley.Object.coal, player.getTileX(), player.getTileY(), player.currentLocation);
                player.currentLocation.localSoundAt("furnace", player.getTileLocation());
                player.AddCustomSkillExperience(Magic.Skill, 2 * (level + 1));
                return null;

            }

            if (player.hasItemInInventory(169, woodAmount))
            {
                player.consumeObject(169, woodAmount);
                Game1.createObjectDebris(StardewValley.Object.coal, player.getTileX(), player.getTileY(), player.currentLocation);
                player.currentLocation.localSoundAt("furnace", player.getTileLocation());
                player.AddCustomSkillExperience(Magic.Skill, 2 * (level + 1));
                return null;
            }
            return null;
        }
    }
}
