using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Actors.Static
{
    public class OpenedDoor : Door
    {
        public override int DefaultSpriteId => 147;
        public override string DefaultName => "OpenedDoor";

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Dementor)
            {
                return false;
            }
            return true;
        }

    }
}
