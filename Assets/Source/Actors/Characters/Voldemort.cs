using Assets.Source.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Voldemort : Monster
    {
        protected override void SetHealth()
        {
            Health = 400;
        }

        public Voldemort()
        {
            SetHealth();
            Damage = 20;
        }

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

        protected override void OnDeath()
        {
            var player = ActorManager.Singleton.GetPlayer();
            player.RemoveSword(player.Inventory);
            Debug.Log("F*ck you...");
        }

        public override int DefaultSpriteId => 4;
        public override string DefaultName => "Voldemort";

        public override int Damage { get; set; }
    }
}