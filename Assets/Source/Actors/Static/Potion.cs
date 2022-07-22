using Assets.Source.Actors.Characters;
using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    public class Potion : Item
    {
        public override int DefaultSpriteId => 569;
        public override string DefaultName => "Potion";

        public int Health = 5;

        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }
    }
}
