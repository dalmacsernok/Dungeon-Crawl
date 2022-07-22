using Assets.Source.Actors.Characters;
using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    public class GoldenCup : Item
    {
        public override int DefaultSpriteId => 723;
        public override string DefaultName => "GoldenCup";

        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }
    }
}