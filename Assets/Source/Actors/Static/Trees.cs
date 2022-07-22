using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    public class Trees : Actor
    {
        public override int DefaultSpriteId => 50;
        public override string DefaultName => "Tree";
        public override int Z => -1;

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}