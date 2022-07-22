using Assets.Source.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Skeleton : Monster
    {
        protected override void SetHealth()
        {
            Health = 25;
        }

        public Skeleton()
        {
            SetHealth();
            Damage = 2;
        }

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

        protected override void OnDeath()
        {
            var player = ActorManager.Singleton.GetPlayer();
            player.RemoveSword(player.Inventory);
            Debug.Log("Well, I was already dead anyway...");
        }

        public override int DefaultSpriteId => 316;
        public override string DefaultName => "Skeleton";

        public override int Damage { get; set; }
    }
}
