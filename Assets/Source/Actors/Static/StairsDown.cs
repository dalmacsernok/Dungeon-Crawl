namespace DungeonCrawl.Actors.Static
{
    public class StairsDown : Actor
    {
        public override int DefaultSpriteId => 239;
        public override string DefaultName => "StairsDown";
        public override int Z => -1;
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }
    }
}
