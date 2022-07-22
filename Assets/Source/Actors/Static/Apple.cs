using Assets.Source.Actors.Characters;
using Assets.Source.Core;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Actors.Static
{
    public class Apple : Item
    {
        public override int DefaultSpriteId => 896;
        public override string DefaultName => "Apple";

        public int Health = 15;

        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }
    }
}
