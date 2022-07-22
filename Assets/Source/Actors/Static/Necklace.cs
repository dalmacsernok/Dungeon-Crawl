using Assets.Source.Actors.Characters;
using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    public class Necklace : Item
    {
        public override int DefaultSpriteId => 428;
        public override string DefaultName => "Necklace";

        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }
    }
}
