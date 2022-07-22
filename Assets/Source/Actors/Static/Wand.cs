using Assets.Source.Actors.Characters;
using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    public class Wand : Item
    {
        public override int DefaultSpriteId => 176;
        public override string DefaultName => "Wand";

        public int Damage = 10;

        public int GetDamage()
        {
            return Damage;
        }
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }
    }
}