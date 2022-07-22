using DungeonCrawl.Actors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Source.Actors
{
    public class Inventory
    {
        public  List<Actor> Items { get; private set; }

        public void AddItem(Actor item)
        {
            Items.Add(item);
        }
    }
}
