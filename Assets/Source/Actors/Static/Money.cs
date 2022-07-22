using Assets.Source.Actors.Characters;
using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    public class Money : Item
    {
        public override int DefaultSpriteId => 184;
        public override string DefaultName => "Money";

        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }
    }
}