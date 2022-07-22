using Assets.Source.Actors.Characters;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Characters
{
    public class Dementor : Monster
    {
        private const float SPEED = 1.0f;
        private float counter;
        protected override void SetHealth()
        {
            Health = 60;
        }

        public Dementor()
        {
            SetHealth();
            Damage = 15;
            counter = SPEED;

        }

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

        protected override void OnUpdate(float deltaTime)
        {
            counter -= deltaTime;
            if (counter <= 0.0f)
            {

                TryMove(Utilities.RandomDir());
                counter = SPEED;
            }
        }

        protected override void OnDeath()
        {
            var player = ActorManager.Singleton.GetPlayer();
            player.RemoveSword(player.Inventory);
            Utilities.PlaySound("Avada");
            Debug.Log("Avada kedavra...");
        }

        public override int DefaultSpriteId => 9;
        public override string DefaultName => "Dementor";

        public override int Damage { get; set; }
    }
}
