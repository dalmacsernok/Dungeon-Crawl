using Assets.Source.Actors.Characters;
using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    public class Key : Item

    {
        public override int DefaultSpriteId => 559;
        public override string DefaultName => "Key";

        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }
    }
}
