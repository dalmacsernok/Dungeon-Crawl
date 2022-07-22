using Assets.Source.Actors.Characters;
using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    public class Crown : Item
    {
        public override int DefaultSpriteId => 139;
        public override string DefaultName => "Crown";

        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }
    }
}