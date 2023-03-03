using Magic.Framework.Schools;
using Magic.Framework.Spells.Effects;
using Microsoft.Xna.Framework;
using SpaceCore;
using SpaceShared;
using StardewValley;

namespace Magic.Framework.Spells
{
    internal class CharmSpell : Spell
    {
        /*********
        ** Public methods
        *********/
        public CharmSpell()
            : base(SchoolId.Eldritch, "charm") { }

        public override int GetManaCost(Farmer player, int level)
        {
            return 0;
        }

        public override IActiveEffect OnCast(Farmer player, int level, int targetX, int targetY)
        {
            var mobs = player.currentLocation.characters;
            int levelAmount = level * 2;

            foreach (var mob in mobs)
            {

                if (mob is StardewValley.NPC npc && player.GetCurrentMana() >= levelAmount && player.health >= 26)
                {
                    Log.Error("charm spell 2 fired");
                    player.changeFriendship(25, npc);
                    int manaToLoose = (levelAmount + 1) * -1;
                    player.AddMana(manaToLoose);
                    player.health -= 25;
                    player.AddCustomSkillExperience(Magic.Skill, levelAmount);
                    player.currentLocation.localSoundAt("jingle1", npc.getTileLocation());
                }
            }

            return null;
        }
    }
}
