using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Actors.Static
{
    public class ClosedDoor : Door
    {
        public override int DefaultSpriteId => 146;
        public override string DefaultName => "ClosedDoor";

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

    }
}