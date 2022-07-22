using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Characters
{
    public abstract class Item : Actor
    {
        public override int Z => -1;
    }
}
