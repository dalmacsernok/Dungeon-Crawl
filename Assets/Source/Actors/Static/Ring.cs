using Assets.Source.Actors.Characters;
using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    public class Ring : Item
    {
        public override int DefaultSpriteId => 332;
        public override string DefaultName => "Ring";

        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }
    }
}
