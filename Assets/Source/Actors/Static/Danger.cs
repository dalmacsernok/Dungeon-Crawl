using Assets.Source.Actors.Characters;
using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    public class Danger : Item
    {
        public override int DefaultSpriteId => 1043;
        public override string DefaultName => "Trap";

        public int Damage = 30;

        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }
    }
}
