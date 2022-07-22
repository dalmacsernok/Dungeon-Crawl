namespace DungeonCrawl.Actors.Static
{
    public class Bridge : Actor
    {
        public override int DefaultSpriteId => 255;
        public override string DefaultName => "Bridge";

        public override int Z => -1;

        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }
    }
}