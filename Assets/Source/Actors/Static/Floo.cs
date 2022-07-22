using Assets.Source.Actors.Characters;
using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    public class Floo : Item
    {
        public override int DefaultSpriteId => 494;
        public override string DefaultName => "Floo";


        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }
    }
}
